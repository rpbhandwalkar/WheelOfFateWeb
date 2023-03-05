using Microsoft.Extensions.Configuration;
using WheelOfFate.Model;
using WheelOfFate.Models.DTO;
using WheelOfFate.Services.Services.IServices;
using WheelOfFate.Utility;

namespace WheelOfFate.Services.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string employeeURL;
        public EmployeeService(IHttpClientFactory ClientFactory, IConfiguration configuration) 
            : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            employeeURL = configuration.GetValue<string>("ServiceURLs:WheelOfFateAPI");
        }

        public Task<T> CreateAsync<T>(EmployeeCreateDTO CreateDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.POST,
                Data = CreateDto,
                Url = employeeURL + "api/EmployeeManagement"

            });
        }

        public Task<T> DeleteAsync<T>(int EmpId)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.DELETE,
                Url = employeeURL + "api/EmployeeManagement/" + EmpId

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL + "api/EmployeeManagement"

            });
        }

        public Task<T> GetAsync<T>(int EmpId)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL + "api/EmployeeManagement/" + EmpId

            });
        }

        public Task<T> UpdateAsync<T>(EmployeeUpdateDTO UpdateDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.PUT,
                Data = UpdateDto,
                Url = employeeURL + "api/EmployeeManagement/" + UpdateDto.EmpId

            });
        }
    }
}
