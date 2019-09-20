using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace S02_MultiEnviromentConsole
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.{env.EnvironmentName}.json");
            //.AddJsonFile("appsettings.{env.EnvironmentName}.json");
            Configuration = builder.Build();

            var appid = Configuration["ConnectionStrings:RicoDbContext"];

            Console.WriteLine(appid);

            Console.ReadKey();
        }
    }
}
