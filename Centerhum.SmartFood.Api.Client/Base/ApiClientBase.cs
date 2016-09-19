using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Centerhum.SmartFood.Api.Client.Base
{
    public abstract class ApiClientBase
    {
    	
        private string _apiUrlBase;
        public string ApiUrlBase
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_apiUrlBase))
                {
                    _apiUrlBase = ConfigurationManager.AppSettings["ApiUrlBase"];
                }
                return _apiUrlBase;
            }
            set { value = _apiUrlBase; }
        }
        public string ControllerApi { get; private set; }

        private string _token = "";
        public string Token 
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_token))
                {
                    _token = ConfigurationManager.AppSettings["ApiToken"];
                }

                return _token;
            }
        }

        public ApiClientBase ()
	    {
            this.ApiUrlBase = ConfigurationManager.AppSettings["ApiUrlBase"];
	    }

        public ApiClientBase(string controller, string apiUrlBase = "")
        {
            this.ControllerApi = controller;
            this.ApiUrlBase = _apiUrlBase;
        }

        public TEntity CallApi<TEntity>(string controller, string methodApi, HttpMethods  method, Dictionary<string, object> parameters = null)
        {
            HttpResponseMessage response = null;
            StringContent contentBody;
            var stringContent = "";
            string json = "";

            using (var client = new HttpClient(new HttpClientHandler
                                    {
                                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                                    }))
            {
                client.BaseAddress = new Uri(ApiUrlBase + controller + "/" + methodApi);

                if (parameters != null && parameters.Count > 0)
                {
                    var getParameters = BuildQueryString(parameters);
                    client.BaseAddress = new Uri(ApiUrlBase + controller + "/" + methodApi + "?" + getParameters);
                }

                client.DefaultRequestHeaders.Add("token", Token);

                switch (method)
                {
                    case HttpMethods.GET:
                        response = client.GetAsync("").Result;
                        break;
                    case HttpMethods.POST:
                            parameters.Aggregate(stringContent, (current, parameter) => current + Serialize(parameter.Value));
                            contentBody = new StringContent(stringContent, Encoding.UTF8, "application/json");
                            response = client.PostAsync("", contentBody).Result;
                        break;
                    default:
                        break;
                }

                if (response != null)
                {
                    json = response.Content.ReadAsStringAsync().Result;
                }
            }

            return JsonConvert.DeserializeObject<TEntity>(json);
        }        

        #region [ Private Methods ]
        private string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(
                    obj,
                   Formatting.Indented,
                   new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore }
                 );
        }

        private static string BuildQueryString(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var queryString = "";
            var separator = "";
            foreach (var item in parameters)
            {
                if (queryString != "")
                    separator = "&";
                queryString += separator + item.Key + "=" + HttpUtility.UrlEncode(item.Value.ToString());
            }
            return queryString;
        } 
        #endregion
    }
}
