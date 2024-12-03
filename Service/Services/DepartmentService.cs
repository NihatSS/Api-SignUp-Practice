using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.Helper.DTOs.Departments;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmnetRepository _repo;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmnetRepository repo,
                                 IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task CreateAsync(DepartmentCreateDto department)
        {
            await _repo.CreateAsync(_mapper.Map<Department>(department));
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task EditAsync(int id, DepartmentEditDto department)
        {
            var existDepartment = await _repo.GetByIdAsync(id);
            _mapper.Map(department,existDepartment);
            await _repo.EditAsync(existDepartment);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DepartmentDto>>(await _repo.GetAllAsync(m => m.Include(m => m.Location)));
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            return _mapper.Map<DepartmentDto>(await _repo.GetByIdAsync(id, x=>x.Location));
        }
    }
}
