using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.Helper.DTOs.Countries;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repo;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repo,
                              IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CountryCreateDto country)
        {
            await _repo.CreateAsync(_mapper.Map<Country>(country));
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task EditAsync(int id, CountryEditDto country)
        {
            var existCountry = await _repo.GetByIdAsync(id);

            _mapper.Map(country, existCountry);
            await _repo.EditAsync(existCountry);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _repo.GetAllAsync(m => m.Include(m => m.Region)));
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CountryDto>(await _repo.GetByIdAsync(id, x=>x.Region));
        }
    }
}
