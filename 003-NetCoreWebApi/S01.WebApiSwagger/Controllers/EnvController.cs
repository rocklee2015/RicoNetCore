using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace S01.WebApiSwagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnvController : ControllerBase
    {
        public static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("show")]
        public ActionResult<string> Get()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var env = Configuration["Env"];
            return env;
        }
    }
}