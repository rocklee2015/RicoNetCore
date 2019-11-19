using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace S01_MultiEnviromentConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //  WebHost.CreateDefaultBuilder(args)
        //  .ConfigureAppConfiguration((webHostBuilderContext, configurationbuilder) =>
        //  {
        //      var env = webHostBuilderContext.HostingEnvironment;//可以通过WebHostBuilderContext类的HostingEnvironment属性得到IHostingEnvironment接口对象

        //        configurationbuilder.SetBasePath(env.ContentRootPath)
        //      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)//这里采用appsettings.{env.EnvironmentName}.json根据当前的运行环境来加载相应的appsettings文件
        //      .AddEnvironmentVariables();
        //  })
        //      .UseStartup<Startup>();
    }
}
