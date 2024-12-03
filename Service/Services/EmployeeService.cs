using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using Service.Helper.DTOs.Employees;
using Service.Helper.DTOs.Jobs;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private AppDbContext _context;

        public EmployeeService(IEmployeeRepository repository,
                               IMapper mapper,
                               IFileService fileService,
                               AppDbContext context)
        {
            _fileService = fileService;
            _repo = repository;
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateAsync(EmployeeCreateDto employee)
        {
            var fileUrl = await _fileService.UploadAsync(employee.Image);

            await _repo.CreateAsync(_mapper.Map<Employee>(employee));
            await _context.SaveChangesAsync();

            foreach (var item in employee.JobIds)
            {
                var job = await _context.Jobs.FindAsync(item) ?? throw new NotFoundException(ExceptionMessages.NotFoundMessage);

                await _context.JobHistories.AddAsync(new JobHistory { JobId = job.Id, EmployeeId = _context.Employees.FirstOrDefaultAsync(x=>x.Name == employee.Name).Id,DepartmentId=employee.DepartmentId });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existEmployee = await _repo.GetByIdAsync(id);

            _fileService.DeleteAsync(existEmployee.Image.ToString());

            await _repo.DeleteAsync(id);
        }

        public async Task EditAsync(int id, EmployeeEditDto employee)
        {
            var existEmployee = _mapper.Map<EmployeeDto>(await _repo.GetByIdAsync(id));

            _fileService.DeleteAsync(existEmployee.Image.ToString());

            var fileUrl = await _fileService.UploadAsync(employee.Image);


            existEmployee.Image = fileUrl.Response;

            _mapper.Map(employee, _mapper.Map<Employee>(existEmployee));

            await _repo.EditAsync(_mapper.Map<Employee>(existEmployee));

        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EmployeeDto>>(await _repo.GetAllAsync(m => m.Include(m => m.Histories)
                                                                                       .ThenInclude(m => m.Job)
                                                                                       .Include(m=>m.Department)));
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            return _mapper.Map<EmployeeDto>(await _repo.GetByIdAsync(id,x=>x.Histories.Select(m=>m.Job)));

        }

        public async Task<IEnumerable<EmployeeDto>> SearchAsync(string str)
        {
            return _mapper.Map<IEnumerable<EmployeeDto>>(await _repo.GetAllWithExpression(m => m.Name.Trim().ToLower()
                                                                                              .Contains(str.Trim().ToLower())));
        }
    }
}
