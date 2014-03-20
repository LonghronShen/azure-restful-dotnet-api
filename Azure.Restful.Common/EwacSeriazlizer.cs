using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Azure.Restful.Common
{
    public class EwacSeriazlizer
    {
        public static string ToXml<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static T ToObject<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml))
            {
                return (T)serializer.Deserialize(sr);
            }
        }

        public static byte[] ToBinary<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T ToObject<T>(byte[] binary)
        {
            using (MemoryStream ms = new MemoryStream(binary))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(ms);
            }
        }

        public static T ToObject<T>(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }
}
