using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WheelOfFate.Models.DTO
{
    public class EmployeeWorkingHoursUpdateDTO
    {
        public int Id { get; set; }

        [DisplayName("Working Shift")]
        public int WorkingShift { get; set; }

        [Required]
        public int EmpsId { get; set; }

        [DataType(DataType.Date)]

        [DisplayName("Work Assigned Date")]
        public DateTime WorkedDate { get; set; }
        
    }
}
