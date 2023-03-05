using AutoMapper;
using WheelOfFate.Models.DTO;

namespace WheelOfFateWebApp
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //ToString reverse map and avoid above 
            CreateMap<EmployeeDTO, EmployeeCreateDTO>().ReverseMap();
            CreateMap<EmployeeDTO, EmployeeUpdateDTO>().ReverseMap();
            CreateMap<EmployeeWorkingHoursDTO, EmployeeWorkingHoursUpdateDTO>().ReverseMap();
        }


    }
}
