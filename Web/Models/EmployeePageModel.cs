using Application.Models;

namespace Web.Models
{
    public class EmployeePageModel
    {
        public List<EmployeeModel> Employees { get; set; }
        public List<DepartmentModel> Departments { get; set; }
    }
}
