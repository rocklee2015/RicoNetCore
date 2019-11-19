using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace S01.MultiEnvNetCore3._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EnvController> _logger;

        public EnvController(ILogger<EnvController> logger, 
            IWebHostEnvironment hostingEnvironment, 
            IOptions<AppSettingOption> options)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _options = options;
        }

        private IOptions<AppSettingOption> _options;

        private IWebHostEnvironment _hostingEnvironment { get; set; }

     

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var myEnvironmentValue = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Machine);

            var results = new List<string>();
            results.Add($"进程内环境变量：IHostingEnvironment.EnvironmentName={_hostingEnvironment.EnvironmentName}");
            results.Add($"操作系统环境变量 ASPNETCORE_ENVIRONMENT={myEnvironmentValue ?? "没有找到"}");
            results.Add($"数据库库连接字符串：{_options.Value.ConnectionStrings.RicoDbContext}\n");
            return results;
        }
    }
}
