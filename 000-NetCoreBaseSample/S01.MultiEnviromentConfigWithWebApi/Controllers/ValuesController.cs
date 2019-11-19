using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using S01.MutiEnviromentConfigWebApi;

namespace S01.MultiEnviromentConfigWithWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IOptions<AppSettingOption> _options;

        private IHostingEnvironment _hostingEnvironment { get; set; }

        public ValuesController(IHostingEnvironment hostingEnvironment, IOptions<AppSettingOption> options)
        {
            _hostingEnvironment = hostingEnvironment;
            _options = options;
        }


        // GET api/values
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
