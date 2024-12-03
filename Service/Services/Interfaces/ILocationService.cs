using Service.Helper.DTOs.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAllAsync();
        Task<LocationDto> GetByIdAsync(int id);
        Task CreateAsync(LocationCreateDto location);
        Task EditAsync(int id, LocationEditDto location);
        Task DeleteAsync(int id);
    }
}
