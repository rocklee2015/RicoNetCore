using Microsoft.Extensions.Configuration;
using S00_Common;
using System;
using System.IO;

namespace S02_ReadAppsettingConfig
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            ReadWithKey();

            Console.ReadKey();
        }

        static void ReadWithKey()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            //1.使用Key读取
            var appid = Configuration["AppId"]; // 结果 12345
            var includeScope = Configuration["Logging:IncludeScopes"]; // 结果 false
            var logLevel = Configuration["Logging:LogLevel:Default"]; // 结果 Debug
            var GrantType = Configuration["GrantTypes:0:Name"]; // 结果 authorization_code

            appid.ToWriteLine();
            includeScope.ToWriteLine();
            logLevel.ToWriteLine();
            GrantType.ToWriteLine();

        }
    }

}
