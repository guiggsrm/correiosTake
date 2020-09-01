using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Services;
using CorreiosTake.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorreiosTake.Controllers
{
    [Route("api/{siglaEstado}/[controller]/Upload")]
    [ApiController]
    public class TrexosController : BaseController
    {
        public TrexosController(IServiceWrapper serviceWrapper) : base(serviceWrapper) { }

        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            try
            {

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
