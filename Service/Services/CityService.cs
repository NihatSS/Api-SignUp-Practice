using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.Helper.DTOs.Cities;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repo;
        private readonly IMapper _mapper;
        public CityService(ICityRepository repo, 
                           IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CityCreateDto city)
        {
            await _repo.CreateAsync(_mapper.Map<City>(city));
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task EditAsync(int id, CityEditDto city)
        {
            var existCity = await _repo.GetByIdAsync(id, x=>x.Country);
            _mapper.Map(city,existCity);
            await _repo.EditAsync(existCity);
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _repo.GetAllAsync(m => m.Include(m => m.Country)));
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CityDto>(await _repo.GetByIdAsync(id,x=>x.Country));
        }
    }
}
