using MySqlConnector;
using System.Data;

namespace demoDocker4.Db
{
    public class MyDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public MyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        public int CompanyId { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

}
