using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFate.Models.DTO
{
    public class MergedDTO
    {
        public int WorkingHourID { get; set; }
        public string Name { get; set; }
        public int EmpId { get; set; }
        public string ShiftType { get; set; }


    }
}
