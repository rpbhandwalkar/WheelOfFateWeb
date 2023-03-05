using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Model;
using WheelOfFate.Models.DTO;
using WheelOfFate.Services.Services.IServices;
using WheelOfFate.Utility;

namespace WheelOfFate.Services.Services
{
    public class MergedService: BaseService, IMergedService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string employeeURL;
        public MergedService(IHttpClientFactory ClientFactory, IConfiguration configuration)
            : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            employeeURL = configuration.GetValue<string>("ServiceURLs:WheelOfFateAPI");
        }


        

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL + "api/Merged"

            });
        }

        public Task<T> GetAllAsync<T>(int EmpId)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL + "api/Merged/" + EmpId

            });
        }

        
    }
}
