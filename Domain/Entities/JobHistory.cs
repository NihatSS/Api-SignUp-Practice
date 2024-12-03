using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
        public class JobHistory : BaseEntity
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int EmployeeId { get; set; }
            public Employee Employee { get; set; }
            public int JobId { get; set; }
            public Job Job { get; set; }
            public int DepartmentId { get; set; }
            public Department Department { get; set; }
        }
}
