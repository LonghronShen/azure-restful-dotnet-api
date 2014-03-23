using Azure.Restful.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace Azure.Restful.Common
{
    public abstract class BaseRestApiClient
    {
        protected abstract string GetApiServiceEndpoint(SubscriptionAccount subscriptionAccount);
        protected abstract string ApiVersion { get; }

        private string GetResponse(SubscriptionAccount subscription, string url, string method, string requestBody, string contentType = null)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = method;
            request.ClientCertificates.Add(subscription.Certificate);
            request.ContentType = contentType ?? "application/xml";
            request.Headers.Add("x-ms-version", ApiVersion);

            HttpWebResponse response = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
                if (response != null)
                {
                    XmlDocument document = new XmlDocument();
                    string result;
                    using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
                    {
                        if (response.ContentLength > 0)
                        {
                            document.Load(reader);
                            result = document.OuterXml;
                        }
                        else
                        {
                            result = string.Empty;
                        }
                    }
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return result;
                    }
                    else
                    {
                        ApplicationException ex = new ApplicationException(string.Format("The request returned an error: Status Code:{0}({1}):{2}{3}", (int)response.StatusCode, response.StatusCode, Environment.NewLine, document));
                        ex.Data.Add("method", method);
                        ex.Data.Add("url", url);
                        ex.Data.Add("reqeustBody", requestBody);
                        ex.Data.Add("subscriptionId", subscription.SubscriptionId);
                        throw ex;
                    }
                }
                return null;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;

                if (response != null)
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                        {
                            string errorResponseString = reader.ReadToEnd();
                            throw new ApplicationException(errorResponseString);
                        }
                    }
                }
                return null;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        public string GetResponse(SubscriptionAccount subscription, RequestInfo request, string contentType = "")
        {
            request.Url = request.Url
                                 .Replace("[service-endpoint]", GetApiServiceEndpoint(subscription))
                                 .Replace("[subscription-id]", subscription.SubscriptionId.ToString());
            return GetResponse(subscription, request.Url, request.Method, request.RequestBody, contentType);
        }

        public T GetResponseEntity<T>(SubscriptionAccount subscription, RequestInfo request) where T : class,new()
        {
            string response = GetResponse(subscription, request);
            return string.IsNullOrEmpty(response) ? null : XmlProvider.ToEntity<T>(response);
        }

        public IList<T> GetResponseEntities<T>(SubscriptionAccount subscription, RequestInfo request) where T : class,new()
        {
            string response = GetResponse(subscription, request);
            return string.IsNullOrEmpty(response) ? null : XmlProvider.ToEntityList<T>(response);
        }

        public string Post(SubscriptionAccount subscription, string url, string requestBody)
        {
            return GetResponse(subscription, url, "POST", requestBody);
        }

        public string Get(SubscriptionAccount subscription, string url, string requestBody)
        {
            return GetResponse(subscription, url, "GET", requestBody);
        }

        public string Put(SubscriptionAccount subscription, string url, string requestBody)
        {
            return GetResponse(subscription, url, "PUT", requestBody);
        }

        public string Delete(SubscriptionAccount subscription, string url, string requestBody)
        {
            return GetResponse(subscription, url, "DELETE", requestBody);
        }
    }
}
