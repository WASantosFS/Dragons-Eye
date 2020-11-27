using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

namespace m4dragon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        private readonly IActionContextAccessor _accessor;

        public CoreController(IActionContextAccessor accessor)
        {
            _accessor = accessor;
        }
        
        [HttpGet]
        public string GetIP()
        {
            var ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress;
            return ip.MapToIPv4().ToString();
        }
    }
}
