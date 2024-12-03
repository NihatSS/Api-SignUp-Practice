using Service.Helper.DTOs.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<JobDto>> GetAllAsync();
        Task<JobDto> GetByIdAsync(int id);
        Task CreateAsync(JobCreateDto job);
        Task DeleteAsync(int id);
        Task EditAsync(int id, JobEditDto job);
    }
}
