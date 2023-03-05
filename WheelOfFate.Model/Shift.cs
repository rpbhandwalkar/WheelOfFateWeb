
using System.ComponentModel;

namespace WheelOfFate.Model
{
    public class Shift
    {
        public int Id { get; set; }
        [DisplayName("Shift Type")]
        public string ShiftType { get; set; }
    }
}
