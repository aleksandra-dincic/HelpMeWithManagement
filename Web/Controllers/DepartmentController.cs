using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments.Result);
        }

        public void CreateDepartment(DepartmentModel department)
        {
            _departmentService.CreateDepartment(department);
        }

        public void UpdateDepartment([FromBody] DepartmentModel department)
        {
            _departmentService.UpdateDepartment(department);
        }

        public void DeleteDepartment(string id)
        {
            _departmentService.DeleteDepartment(id);
        }

        public async Task<DepartmentModel> GetDepartment(string departmentId)
        {
            return await _departmentService.GetDepartment(departmentId);
        }

        public async Task<List<DepartmentModel>> GetDepartments()
        {
            return await _departmentService.GetAllDepartments();
        }

        public async Task<List<DepartmentModel>> SearchDepartments(string searchTerm)
        {
            return await _departmentService.SearchDepartments(searchTerm);
        }

        public async Task<List<EmployeeModel>> FindAllEmployeesInDepartment(string id)
        {
            return await _departmentService.FindAllEmployeesInDepartment(id);
        }
    }
}