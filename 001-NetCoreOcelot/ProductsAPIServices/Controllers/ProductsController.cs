using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductsAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return $"API_Product:{DateTime.Now.ToString()}  { Environment.MachineName + " OS:" + Environment.OSVersion.VersionString}";
        }

        [HttpGet("health")]
        public IActionResult Heathle()
        {
            return Ok();
        }
    }
}
