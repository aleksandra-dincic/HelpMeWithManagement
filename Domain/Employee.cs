using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string PictureUrl { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RoleName { get; set; }
        public DateTime Started { get; set; }
        public List<Department> Departments { get; set; } 
    }
}
