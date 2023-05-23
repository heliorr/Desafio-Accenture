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
        private static List<Company> Companys = new List<Company> {
            new Company(),
            new Company { name = "empresa nova" }
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Company>> Get()
        {
            return Ok(Companys);
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetSingle(int id)
        {
            return Ok(Companys.FirstOrDefault(c => c.Id == id));
        }
    }
}