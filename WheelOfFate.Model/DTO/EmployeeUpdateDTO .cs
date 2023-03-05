using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFate.Models.DTO
{
    public class EmployeeUpdateDTO
    {
        [Key] 
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        
       
    }
}
