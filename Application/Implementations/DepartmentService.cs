using Application.Interfaces;
using Application.Models;
using Domain;
using Persistence.Repositories.Interfaces;

namespace Application.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task CreateDepartment(DepartmentModel department)
        {
            await _departmentRepository.CreateDepartment(new Department
            {
                Description = department.Description,
                Name = department.Name,
                Type = (DepartmentType)department.Type
            });
        }

        public async Task DeleteDepartment(string departmentId)
        {
            await _departmentRepository.DeleteDepartment(departmentId);
        }

        public async Task<List<EmployeeModel>> FindAllEmployeesInDepartment(string id)
        {
            List<Employee> employees = await _employeeRepository.FindAllEmployeesInDepartment(id);

            return employees.Select(x => new EmployeeModel
            {
                DateOfBirth = x.DateOfBirth.ToString(),
                FirstName = x.FirstName,
                LastName = x.LastName,
                PictureUrl = x.PictureUrl,
                RoleName = x.RoleName,
                Started = x.Started.ToString(),
                Id = x.Id
            }).ToList();
        }

        public async Task<List<DepartmentModel>> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartments();

            foreach (var department in departments)
            {
                department.Employees = await _employeeRepository.FindAllEmployeesInDepartment(department.Id);
            }

            return departments.Select(x => new DepartmentModel
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                TypeString = x.Type.ToString(),
                Employees = x.Employees.Select(y => new EmployeeModel
                {
                    DateOfBirth = y.DateOfBirth.ToString(),
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    PictureUrl = y.PictureUrl,
                    RoleName = y.RoleName,
                    Id = x.Id,
                    Started = y.Started.ToString()
                }).ToList()
            }).ToList();
        }

        public async Task<DepartmentModel> GetDepartment(string departmentId)
        {
            var department =  await _departmentRepository.GetDepartment(departmentId);

            return new DepartmentModel
            {
                Id = department.Id,
                Description = department.Description,
                Name = department.Name,
                TypeString = department.Type.ToString()
            };
        }

        public async Task<List<DepartmentModel>> SearchDepartments(string searchTerm)
        {
            var departments = await _departmentRepository.SearchDepartments(searchTerm);

            return departments.Select(x => new DepartmentModel
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                TypeString = x.Type.ToString()
            }).ToList();
        }

        public async Task UpdateDepartment(DepartmentModel department)
        {
            await _departmentRepository.UpdateDepartment(new Department
            {
                 Id= department.Id,
                 Description = department.Description,
                 Name = department.Name,
                 Type = (DepartmentType)department.Type
            });
        }
    }
}
