using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.Helper.DTOs.Jobs;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _repo;
        private readonly IMapper _mapper;
        public JobService(IJobRepository repo,
                          IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(JobCreateDto job)
        {
            await _repo.CreateAsync(_mapper.Map<Job>(job));
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task EditAsync(int id, JobEditDto job)
        {
            var existJob = await _repo.GetByIdAsync(id);
            _mapper.Map(job,existJob);
            await _repo.EditAsync(existJob);
        }

        public async Task<IEnumerable<JobDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<JobDto>>(await _repo.GetAllAsync(m=>m.Include(m=>m.JobHistories).ThenInclude(m=>m.Employee)));
        }

        public async Task<JobDto> GetByIdAsync(int id)
        {
            return _mapper.Map<JobDto>(await _repo.GetByIdAsync(id, x => x.JobHistories.Select(m => m.Employee)));
        }
    }
}
