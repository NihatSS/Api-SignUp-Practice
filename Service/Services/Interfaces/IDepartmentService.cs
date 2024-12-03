using Service.Helper.DTOs.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task CreateAsync(DepartmentCreateDto department);
        Task EditAsync(int id, DepartmentEditDto department);
    }
}
