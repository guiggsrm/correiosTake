using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entidades.Context;
using Entidades.Models;
using CorreiosTake.Controllers.Base;
using Contracts.Services;
using EntidadesDTO.Extensions;

namespace CorreiosTake.Controllers
{
    [Route("api/estados/{siglaEstado}/[controller]")]
    [ApiController]
    public class CidadesController : BaseController
    {
        public CidadesController(IServiceWrapper serviceWrapper) : base(serviceWrapper) { }

        [HttpGet(Name = "GetCidades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cidades = await ServiceWrapper.CidadeService.ObterTodosAsync();
                return Ok(cidades.ParseToCidadesDTO());
            }catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{idCidadeCidade}", Name = "GetCidade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int idCidade)
        {
            try
            {
                var cidade = await ServiceWrapper.CidadeService.ObterPorIdAsync(idCidade);

                if (cidade == null)
                {
                    return NotFound();
                }

                return Ok(cidade);
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{siglaCidade}", Name = "GetCidadesPorSigla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(string siglaEstado, string siglaCidade)
        {
            try
            {
                var cidade = await ServiceWrapper.CidadeService.ObterPorSiglaAsync(siglaEstado, siglaCidade);

                if (cidade == null)
                {
                    return NotFound();
                }

                return Ok(cidade.ParseToCidadeDTO());
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{idCidade}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int idCidade, Cidade cidade)
        {
            if (idCidade != cidade.Id)
            {
                return BadRequest();
            }

            ServiceWrapper.CidadeService.Atualizar(cidade);

            try
            {
                await ServiceWrapper.CidadeService.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(idCidade))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(Cidade cidade)
        {
            try
            {
                await ServiceWrapper.CidadeService.IncluirAsync(cidade);

                return CreatedAtAction("GetCidade", new { idCidade = cidade.Id }, cidade.ParseToCidadeDTO());
            } catch(Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cidade = await ServiceWrapper.CidadeService.ObterPorIdAsync(id);
                if (cidade == null)
                {
                    return NotFound();
                }

                ServiceWrapper.CidadeService.Deletar(cidade);
                await ServiceWrapper.CidadeService.SaveAsync();

                return Ok(cidade.ParseToCidadeDTO());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private bool CidadeExists(int id)
        {
            return ServiceWrapper.CidadeService.ObterPorId(id) != null;
        }
    }
}
