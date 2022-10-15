using System.Data;
using Dapper;
using demoDocker4.Db;
using demoDocker4.Models;

namespace demoDocker4.Repo
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly MyDbContext _context;
        public CompanyRepo(MyDbContext context)
            => _context = context;

        public  Company CreateCompany(CompanyForCreationDto company)
        {
            // var query =  "insert into company (company_name, address, country) values(@Name, @Address, @Country)";
            var query = @"insert into company (company_name, address, country) values(@Name, @Address, @Country);"
            + "SELECT last_insert_id()"; // mysql version 

            var parameters = new DynamicParameters();
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                // int i = await connection.ExecuteAsync(query, parameters);

                var id = connection.QuerySingle<int>(query, parameters);
                var createCompany = new Company
                {
                    Id = id,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country
                };

                return createCompany;
            }
        }

        public void  CreateMultipleCompanies(List<CompanyForCreationDto> companies)
        {
            var query = "insert into company (company_Name, address, country) values (@Name, @Address, @Country)";
            using (var connection = _context.CreateConnection()) {
                connection.Open();

                using (var transaction = connection.BeginTransaction()) {
                    foreach (var company in companies) {
                        var parameter = new DynamicParameters();
                        parameter.Add("Name", company.Name, DbType.String);
                        parameter.Add("Address", company.Address, DbType.String);
                        parameter.Add("Country", company.Country, DbType.String);
                        connection.Execute(query, parameter, transaction: transaction);
                    }

                    transaction.Commit(); 
                }
            }
        }

        public void DeleteCompany(int id)
        {
            var query = "delete from Company where id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { id });
            }
        }

        public IEnumerable<Company> GetCompanies()
        {
            var query = "select id, company_name as name, address,country from Company";
            using (var connection = _context.CreateConnection())
            {
                var companies = connection.Query<Company>(query);
                return companies.ToList();
            }
        }

        public Company GetCompany(int id)
        {
            var query = "select * from Company where id=@id";
            using (var connection = _context.CreateConnection())
            {
                var company = connection.QuerySingleOrDefault<Company>(query, new { id });
                return company;
            }
        }

        public Company GetCompanyByEmployeeId(int id)
        {
            var procecureName = "show_company_by_employid";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var company = connection.QuerySingleOrDefault<Company>
                (procecureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }

        public Company GetMultipleResults(int id)
        {
            var query = "select * from company where id=@Id;" +
            "select * from employee where Company_Id=@Id";

            using (var connection = _context.CreateConnection())
            using (var multi =  connection.QueryMultiple(query, new { id }))
            {
                var company =  multi.ReadSingleOrDefault<Company>();
                if (company is null)
                {
                    company.Employees = (multi.Read<Employee>()).ToList();
                }

                return company;
            }
        }

        public List<Company> MultipleMapping()
        {
            var query = "select * from company c join employee e on c.id=e.company_id;";
            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, Company>();

                var companies = connection.Query<Company, Employee, Company>(query, (company, employee) =>
                {
                    if (!companyDict.TryGetValue(company.Id, out var currentCompany))
                    {
                        currentCompany = company;
                        companyDict.Add(currentCompany.Id, currentCompany);
                    }

                    currentCompany.Employees.Add(employee);

                    return currentCompany;
                });

                return companies.Distinct().ToList();
            }
        }

        public void UpdateCompany(int id, CompanyForUpdateDto compnay)
        {
            var query = "update company set company_name=@Name, address=@Address, country=@Country where id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", compnay.Name, DbType.String);
            parameters.Add("Address", compnay.Address, DbType.String);
            parameters.Add("Country", compnay.Country, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }


    }
}