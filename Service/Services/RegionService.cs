using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Helper.DTOs.Regions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _repository;
        private readonly IMapper _mapper;

        public RegionService(IRegionRepository repository,
                               IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreataAsync(RegionCreateDto region)
        {
            await _repository.CreateAsync(_mapper.Map<Region>(region));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task EditAsync(int id, RegionEditDto region)
        {
            var existRegion = await _repository.GetByIdAsync(id);
            _mapper.Map(region, existRegion);
            await _repository.EditAsync(existRegion);
        }

        public async Task<IEnumerable<RegionDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<RegionDto>>(await _repository.GetAllAsync());
        }

        public async Task<RegionDto> GetByIdAsync(int id)
        {
            return _mapper.Map<RegionDto>(await _repository.GetByIdAsync(id));
        }
    }
}
