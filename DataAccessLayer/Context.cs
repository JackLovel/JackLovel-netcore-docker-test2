using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseMySql();   
        }
    }
}


//public class MyDbContext
//{
//    private readonly IConfiguration _configuration;
//    private readonly string _connectionString;
//    public MyDbContext(IConfiguration configuration)
//    {
//        _configuration = configuration;
//        _connectionString = _configuration.GetConnectionString("Default");
//    }
//    public IDbConnection CreateConnection()
//        => new MySqlConnection(_connectionString);
//}

//public class Employee
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public int Age { get; set; }
//    public string? Position { get; set; }
//    public int CompanyId { get; set; }
//}
//public class Company
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public string? Address { get; set; }
//    public string? Country { get; set; }
//    public List<Employee> Employees { get; set; } = new List<Employee>();
//}
