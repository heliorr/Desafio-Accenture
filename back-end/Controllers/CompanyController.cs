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
    }
}