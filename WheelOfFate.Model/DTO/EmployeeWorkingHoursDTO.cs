using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WheelOfFate.Model;

namespace WheelOfFate.Models.DTO
{
    public class EmployeeWorkingHoursDTO
    {
        public int Id { get; set; }
        [Range(1,12)]
        [DisplayName("Working Shift")]
        public int WorkingShift{ get; set; }
        [Required]
        public int EmpsId { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Work Assigned Date")]
        public DateTime WorkedDate { get; set; }

    }
}
