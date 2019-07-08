using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActiveCampaignNet
{
    public class ActiveCampaignClient
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private static readonly HttpClient HttpClient = new HttpClient();

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

        public async Task<ApiResult> ApiAsync(string apiAction, Dictionary<string, string> parameters)
        {
            //var payload = PreparePayload(parameters);
            var uri = CreateBaseUrl(apiAction);

            using (var postContent = new FormUrlEncodedContent(parameters))
            {
                using (HttpResponseMessage response = await HttpClient.PostAsync(uri, postContent))
                {
                    response.EnsureSuccessStatusCode(); //throw if httpcode is an error
                    using (HttpContent content = response.Content)
                    {
                        string rawData = await content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ApiResult>(rawData);
                        result.Data = rawData;
                        return result;
                    }
                }
            }
        }
    }
}
