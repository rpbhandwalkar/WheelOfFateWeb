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
    public class EmployeeHourService: BaseService, IEmployeeHourService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string employeeURL;
        public EmployeeHourService(IHttpClientFactory ClientFactory, IConfiguration configuration)
            : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            employeeURL = configuration.GetValue<string>("ServiceURLs:WheelOfFateAPI")+ "api/EmployeeJobManagement";
        }

        public Task<T> CreateAsync<T>(EmployeeWorkingHoursUpdateDTO CreateDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.POST,
                Data = CreateDto,
                Url = employeeURL

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.DELETE,
                Url = employeeURL + "/" + id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL 

            });
        }

        public Task<T> GetAsync<T>(int EmpID)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL+"/"+EmpID

            });
        }
        public Task<T> UpdateAsync<T>(EmployeeWorkingHoursUpdateDTO UpdateDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.PUT,
                Data = UpdateDto,
                Url = employeeURL + "/" + UpdateDto.Id

            });
        }
    }
}
