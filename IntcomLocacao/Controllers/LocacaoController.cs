using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Enums;
using Service.Interfaces;

namespace IntcomLocacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _serv;
        public LocacaoController(ILocacaoService serv)
        {
            _serv = serv;
        }
        // GET: api/Locacao
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

        // GET: api/Locacao/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _serv.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Locacao
        [HttpPost]
        public IActionResult Post(CadastrarLocacaoDto value)
        {
            try
            {
                RetornoCadastroLocacaoDto result = _serv.CadastrarLocacao(value);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Locacao/5
        [HttpPut]
        public IActionResult Put(DevolverLocacaoDto value)
        {
            try
            {
                _serv.DevolverLocacao(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
