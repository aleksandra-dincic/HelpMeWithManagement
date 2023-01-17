using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string PictureUrl { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string RoleName { get; set; }
        public string Started { get; set; }
        public List<DepartmentModel> Departments { get; set; }
    }
}