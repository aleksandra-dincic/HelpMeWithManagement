using Domain;

namespace Persistence.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task CreateDepartment(Department department);
        Task DeleteDepartment(string departmentId);
        Task UpdateDepartment(Department department);
        Task<Department> GetDepartment(string departmentId);
        Task<List<Department>> GetAllDepartments();
        Task<List<Department>> SearchDepartments(string searchTerm);
    }
}