using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Model;
using WheelOfFate.Models;
using WheelOfFate.Services.Services.IServices;
using WheelOfFate.Utility;

namespace WheelOfFate.Services.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }

        public IHttpClientFactory httpClient { get; set; }
        //APIResponse IBaseService.responseModel { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = this.httpClient.CreateClient("MagicAPI");
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Headers.Add("Accept", "application/json");
                httpRequestMessage.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {

                    case SD.API_Type.POST:
                        httpRequestMessage.Method = HttpMethod.Post;

                        break;
                    case SD.API_Type.PUT:
                        httpRequestMessage.Method = HttpMethod.Put;

                        break;
                    case SD.API_Type.DELETE:
                        httpRequestMessage.Method = HttpMethod.Delete;
                        break;
                    default:
                        httpRequestMessage.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage responseMessage = null;
                responseMessage = await client.SendAsync(httpRequestMessage);
                var apiContent = await responseMessage.Content.ReadAsStringAsync();
                var APIresponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIresponse;

            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessage = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
