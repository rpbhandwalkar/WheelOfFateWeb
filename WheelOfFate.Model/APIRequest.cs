using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WheelOfFate.Utility.SD;

namespace WheelOfFate.Model
{
    public class APIRequest
    {
        public API_Type ApiType { get; set; } = API_Type.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
