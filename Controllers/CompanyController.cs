using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskcomapny.models;

namespace Taskcomapny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDbContext _companyDbContext;

        public CompanyController(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }
        [HttpGet]
        [Route("GetCompany")]
        public async Task<IEnumerable<Company>> GetComapnies()
        {
            var x =  await _companyDbContext.Companies.ToListAsync();
            return x;
        }
        [HttpPost]
        [Route("AddCompany")]
        public async Task<Company> AddCompany(Company objCompany)
        {
            _companyDbContext.Companies.Add(objCompany);
            await _companyDbContext.SaveChangesAsync();
            return objCompany;
        }
        [HttpPatch]
        [Route("UpdateCompany/{id}")]
        public async Task<Company> UpdateCompany(Company objCompany)
        {
            _companyDbContext.Entry(objCompany).State = EntityState.Modified;
            await _companyDbContext.SaveChangesAsync();
            return objCompany;
        }
        [HttpDelete]
        [Route("DeleteCompany/{id}")]
        public bool DeleteCompany(int id)
        {
            bool a = false;
            var company = _companyDbContext.Companies.Find(id);
            if (company != null)
            {
                a = true;
                _companyDbContext.Entry(company).State = EntityState.Deleted;
                _companyDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;

        }
    }
}
