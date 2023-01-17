using System.Security.Cryptography;
using Domain;
using Neo4jClient;
using Neo4jClient.Cypher;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IGraphClient _client;

        public EmployeeRepository(IGraphClient client)
        {
            _client = client;
        }

        public async Task AssignToDepartment(string employee, string department)
        {
            await _client.Cypher.Match("(d:Department), (e:Employee)")
            .Where((Department d, Employee e) => d.Id == department && e.Id == employee)
                                   .Create("(d)-[r:hasEmployee]->(e)")
                                   .ExecuteWithoutResultsAsync();
        }

        public async Task CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            await _client.Cypher.Create("(e:Employee $employee)")
                                    .WithParam("employee", employee)
                                    .ExecuteWithoutResultsAsync();
        }

        public async Task DeleteEmployee(string employeeId)
        {
            await _client.Cypher.Match("(e:Employee)")
                                 .Where((Employee e) => e.Id == employeeId)
                                 .DetachDelete("e")
                                 .ExecuteWithoutResultsAsync();
        }

        public async Task<List<Employee>> FindAllEmployeesInDepartment(string id)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("Id", id);

            var query = new CypherQuery($"match (d)-[r:hasEmployee]->(e) where d.Id = '{id}' return e",
                                                            queryDict, CypherResultMode.Set, _client.DefaultDatabase);

            List<Employee> employees = ((IRawGraphClient)_client).ExecuteGetCypherResultsAsync<Employee>(query).Result.ToList();

            return employees;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _client.Cypher.Match("(e:Employee)")
                                                  .Return(e => e.As<Employee>()).ResultsAsync;

            return employees != null ? employees.ToList() : new List<Employee>();
        }

        public async Task<Employee> GetEmployee(string employeeId)
        {
            var employees = await _client.Cypher.Match("(e:Employee)")
                                                   .Where((Employee e) => e.Id == employeeId)
                                                   .Return(e => e.As<Employee>()).ResultsAsync;

            return employees != null ? employees.FirstOrDefault() : null;
        }

        public async Task<List<Employee>> SearchEmployees(string searchTerm)
        {
            var employees = await _client.Cypher.Match("(e:Employee)")
                                                   .Where((Employee e) => e.FirstName.Contains(searchTerm) ||
                                                                          e.LastName.Contains(searchTerm) || 
                                                                          e.RoleName.Contains(searchTerm) ||
                                                                          e.Started.ToString().Contains(searchTerm) ||
                                                                          e.DateOfBirth.ToString().Contains(searchTerm))
                                                   .Return(e => e.As<Employee>()).ResultsAsync;

            return employees != null ? employees.ToList() : new List<Employee>();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _client.Cypher.Match("(e:Employee)")
                                .Where((Employee e) => e.Id == employee.Id)
                                .Set("e = $employee")
                                .WithParam("employee", employee)
                                .ExecuteWithoutResultsAsync();
        }
    }
}
