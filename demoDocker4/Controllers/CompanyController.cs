using demoDocker4.Db;
using demoDocker4.Models;
using demoDocker4.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demoDocker4.Controllers
{

    public class CompanyController : Controller
    {

        private readonly ICompanyRepo _companyRepo;

        public CompanyController(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompanies()
        {
            IEnumerable<Company> companies = _companyRepo.GetCompanies();

            return View(companies);
        }


      //  [HttpGet("{id}", Name = "CompanyById")]
      //  public async Task<IActionResult> GetCompany(int id)
      //  {
      //      var company = await _companyRepo.GetCompany(id);
      //      if (company is null) return NotFound();
      //      return Ok(company);
      //  }

      //  [HttpPost]
      //  public async Task<IActionResult> CreateCompany(
      //      [FromBody] CompanyForCreationDto company)
      //  {
      //      var createCompany = await _companyRepo.CreateCompany(company);
      //      return CreatedAtRoute(
      //"CompanyById",
      //  routeValues: new { id = createCompany.Id },
      //  createCompany);
      //  }

      //  [HttpPut("{id}")]
      //  public async Task<IActionResult> UpdateCompany(
      //   int id,
      //   [FromBody] CompanyForUpdateDto company)
      //  {
      //      var dbCompany = await _companyRepo.GetCompany(id);
      //      if (dbCompany is null)
      //      {
      //          return NotFound();
      //      }

      //      await _companyRepo.UpdateCompany(id, company);

      //      return NoContent();
      //  }

      //  [HttpDelete("{id}")]
      //  public async Task<IActionResult> DeleteCompany(int id)
      //  {
      //      var dbCompany = await _companyRepo.GetCompany(id);
      //      if (dbCompany is null)
      //      {


      //          return NotFound();
      //      }

      //      await _companyRepo.DeleteCompany(id);

      //      return NoContent();
      //  }

      //  [HttpGet("ByEmployeeId/{id}")]
      //  public async Task<IActionResult> GetCompanyForEmployee(int id)
      //  {
      //      var company = await _companyRepo.GetCompanyByEmployeeId(id);
      //      if (company is null)
      //      {
      //          return NotFound();
      //      }

      //      return Ok(company);
      //  }

      //  // 
      //  [HttpGet("{id}/multipleResult")]
      //  public async Task<IActionResult> GetMultipleResults(int id)
      //  {
      //      var company = await _companyRepo.GetMultipleResults(id);
      //      if (company is null)
      //      {
      //          return NotFound();
      //      }

      //      return Ok(company);
      //  }

      //  ///
      //  [HttpGet("MultipleMapping")]
      //  [Authorize]
      //  public async Task<IActionResult> GetMultipleMapping(int id)
      //  {
      //      var companies = await _companyRepo.MultipleMapping();
      //      return Ok(companies);
      //  }
    }
}
