using Microsoft.Extensions.Configuration;
using WheelOfFate.Model;
using WheelOfFate.Services.Services.IServices;
using WheelOfFate.Utility;

namespace WheelOfFate.Services.Services
{
    public class ShiftService : BaseService, IShiftService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string employeeURL;
        public ShiftService(IHttpClientFactory ClientFactory, IConfiguration configuration)
            : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            employeeURL = configuration.GetValue<string>("ServiceURLs:WheelOfFateAPI");
        }

        public Task<T> CreateAsync<T>(Shift Create)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.POST,
                Data = Create,
                Url = employeeURL + "api/Shift"

            });
        }

        public Task<T> DeleteAsync<T>(int Id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.DELETE,
                Url = employeeURL + "api/Shift/" + Id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL + "api/Shift"

            });
        }

        public Task<T> GetAsync<T>(int Id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.GET,
                Url = employeeURL + "api/Shift/" + Id

            });
        }

        public Task<T> UpdateAsync<T>(Shift Update)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.API_Type.PUT,
                Data = Update,
                Url = employeeURL + "api/Shift/" + Update.Id

            });
        }
    }
}
