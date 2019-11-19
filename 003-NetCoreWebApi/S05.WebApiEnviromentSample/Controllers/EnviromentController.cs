using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace S05.WebApiEnviromentSample.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnviromentController : ControllerBase
    {
        public static IConfigurationRoot Configuration { get; set; }

        private IHostingEnvironment _hostingEnvironment { get; set; }

        public EnviromentController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName}.json");

            Configuration = builder.Build();

            var env = Configuration["Env"];


            return new string[] { $"当前环境：{env}", $"IHostingEnvironment:{_hostingEnvironment.EnvironmentName}" };
        }


    }
}
