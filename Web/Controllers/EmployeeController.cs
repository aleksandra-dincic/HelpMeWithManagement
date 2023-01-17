using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var employeeModel = new EmployeePageModel();

            employeeModel.Employees = _employeeService.GetAllEmployees().Result;
            employeeModel.Departments = _departmentService.GetAllDepartments().Result;

            return View(employeeModel);
        }

        public void AddEmployee(EmployeeModel employee)
        {
            _employeeService.CreateEmployee(employee);
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            _employeeService.UpdateEmployee(employee);
        }

        public void DeleteEmployee(string id)
        {
            _employeeService.DeleteEmployee(id);
        }

        public async Task<EmployeeModel> GetEmployee(string employeeId)
        {
            return await _employeeService.GetEmployee(employeeId);
        }

        public async Task<List<EmployeeModel>> GetEmployees()
        {
            return await _employeeService.GetAllEmployees();
        }

        public async Task<List<EmployeeModel>> SearchEmployees(string searchTerm)
        {
            return await _employeeService.SearchEmployees(searchTerm);
        }

        public async Task AssignToDepartment(DepartmentAssignment departmentAssignment)
        {
            await _employeeService.AssignToDepartment(departmentAssignment);
        }
    }
}