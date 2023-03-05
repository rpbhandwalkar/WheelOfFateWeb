using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Models.DTO;

namespace WheelOfFate.Services.Services.IServices
{
    public interface IMergedService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAllAsync<T>(int id);
       
    }
}
