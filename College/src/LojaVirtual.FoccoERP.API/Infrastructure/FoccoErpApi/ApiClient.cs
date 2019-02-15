using Domain.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace Infrastructure.FoccoErpApi
{

    public class ApiClient
    {
        public readonly Settings _settings;

        public ApiClient(Settings settings)
        {
            _settings = settings;
        }

        public T ExecutePost<T>(string sufixUrl, object data)
        {
            return this.ExecutePost<T>(sufixUrl, data, null);
        }

        public T ExecutePost<T>(string sufixUrl, string token)
        {
            return this.ExecutePost<T>(sufixUrl, null, token);
        }

        public T ExecutePost<T>(string sufixUrl, object data, string token)
        {
            var requestUri = new Uri(BuildUrl(sufixUrl));

            string requestData = null;
            string responseData = null;

            try
            {
                requestData = data == null ? "{}" : JsonConvert.SerializeObject(data);

                using (var client = CreateWebClient(token))
                {
                    responseData = client.UploadString(requestUri, requestData);
                    var result = JsonConvert.DeserializeObject<T>(responseData);
                    return result;
                }
            }
            catch (WebException webException)
            {
                throw new Exception("Falha na resposta do webserver " + requestUri, webException);
            }
            catch (JsonSerializationException jsonSerializationException)
            {
                throw new Exception("Falha na tradução da resposta do webserver " + requestUri, jsonSerializationException);
            }
        }

        internal WebClient CreateWebClient(string token = null)
        {
            var client = new WebClientEx();
            client.Headers["Content-type"] = "application/json";
            client.Headers["DataServiceVersion"] = "3.0";
            client.Encoding = Encoding.UTF8;
            client.Proxy = null;

            if (!string.IsNullOrEmpty(token))
                client.Headers.Add("Authorization", string.Format("Bearer {0}", token));

            return client;
        }

        internal class WebClientEx : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = (HttpWebRequest)base.GetWebRequest(address);
                request.AutomaticDecompression = DecompressionMethods.Deflate;

                return request;
            }
        }

        internal string BuildUrl(string sufixUrl)
        {
            return this._settings.BaseUrl.TrimEnd('/') + '/' + sufixUrl.TrimStart('/');
        }
    }
}
