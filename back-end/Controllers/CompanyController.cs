using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController (ICompanyService companyService){
            _companyService = companyService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Company>>>> Get()
        {
            return Ok(await _companyService.GetAllCompanys());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Company>>> GetSingle(int id)
        {
            return Ok(await _companyService.GetCompanyById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Company>>>> AddCompany(Company newCompany)
        {
            return Ok(await _companyService.AddCompany(newCompany));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Company>>>> UpdateCompany(Company newCompany)
        {
            var response = await _companyService.UpdateCompany(newCompany);
            if (response.data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Company>>> DeleteCompany(int id)
        {
            var response = await _companyService.DeleteCompany(id);
            if (response.data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}