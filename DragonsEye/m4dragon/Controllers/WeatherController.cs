using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using m4dragon.Models_Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Net.Http;

namespace m4dragon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private string connectionString;
        private readonly IActionContextAccessor accessor;

        public WeatherController(string connection)
        {
            this.connectionString = connection;
        }

        [HttpGet]
        public ActionResult<List<Weather>> GetWeatherFromIP()
        {
            //var ip = accessor.ActionContext.HttpContext.Connection.RemoteIpAddress;
                         
            //ip.MapToIPv4().ToString();

            List<Weather> weather = new List<Weather>();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(connectionString);
                
                client.

                responseTask.Wait();

                var result = responseTask.Result;

                
            }
            
        }
    }
}
