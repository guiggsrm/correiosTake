using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Services;
using CorreiosTake.Controllers.Base;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorreiosTake.Controllers
{
    [Route("api/estados/{siglaEstado}/[controller]/Upload")]
    [ApiController]
    public class TrexosController : BaseController
    {
        public TrexosController(IServiceWrapper serviceWrapper) : base(serviceWrapper) { }

        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFileAsync(string siglaEstado, IFormFile file)
        {
            try
            {
                var trexos = await ServiceWrapper.TrexoService.UploadAsync(siglaEstado, file);
                return Ok(trexos);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
