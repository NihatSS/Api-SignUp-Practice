using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.Helper.DTOs.Locations;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repo;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository repo,
                               IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task CreateAsync(LocationCreateDto location)
        {
            await _repo.CreateAsync(_mapper.Map<Location>(location));
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<LocationDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<LocationDto>>(await _repo.GetAllAsync(m => m.Include(m => m.City)));
        }

        public async Task<LocationDto> GetByIdAsync(int id)
        {
            return _mapper.Map<LocationDto>(await _repo.GetByIdAsync(id, x=>x.City));
        }

        public async Task EditAsync(int id, LocationEditDto location)
        {
            var existLocation = await _repo.GetByIdAsync(id);
            _mapper.Map(location, existLocation);
            await _repo.EditAsync(existLocation);
        }
    }
}
