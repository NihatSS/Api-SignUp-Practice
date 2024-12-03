using Service.Helper.DTOs.Cities;

namespace Service.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(int id);
        Task CreateAsync(CityCreateDto city);
        Task EditAsync(int id, CityEditDto city);
        Task DeleteAsync(int id);
    }
}
