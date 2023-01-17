using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DepartmentType Type { get; set; }
        public List<Employee> Employees { get; set; }
        public int EmployeesCount { get; set; }
    }
}
