using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WheelOfFate.Models.DTO;
using WheelOfFate.Models;
using WheelOfFate.Services.Services;
using WheelOfFate.Services.Services.IServices;
using System.Xml.Linq;
using WheelOfFate.Model;
using System.Collections.Generic;

namespace WheelOfFateWebApp.Controllers
{
    public class EmployeeHoursController : Controller
    {
        private readonly IMergedService _service;
        private readonly IShiftService _Shiftservice;
        private readonly IMapper _mapper;
        private APIResponse _APIResponse;

        public EmployeeHoursController(IMergedService service, IMapper mapper, IShiftService shiftservice)
        {
            _service = service;
            _mapper = mapper;
            _APIResponse = new();
            _Shiftservice = shiftservice;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<MergedDTO> _data = new();

                var response = await _service.GetAllAsync<APIResponse>();
                if (response != null && response.IsSuccess )
                {
                    _data = JsonConvert.DeserializeObject<List<MergedDTO>>
                        (Convert.ToString(response.Result));
                    
                }
                

                return View(_data);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }   

        //public async Task<IActionResult> DeleteAssignedHours(int id)
        //{
        //    var response = await _service.DeleteAsync<APIResponse>(id);
        //    if (response != null && response.IsSuccess) {
        //        TempData["Success"] = "Assigned Hours deleted successfully";
        //        return RedirectToAction(nameof(EmployeeManagementController), nameof(Index));
        //    }

        //    TempData["Error"] = "There was an error deleting hours please try again";
        //    return RedirectToAction(nameof(EmployeeManagementController), nameof(Index));
        //}

    }
}
