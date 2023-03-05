using WheelOfFate.Models.DTO;

namespace WheelOfFate.Services.Services.IServices
{
    public interface IEmployeeService
    {   
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(EmployeeCreateDTO CreateDto);
        Task<T> UpdateAsync<T>(EmployeeUpdateDTO UpdateDto);
        Task<T> DeleteAsync<T>(int id);
    }
}
