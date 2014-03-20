using Azure.Restful.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Azure.Restful.Common
{
    public static class XmlProvider
    {

        public static string GetXmlTemplate(string name)
        {
            PropertyInfo property = typeof(XmlDefResource).GetProperty(name);
            if (property == null)
            {
                return string.Empty;
            }
            return property.GetValue(null, null).ToString();
        }

        public static RequestInfo CreateRequestInfo<T>(string name, T entity) where T : class,new()
        {
            string xml = GetXmlTemplate(name);
            return ToRequestInfo<T>(entity, xml);
        }

        public static T ToEntity<T>(string xml) where T : class,new()
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return ToEntity<T>(doc.LastChild);
        }

        public static T ToEntity<T>(XmlNode node) where T : class,new()
        {
            T entity = new T();
            FillEntityValue(entity, node);
            return entity;
        }

        public static object ConvertToType(string value, Type targetType)
        {
            try
            {
                Type underlyingType = Nullable.GetUnderlyingType(targetType);

                if (underlyingType != null)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        return null;
                    }
                }
                else
                {
                    underlyingType = targetType;
                }
                switch (underlyingType.Name)
                {
                    case "Guid":
                        return Guid.Parse(value);
                    default:
                        return Convert.ChangeType(value, underlyingType);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Convert {0} to target type {1} failed", value, targetType.ToString());
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private static void FillEntityValue<T>(T entity, XmlNode node)
        {
            Type t = entity.GetType();
            foreach (XmlNode cNode in node.ChildNodes)
            {
                if (cNode.NodeType == XmlNodeType.Text)
                {
                    continue;
                }
                PropertyInfo p = t.GetProperty(cNode.Name);
                if (p == null)
                {
                    Debug.WriteLine("Class [{0}] does not have property [{1}]", t.FullName, cNode.Name);
                    continue;
                }
                if (p.PropertyType.Namespace == "System")
                {
                    object obj = ConvertToType(cNode.InnerText, p.PropertyType);
                    if ( obj != null )
                    {
                        p.SetValue(entity, obj);
                    }
                }
                else
                {
                    var cValue = Activator.CreateInstance(p.PropertyType);
                    p.SetValue(entity, cValue);
                    if (IsGenericList(p.PropertyType))
                    {
                        Type ccType = p.PropertyType.GetGenericArguments()[0];
                        MethodInfo add = p.PropertyType.GetMethod("Add");
                        if (ccType.Namespace == "System")
                        {
                            foreach (XmlNode ccNode in cNode.ChildNodes)
                            {
                                var item = Convert.ChangeType(ccNode.InnerText, ccType);
                                add.Invoke(cValue, new object[] { item });
                            }
                        }
                        else
                        {
                            foreach (XmlNode ccNode in cNode.ChildNodes)
                            {
                                var item = Activator.CreateInstance(ccType);
                                FillEntityValue(item, ccNode);
                                add.Invoke(cValue, new object[] { item });
                            }
                        }
                    }
                    else
                    {
                        FillEntityValue(cValue, cNode);
                    }
                }
            }
        }

        public static IList<T> ToEntityList<T>(string xml) where T : class,new()
        {
            IList<T> list = new List<T>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode root = doc.LastChild;
            foreach (XmlNode cnode in root.ChildNodes)
            {
                list.Add(ToEntity<T>(cnode));
            }
            return list;
        }

        public static object GetValue<T>(T entity, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return entity;
            }
            string[] paths = path.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            object obj = entity;
            foreach (string p in paths)
            {
                try
                {
                    obj = obj.GetType().GetProperty(p).GetValue(obj);
                }
                catch
                {
                }
            }
            return obj;
        }

        public static RequestInfo ToRequestInfo<T>(T entity, string xmlTemplate)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlTemplate);
            XmlNode root = doc.LastChild;
            RequestInfo request = new RequestInfo { Url = root.Attributes["Url"].Value, Method = root.Attributes["Method"].Value };
            root.Attributes.RemoveNamedItem("Url");
            root.Attributes.RemoveNamedItem("Method");
            if (root.Name != "Empty")
            {
                SerializerStack<object> stack = new SerializerStack<object>();
                stack.Push(entity);
                foreach (XmlNode cnode in root.ChildNodes)
                {
                    FillXmlNode(cnode, stack);
                }
                RemoveEmptyChildNode(doc);
                request.RequestBody = doc.OuterXml;
            }

            return request;
        }

        private static XmlNode GetXmlNodeByCondition(object entity, IList<XmlNode> nodes)
        {
            if (nodes == null || nodes.Count == 0)
            {
                return null;
            }
            XmlNode result = null;
            if (nodes.Count == 1)
            {
                result = nodes[0];
            }
            else
            {
                foreach (XmlNode node in nodes)
                {
                    var cnode = node.SelectSingleNode("*[@Condition]");
                    if (cnode != null)
                    {
                        object propValue = GetValue(entity, cnode.Name);
                        if (propValue == null)
                        {
                            continue;
                        }
                        switch (cnode.Attributes["Condition"].Value.ToLower())
                        {
                            case "equalto":
                                if (propValue.ToString() == cnode.InnerText)
                                {
                                    result = node;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (result == null)
                {
                    result = nodes[0];
                }
            }
            XmlNode cloneNode = result.CloneNode(true);
            foreach (XmlNode cnode in cloneNode.ChildNodes)
            {
                if (cnode.Attributes != null)
                {
                    cnode.Attributes.RemoveNamedItem("Condition");
                }
            }
            return cloneNode;
        }

        private static void RemoveEmptyChildNode(XmlNode node)
        {
            int len = node.ChildNodes.Count;
            for (int idx = len - 1; idx >= 0; idx--)
            {
                var cnode = node.ChildNodes[idx];
                RemoveEmptyChildNode(cnode);
                if (!cnode.HasChildNodes)
                {
                    if (cnode.InnerText.Trim().Length == 0)
                    {
                        node.RemoveChild(cnode);
                    }
                }
            }
        }

        private static void FillXmlNode(XmlNode node, SerializerStack<object> stack)
        {
            XmlAttribute fromAttr = node.Attributes == null ? null : node.Attributes["From"];
            string from = fromAttr == null ? node.Name : fromAttr.Value;
            object parent = stack.Top();
            object current = GetValue(parent, from);
            if (!node.HasChildNodes || node.FirstChild.NodeType == XmlNodeType.Text)
            {
                node.InnerText = current == null ? "" : current.ToString();
            }
            else
            {
                if (current == null)
                {
                    node.InnerText = "";
                }
                else
                {
                    stack.Push(current);
                    if (IsGenericList(current.GetType()))
                    {
                        IList<XmlNode> rpNodes = new List<XmlNode>();
                        foreach (XmlNode rpcNode in node.ChildNodes)
                        {
                            rpNodes.Add(rpcNode);
                        }
                        node.RemoveAll();
                        IEnumerable list = current as IEnumerable;
                        foreach (var item in list)
                        {
                            XmlNode cloneNode = GetXmlNodeByCondition(item, rpNodes);
                            SerializerStack<object> nstack = new SerializerStack<object>();
                            nstack.Push(item);
                            node.AppendChild(cloneNode);
                            foreach (XmlNode ccNode in cloneNode.ChildNodes)
                            {
                                if (cloneNode.Name == "Role")
                                {
                                    Console.WriteLine(ccNode.Name);
                                }
                                FillXmlNode(ccNode, nstack);
                            }
                        }
                    }
                    else
                    {
                        foreach (XmlNode cnode in node.ChildNodes)
                        {
                            FillXmlNode(cnode, stack);
                        }
                    }
                    stack.Pop();
                }
            }
            if (fromAttr != null)
            {
                node.Attributes.RemoveNamedItem("From");
            }
        }

        public static bool IsGenericList(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            foreach (Type @interface in type.GetInterfaces())
            {
                if (@interface.IsGenericType)
                {
                    if (@interface.GetGenericTypeDefinition() == typeof(ICollection<>))
                    {
                        // if needed, you can also return the type used as generic argument
                        return true;
                    }
                }
            }
            return false;
        }
    }

    internal class SerializerStack<T> where T : class
    {
        private readonly List<T> stack;

        public SerializerStack()
        {
            stack = new List<T>();
        }

        public T Pop()
        {
            if (stack.Count == 0)
            {
                return null;
            }
            T v = stack.Last();
            stack.RemoveAt(stack.Count - 1);
            return v;
        }

        public void Push(T value)
        {
            stack.Add(value);
        }

        public T Top()
        {
            return stack.Last();
        }
    }

}
