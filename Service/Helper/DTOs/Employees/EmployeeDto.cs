namespace Service.Helper.DTOs.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public List<string> Jobs { get; set; }
        public string Image { get; set; }
        public string DepartmentName { get; set; }
    }
}
