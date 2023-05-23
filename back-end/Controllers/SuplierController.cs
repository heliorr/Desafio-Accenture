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

        [HttpGet("{cnpjCpf}")]
        public async Task<ActionResult<ServiceResponse<suplier>>> Get(int cnpjCpf)
        {
            return Ok(await _suplierService.GetSuplierByCnpjCpf(cnpjCpf));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ServiceResponse<List<suplier>>>> Get(string name)
        {
            return Ok(await _suplierService.GetSuplierByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<suplier>>>> AddSuplier(suplier newSuplier)
        {
            return Ok(await _suplierService.AddSuplier(newSuplier));
        }
    }
}