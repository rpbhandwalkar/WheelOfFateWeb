using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WheelOfFate.Models;
using WheelOfFate.Models.DTO;
using WheelOfFate.Services.Services.IServices;

namespace WheelOfFateWebApp.Controllers
{
    public class ShiftsController : Controller
    {
        IAllHoursService _allHoursService;
        private APIResponse _APIResponse;
        public ShiftsController(IAllHoursService allHoursService)
        {
            _allHoursService = allHoursService;
            _APIResponse = new();
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Merged> _data = new();

                var response = await _allHoursService.GetAllAsync<APIResponse>();
                if (response != null && response.IsSuccess)
                {
                    _data = JsonConvert.DeserializeObject<List<Merged>>
                        (Convert.ToString(response.Result));

                }


                return View(_data);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
