using WheelOfFate.Model;

namespace WheelOfFate.Services.Services.IServices
{
    public interface IShiftService
    {

        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int Id);
        Task<T> CreateAsync<T>(Shift Create);
        Task<T> UpdateAsync<T>(Shift Update);
        Task<T> DeleteAsync<T>(int id);
    }
}
