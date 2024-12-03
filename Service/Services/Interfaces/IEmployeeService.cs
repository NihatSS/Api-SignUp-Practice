using Service.Helper.DTOs.Employees;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeCreateDto employee);

        Task<EmployeeDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(int id, EmployeeEditDto employee);
        Task<IEnumerable<EmployeeDto>> SearchAsync(string str);

        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}
