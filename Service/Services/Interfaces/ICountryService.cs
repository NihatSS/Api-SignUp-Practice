using Service.Helper.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<CountryDto> GetByIdAsync(int id);
        Task CreateAsync(CountryCreateDto country);
        Task EditAsync(int id, CountryEditDto country);
        Task DeleteAsync(int id);
    }
}
