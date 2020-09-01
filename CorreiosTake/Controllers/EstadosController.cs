using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Services;
using CorreiosTake.Controllers.Base;
using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Wrapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorreiosTake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : BaseController
    {
        public EstadosController(IServiceWrapper serviceWrapper) : base(serviceWrapper) { }

        // GET: api/<EstadoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ServiceWrapper.EstadoService.ObterTodos());
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<EstadoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = ServiceWrapper.EstadoService.ObterPorId(id);
                if (model == null)
                    return NotFound();
                return Ok(model);
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<EstadoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estado model)
        {
            try
            {
                await ServiceWrapper.EstadoService.IncluirAsync(model);
                return CreatedAtAction("Get", model);
            } catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        // PUT api/<EstadoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estado model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                ServiceWrapper.EstadoService.Atualizar(model);
                ServiceWrapper.EstadoService.Save();
                return Ok(model);
            }
            catch (Exception)
            {
                if (ServiceWrapper.EstadoService.ObterPorId(id) == null)
                    return NotFound();
                else
                    throw;
            }
        }

        // DELETE api/<EstadoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estado = await ServiceWrapper.EstadoService.ObterPorIdAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            ServiceWrapper.EstadoService.Deletar(estado);
            await ServiceWrapper.EstadoService.SaveAsync();

            return Ok(estado);
        }
    }
}
