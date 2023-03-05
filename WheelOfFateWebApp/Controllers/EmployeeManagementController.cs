using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Numerics;
using WheelOfFate.Model;
using WheelOfFate.Model.VM;
using WheelOfFate.Models;
using WheelOfFate.Models.DTO;
using WheelOfFate.Services.Services;
using WheelOfFate.Services.Services.IServices;

namespace WheelOfFateWebApp.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IShiftService _shiftService;
        private readonly IEmployeeHourService _service;
        private readonly IMergedService _mergedService;
        private readonly IMapper _mapper;

        public EmployeeManagementController(IEmployeeService employeeService, IMapper mapper,IMergedService mergedService, IEmployeeHourService service, IShiftService shiftService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _service = service;
            _shiftService = shiftService;
            _mergedService = mergedService;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeDTO> empDTO = new();
            var response = await _employeeService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                empDTO = JsonConvert.DeserializeObject<List<EmployeeDTO>>
                    (Convert.ToString(response.Result));
            }
            return View(empDTO);
        }


        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeCreateDTO createDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _employeeService.CreateAsync<APIResponse>(createDTO);
                if (response != null && response.IsSuccess)
                {
                    TempData["Success"] = "Employee added successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["Error"] = "There was an error adding employee please try again";
            return View(createDTO);
        }

        public async Task<IActionResult> EditEmployee(int EmpId)
        {
            if (EmpId != 0)
            {
                EmployeeUpdateDTO empDTO = new();
                var response = await _employeeService.GetAsync<APIResponse>(EmpId);
                if (response != null && response.IsSuccess)
                {
                    empDTO = JsonConvert.DeserializeObject<EmployeeUpdateDTO>
                        (Convert.ToString(response.Result));
                }
                return View(empDTO);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(EmployeeUpdateDTO updateDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _employeeService.UpdateAsync<APIResponse>(updateDTO);
                if (response != null && response.IsSuccess)
                {
                    TempData["Success"] = "Employee edited successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["Error"] = "Employee details coudnot be modified.\n please try again later ";
            return View(updateDTO);
        }

        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {

            EmployeeUpdateDTO empDTO = new();
            var response = await _employeeService.DeleteAsync<APIResponse>(EmpId);
            if (response != null && response.IsSuccess)
            {
                empDTO = JsonConvert.DeserializeObject<EmployeeUpdateDTO>
                    (Convert.ToString(response.Result));
                TempData["Success"] = "Deleting employee was successfully";
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> AssignHours(int EmpId)
        {
            EmplyeeHoursVM emplyeeHoursVM = new();
            List<Merged> empDTO = new();
            var response = await _mergedService.GetAllAsync<APIResponse>(EmpId);
            if (response != null && response.IsSuccess)
            {
                emplyeeHoursVM.merged = JsonConvert.DeserializeObject<List<Merged>>
                    (Convert.ToString(response.Result)).FirstOrDefault();


            }
            //
            response = await _shiftService.GetAllAsync<APIResponse>();
            //Shift shift = new();
            if (response != null && response.IsSuccess)
            {
                emplyeeHoursVM.List = JsonConvert.DeserializeObject<IEnumerable<Shift>>
                    (Convert.ToString(response.Result)).Select(x=>new SelectListItem { 
                    Text = x.ShiftType,
                    Value = x.Id.ToString(),
                    });
                //emplyeeHoursVM.List = (List<SelectListItem>)selectLists;
            }
            //var data = empDTO.FirstOrDefault();
            return View(emplyeeHoursVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignHours(EmplyeeHoursVM createDTO) {
            ModelState.Clear();
            List<string> strings = new List<string>();
            List<EmployeeWorkingHoursDTO> merge = new();
            APIResponse response = await _service.GetAsync<APIResponse>(createDTO.merged.EmpId);
            if (response != null && response.IsSuccess)
            {
                merge = JsonConvert.DeserializeObject<List<EmployeeWorkingHoursDTO>>
                    (Convert.ToString(response.Result));
            }
            //I am using datetime now for checking today and yesterday
            // for checking pursose please select createDTO.employeeHours.WorkedDate.Date.AddDays(-1)
            var datec = merge.Where(x => x.WorkedDate.Date == createDTO.employeeHours.WorkedDate.Date).Count();
            if (datec >= 1 )
            {
                strings.Add("Please apply one shift per day!");
                ModelState.AddModelError("OneShiftPerDay", "Please apply one shift per day!");
            }
            var date = DateTime.Now.Date.AddDays(-1);
            //I am using datetime now for checking today and yesterday
            // for checking pursose please select createDTO.employeeHours.WorkedDate.Date.AddDays(-1)
            
            if (merge.Where(x => x.WorkedDate.Date == createDTO.employeeHours.WorkedDate.Date.AddDays(-1)).Count() !=0 &&
                merge.Where(x => x.WorkedDate.Date == createDTO.employeeHours.WorkedDate.Date.AddDays(+1)).Count()!=0)
            {
                strings.Add("Cannot assign shift on Consecutive day!");
                ModelState.AddModelError("NoConsecutiveDayShift", "Cannot assign shift on Consecutive day!");
            }

            if (ModelState.IsValid)
            {
                //createDTO.employeeHours.Id = createDTO.merged.WorkingHourID;
                createDTO.employeeHours.EmpsId = createDTO.merged.EmpId;    
                EmployeeWorkingHoursUpdateDTO d = _mapper.Map<EmployeeWorkingHoursUpdateDTO>(createDTO.employeeHours);
                APIResponse resp = await _service.CreateAsync<APIResponse>(d);
                if (resp != null && resp.IsSuccess)
                {
                    TempData["Success"] = "Assign hours to employee was successfully";
                    return RedirectToAction(nameof(Index));
                    
                }
            }
            else
            {
                TempData["Error"] = string.Join(",", strings); ;
                return RedirectToAction("AssignHours", new { EmpId = createDTO.merged.EmpId });
            }

            return BadRequest();
            
        }

        

    }
}
