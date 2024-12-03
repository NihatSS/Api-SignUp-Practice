using Domain.Entities;
using Service.Helper.DTOs.Regions;

namespace Service.Services.Interfaces
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionDto>> GetAllAsync();
        Task<RegionDto> GetByIdAsync(int id);
        Task CreataAsync(RegionCreateDto region);
        Task DeleteAsync(int id);
        Task EditAsync(int id, RegionEditDto region);
    }
}
