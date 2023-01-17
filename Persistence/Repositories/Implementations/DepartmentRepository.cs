using Domain;
using Neo4jClient;
using Persistence.Repositories.Interfaces;

namespace Persistencd.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IGraphClient _client;

        public DepartmentRepository(IGraphClient client)
        {
            _client = client;
        }

        public async Task CreateDepartment(Department department)
        {
            department.Id = Guid.NewGuid().ToString();
            await _client.Cypher.Create("(d:Department $department)")
                                    .WithParam("department", department)
                                    .ExecuteWithoutResultsAsync();
        }

        public async Task DeleteDepartment(string departmentId)
        {
            await _client.Cypher.Match("(d:Department)")
                                 .Where((Department d) => d.Id == departmentId)
                                 .DetachDelete("d")
                                 .ExecuteWithoutResultsAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var departments = await _client.Cypher.Match("(d:Department)")
                                                  .Return(d => d.As<Department>()).ResultsAsync;

            return departments != null ? departments.ToList() : new List<Department>();
        }

        public async Task<Department> GetDepartment(string departmentId)
        {
            var departments = await _client.Cypher.Match("(e:Department)")
                                                   .Where((Department d) => d.Id == departmentId)
                                                   .Return(d => d.As<Department>()).ResultsAsync;

            return departments != null ? departments.FirstOrDefault() : null;
        }

        public async Task<List<Department>> SearchDepartments(string searchTerm)
        {
            var departments = await _client.Cypher.Match("(d:Department)")
                                                   .Where((Department d) => d.Name.Contains(searchTerm) ||
                                                                          d.Description.Contains(searchTerm) || 
                                                                          d.Type.ToString().Contains(searchTerm))
                                                   .Return(d => d.As<Department>()).ResultsAsync;

            return departments != null ? departments.ToList() : new List<Department>();
        }

        public async Task UpdateDepartment(Department department)
        {
            await _client.Cypher.Match("(d:Department)")
                                .Where((Department d) => d.Id == department.Id)
                                .Set("d = $department")
                                .WithParam("department", department)
                                .ExecuteWithoutResultsAsync();
        }
    }
}
