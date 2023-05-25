using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuplierController : ControllerBase
    {
        private readonly ISuplierService _suplierService;

        public SuplierController (ISuplierService suplierService){
            _suplierService = suplierService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<suplier>>>> Get()
        {
            return Ok(await _suplierService.GetAllSupliers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<suplier>>> GetSingle(int id)
        {
            return Ok(await _suplierService.GetSuplierById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<suplier>>>> AddSuplier(suplier newSuplier)
        {
            return Ok(await _suplierService.AddSuplier(newSuplier));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<suplier>>> DeleteSuplier(int id)
        {
            var response = await _suplierService.DeleteSuplier(id);
            if (response.data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}