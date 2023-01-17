using Neo4jClient;
using Neo4jClient.Cypher;

namespace Persistence
{
    public class Database
    {
        public  GraphClient _client;
        public ICypherFluentQuery Query { get; set; }
        public string DatabaseName { get; set; } = "managementapp";

        public Database()
        {
            _client = new GraphClient(new Uri("http://localhost:7474"), "neo4j", "password");
            try
            {
                _client.ConnectAsync();
                Query = _client.Cypher;
            }
            catch (Exception e)
            {
                //Log exception
            }
        }
    }
}