using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Azure.Restful.Model;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class BaseProvider<T> where T : class,new()
    {
        protected SubscriptionAccount subscriptionAccount;
        protected BaseRestApiClient provider = null;

        public BaseProvider(SubscriptionAccount subscriptionAccount)
        {
            this.subscriptionAccount = subscriptionAccount;
            this.provider = ServiceManagementRestApiClient.Instance;
        }

        public BaseProvider()
            : this(null)
        {

        }


        public SubscriptionAccount Account
        {
            get { return subscriptionAccount; }
            set { subscriptionAccount = value; }
        }

        protected virtual string GenerateUrl(string urlTemplate, T entity)
        {
            return Regex.Replace(urlTemplate, @"{([a-zA-Z0-9\-]+)}", delegate(Match match)
            {
                string propName = match.Groups[1].Value.Replace("-", "");
                PropertyInfo property = typeof(T).GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null && entity != null)
                {
                    return property.GetValue(entity, null).ToString();
                }
                return "";
            });
        }

        protected virtual string GenerateUrl(string urlTemplate, params object[] paramters)
        {
            int index = 0;
            return Regex.Replace(urlTemplate, @"{([a-zA-Z0-9\-]+)}", delegate
                {
                    string result = "";
                    if (paramters.Length > index && paramters[index] != null)
                    {
                        result = paramters[index].ToString();
                    }
                    index++;
                    return result;
                });
        }

        public virtual IEnumerable<T> GetList()
        {
            string opName = "List" + typeof(T).Name;
            RequestInfo request = XmlProvider.CreateRequestInfo<T>(opName, null);
            return provider.GetResponseEntities<T>(subscriptionAccount, request);
        }

        public virtual T GetSingle(string name)
        {
            string opName = "Get" + typeof(T).Name;
            RequestInfo request = XmlProvider.CreateRequestInfo<T>(opName, null);
            request.Url = GenerateUrl(request.Url, name);
            return provider.GetResponseEntity<T>(subscriptionAccount, request);
        }

        public virtual bool Update(T entity)
        {
            string opName = "Update" + entity.GetType().Name;
            return DoWorkWithoutResponse(opName, entity);
        }

        public virtual bool Delete(T entity)
        {
            string opName = "Delete" + entity.GetType().Name;
            return DoWorkWithoutResponse(opName, entity);
        }

        public virtual bool Delete(string name)
        {
            string opName = "Delete" + typeof(T).Name;
            RequestInfo request = XmlProvider.CreateRequestInfo<T>(opName, null);
            request.Url = GenerateUrl(request.Url, name);
            try
            {
                provider.GetResponse(subscriptionAccount, request);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Create(T entity)
        {
            string opName = "Create" + entity.GetType().Name;
            return DoWorkWithoutResponse(opName, entity);
        }

        protected virtual string DoWorkWithResponse(string workName, T entity)
        {
            RequestInfo request = XmlProvider.CreateRequestInfo<T>(workName, entity);
            request.Url = GenerateUrl(request.Url, entity);
            return provider.GetResponse(subscriptionAccount, request);
        }

        protected virtual bool DoWorkWithoutResponse(string workName, T entity)
        {
            try
            {
                DoWorkWithResponse(workName, entity);
                return true;
            }
            catch
            {
                //todo:log the exception
                return false;
            }
        }
    }
}
