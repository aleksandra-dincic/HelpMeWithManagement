using Application.Interfaces;
using Application.Models;
using Domain;
using Persistence.Repositories.Interfaces;

namespace Application.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task AssignToDepartment(DepartmentAssignment departmentAssignment)
        {
            await _employeeRepository.AssignToDepartment(departmentAssignment.Employee, departmentAssignment.Department);
        }

        public async Task CreateEmployee(EmployeeModel employee)
        {
            DateTime dateOfBirth = DateTime.MinValue;
            DateTime started = DateTime.MinValue;

            bool birth = DateTime.TryParse(employee.DateOfBirth, out dateOfBirth);
            bool start = DateTime.TryParse(employee.Started, out started);

            await _employeeRepository.CreateEmployee(new Employee
            {
                DateOfBirth = dateOfBirth,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                RoleName = employee.RoleName,
                PictureUrl= employee.PictureUrl,
                Started = started,
                Departments = employee.Departments != null ? employee.Departments.Select(x => new Department
                {
                    Description = x.Description,
                    EmployeesCount = employee.Departments.Count,
                    Name = x.Name,
                    Id = x.Id,
                    Type = (DepartmentType)x.Type
                }).ToList() : new List<Department>()
            });
        }

        public async Task DeleteEmployee(string employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();

            return employees.Select(x => new EmployeeModel
            {
                DateOfBirth = x.DateOfBirth.ToString(),
                FirstName = x.FirstName,
                PictureUrl= x.PictureUrl,
                LastName = x.LastName,
                RoleName = x.RoleName,
                Id = x.Id,
                Started = x.Started.ToString()
            }).ToList();
        }

        public async Task<EmployeeModel> GetEmployee(string employeeId)
        {
            var domain =  await _employeeRepository.GetEmployee(employeeId);

            return new EmployeeModel
            {
                DateOfBirth = domain.DateOfBirth.ToString(),
                FirstName = domain.FirstName,
                PictureUrl = domain.PictureUrl,
                LastName = domain.LastName,
                RoleName = domain.RoleName,
                Started = domain.Started.ToString(),
                Id = domain.Id
            };
        }

        public async Task<List<EmployeeModel>> SearchEmployees(string searchTerm)
        {
            var employees = await _employeeRepository.SearchEmployees(searchTerm);

            return employees.Select(x => new EmployeeModel
            {
                DateOfBirth = x.DateOfBirth.ToString(),
                FirstName = x.FirstName,
                LastName = x.LastName,
                PictureUrl= x.PictureUrl,
                RoleName = x.RoleName,
                Id = x.Id,
                Started = x.Started.ToString()
            }).ToList();
        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            DateTime dateOfBirth = DateTime.MinValue;
            DateTime started = DateTime.MinValue;

            bool birth = DateTime.TryParse(employee.DateOfBirth, out dateOfBirth);
            bool start = DateTime.TryParse(employee.Started, out started);

            await _employeeRepository.UpdateEmployee(new Employee
            {
                Id = employee.Id,
                DateOfBirth = dateOfBirth,
                FirstName = employee.FirstName,
                PictureUrl= employee.PictureUrl,
                LastName = employee.LastName,
                RoleName = employee.RoleName,
                Started = started,
                Departments = employee.Departments != null ? employee.Departments.Select(x => new Department
                {
                    Description = x.Description,
                    EmployeesCount = employee.Departments.Count,
                    Name = x.Name,
                    Id = x.Id,
                    Type = (DepartmentType)x.Type
                }).ToList() : new List<Department>()
            });
        }
    }
}
