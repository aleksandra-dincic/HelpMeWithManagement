using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistence.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateEmployee(Employee employee);
        Task DeleteEmployee(string employeeId);
        Task UpdateEmployee(Employee employee);
        Task<Employee> GetEmployee(string employeeId);
        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> SearchEmployees(string searchTerm);
        Task AssignToDepartment(string employee, string department);
        Task<List<Employee>> FindAllEmployeesInDepartment(string id);
    }
}
