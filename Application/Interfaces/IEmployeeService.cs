using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployee(EmployeeModel employee);
        Task DeleteEmployee(string employeeId);
        Task UpdateEmployee(EmployeeModel employee);
        Task<EmployeeModel> GetEmployee(string employeeId);
        Task<List<EmployeeModel>> GetAllEmployees();
        Task<List<EmployeeModel>> SearchEmployees(string searchTerm);
        Task AssignToDepartment(DepartmentAssignment departmentAssignment);
    }
}
