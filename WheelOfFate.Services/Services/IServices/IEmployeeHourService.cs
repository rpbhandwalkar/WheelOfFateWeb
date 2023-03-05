using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Models.DTO;

namespace WheelOfFate.Services.Services.IServices
{
    public interface IEmployeeHourService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int EmpID);
        Task<T> CreateAsync<T>(EmployeeWorkingHoursUpdateDTO CreateDto);
        Task<T> UpdateAsync<T>(EmployeeWorkingHoursUpdateDTO UpdateDto);
        Task<T> DeleteAsync<T>(int id);
    }
}
