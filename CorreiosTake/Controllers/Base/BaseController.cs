using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorreiosTake.Controllers.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IServiceWrapper ServiceWrapper;

        public BaseController(IServiceWrapper serviceWrapper)
        {
            this.ServiceWrapper = serviceWrapper;
        }
    }
}
