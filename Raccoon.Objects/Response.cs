using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Raccoon.Objects
{
    public class Response <T> where T: Common, new()
    {
        [JsonProperty("took", NullValueHandling = NullValueHandling.Ignore)]
        public long? TookMs { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public string Media { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<Result<T>> Results { get; set; }

        [JsonIgnore]
        public bool HasError
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Error);
            }
        }

        public static async Task<Response<T>> MakeRequest(string query)
        {
            #region Uri creation
            UriBuilder ub = new UriBuilder();
            ub.Scheme = "http";
            ub.Host = "localhost";  //TODO: address
            ub.Port = 1337;

            ub.Query = string.Format(
                "q={0}&m={1}", 
                WebUtility.UrlEncode(query), 
                WebUtility.UrlEncode(new T().MediaTypeName)
            );
            #endregion

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(ub.Uri, HttpCompletionOption.ResponseContentRead))
            {
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Response<T>>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    //May be error code but I want to parse the error
                    string respString = string.Empty;
                    try
                    {
                        respString = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(respString))
                        {
                            return JsonConvert.DeserializeObject<Response<T>>(respString);
                        }
                    }
                    catch
                    {
                        //TODO: handle error
                    }
                }
            }
            //All fails, give empty object with custom error
            Response<T> res = new Response<T>();
            res.Error = "Wrong request";
            //TODO: improve response
            return res;
        }
    }
}
