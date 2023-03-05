using Microsoft.AspNetCore.Mvc.Rendering;
using WheelOfFate.Models;
using WheelOfFate.Models.DTO;

namespace WheelOfFate.Model.VM
{
    public class EmplyeeHoursVM
    {
        public EmplyeeHoursVM()
        {
            employeeHours = new EmployeeWorkingHoursDTO();
            merged = new Merged();
         }
        public EmployeeWorkingHoursDTO employeeHours { get; set; }
        public Merged merged { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> List { get; set; }
    }
}
