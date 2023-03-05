using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFate.Models
{
    public class Merged
    {
        [DisplayName("ID")]
        public int WorkingHourID { get; set; }
        public string Name { get; set; }
        public int EmpId { get; set; }
        [DisplayName("Shifts Assigned")]
        public int Hours { get; set; }


    }
}
