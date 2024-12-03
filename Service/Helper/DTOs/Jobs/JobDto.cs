using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.DTOs.Jobs
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public List<string> Employees { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
