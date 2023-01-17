using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class DepartmentModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public string TypeString { get; set; }
        public List<EmployeeModel> Employees { get; set; }
        public int EmployeesCount { get; set; }
    }
}
