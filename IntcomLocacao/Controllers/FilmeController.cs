using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace IntcomLocacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _serv;
        public FilmeController(IFilmeService serv)
        {
            _serv = serv;
        }

        // GET: api/Filme
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _serv.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
