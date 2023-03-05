using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Model;
using WheelOfFate.Services.Services.IServices;
using WheelOfFate.Utility;

namespace WheelOfFate.Services.Services
{
    public class AllHoursService : BaseService, IAllHoursService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string employeeURL;
        public AllHoursService(IHttpClientFactory ClientFactory, IConfiguration configuration):base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            employeeURL = configuration.GetValue<string>("ServiceURLs:WheelOfFateAPI") + "api/AllHours";
        }
        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL

            });
        }
    }
}
