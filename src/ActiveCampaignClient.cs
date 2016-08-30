using System;
using System.Collections.Specialized;
using System.Dynamic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ActiveCampaignNet
{
    public class ActiveCampaignClient
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
      
        public ActiveCampaignClient(string apiKey, string baseUrl)
        {
            if(string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));

            _apiKey = apiKey;
            _baseUrl = baseUrl;
        }
      
        private string CreateBaseUrl(string apiAction)
        {
            return $"{_baseUrl}/admin/api.php?api_action={apiAction}&api_key={_apiKey}&api_output=json";
        }

        private string PreparePayload(NameValueCollection payloads)
        {
            StringBuilder postData = new StringBuilder();

            foreach (var keyValue in payloads.AllKeys)
            {
                postData.AppendUrlEncoded(keyValue, payloads[keyValue]);
            }            

            return postData.ToString();
        }

        public ApiResult Api(string apiAction, NameValueCollection parameters)
        {
            var payload = PreparePayload(parameters);
            var uri = CreateBaseUrl(apiAction);

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                var rawData = wc.UploadString(uri, payload);

                var result = JsonConvert.DeserializeObject<ApiResult>(rawData);

                result.Data = rawData;

                return result;
            }
        }
    }
}
