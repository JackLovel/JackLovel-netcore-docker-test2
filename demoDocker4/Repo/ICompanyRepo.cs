using demoDocker4.Db;
using demoDocker4.Models;

namespace demoDocker4.Repo
{
    public interface ICompanyRepo
    {
        public IEnumerable<Company> GetCompanies();
        public Company GetCompany(int id);
        public Company CreateCompany(CompanyForCreationDto compnay);
        public void UpdateCompany(int id, CompanyForUpdateDto compnay);
        public void DeleteCompany(int id);
        public Company GetCompanyByEmployeeId(int id);
        public Company GetMultipleResults(int id);
        public List<Company> MultipleMapping();
        public void CreateMultipleCompanies(List<CompanyForCreationDto> companies);
    }
}
