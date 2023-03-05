using AutoMapper;
using WheelOfFate.Model.DTO;

namespace WheelOfFateWebApplication
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //ToString reverse map and avoid above 
            CreateMap<EmployeeDTO, EmployeeCreateDTO>().ReverseMap();
            CreateMap<EmployeeDTO, EmployeeUpdateDTO>().ReverseMap();
        }


    }
}
