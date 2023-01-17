using Application.Models;

namespace Application.Interfaces
{
    public interface IDepartmentService
    {
        Task CreateDepartment(DepartmentModel department);
        Task DeleteDepartment(string departmentId);
        Task UpdateDepartment(DepartmentModel department);
        Task<DepartmentModel> GetDepartment(string departmentId);
        Task<List<DepartmentModel>> GetAllDepartments();
        Task<List<DepartmentModel>> SearchDepartments(string searchTerm);
        Task<List<EmployeeModel>> FindAllEmployeesInDepartment(string id);
    }
}