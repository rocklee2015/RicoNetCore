using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomersAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return $"API_Customer:{DateTime.Now.ToString()}  { Environment.MachineName + " OS:" + Environment.OSVersion.VersionString}";
        }

        [HttpGet("health")]
        public IActionResult Heathle()
        {
            return Ok();
        }

    }
}
