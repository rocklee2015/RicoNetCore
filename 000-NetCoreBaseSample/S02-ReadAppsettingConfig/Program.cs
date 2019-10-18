using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using S00_Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace S02_ReadAppsettingConfig
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            ReadJsonByKey();

            ReadJsonByGetValueMethod();

            ReadJsonByOption();

            ReadFromMemory();

            ReadFromCommandLine(args);

            Console.ReadKey();
        }

        static void ReadJsonByKey()
        {
            //使用Key读取
            //nuget:Microsoft.Extensions.Configuration.Json
            var appid = Configuration["AppId"];
            var includeScope = Configuration["Logging:IncludeScopes"];
            var logLevel = Configuration["Logging:LogLevel:Default"];
            var roleName = Configuration["RoleNames:0:Name"];
            Console.WriteLine("通过key读取：");
            Console.WriteLine(appid);
            Console.WriteLine(includeScope);
            Console.WriteLine(logLevel);
            Console.WriteLine(roleName);
        }
        static void ReadJsonByGetValueMethod()
        {
            //使用GetValue<T>
            //nuget：Microsoft.Extensions.Configuration.Binder

            var appid = Configuration.GetValue<int>("AppId", 12345);
            var includeScope = Configuration.GetValue<bool>("Logging:IncludeScopes", false);
            var logLevel = Configuration.GetValue<string>("Logging:LogLevel:Default", "Debug");
            var roleName = Configuration.GetValue<string>("RoleNames:0:Name", "adminDefault");
            Console.WriteLine("通过GetValue()读取：");
            Console.WriteLine(appid);
            Console.WriteLine(includeScope);
            Console.WriteLine(logLevel);
            Console.WriteLine(roleName);
        }

        static void ReadJsonByOption()
        {
            /* nuget：
             * Microsoft.Extensions.Options.ConfigurationExtensions，
             * Microsoft.Extensions.DependencyInjection
             * Microsoft.Extensions.Options
             */

            var services = new ServiceCollection();
            services.AddOptions();

            services.Configure<MyOptions>(Configuration);
            services.Configure<LoggingOptions>(Configuration.GetSection("Logging"));
            services.Configure<LogLevelOptions>(Configuration.GetSection("Logging:LogLevel"));
            services.Configure<List<RoleName>>(Configuration.GetSection("RoleNames"));

            var serviceProvider = services.BuildServiceProvider();

            Console.WriteLine("通过Option读取：");

            var myOptions = serviceProvider.GetService<IOptions<MyOptions>>();
            Console.WriteLine(myOptions.Value.AppId);

            var logging = serviceProvider.GetService<IOptions<LoggingOptions>>();
            Console.WriteLine(logging.Value.IncludeScopes);

            var logLevel = serviceProvider.GetService<IOptions<LogLevelOptions>>();
            Console.WriteLine(logLevel.Value.System);

            var roleNames = serviceProvider.GetService<IOptions<List<RoleName>>>();
            Console.WriteLine(roleNames.Value[0].Name);
        }

        static void ReadFromMemory()
        {
            var dict = new Dictionary<string, string>
            {
                {"name","ricolee_read-from-memory"}
            };

            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(dict);

            Configuration = builder.Build();
            Console.WriteLine("从内存中读取：");
            Console.WriteLine(Configuration["name"]);
        }

        static void ReadFromCommandLine(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .AddCommandLine(args);

            Configuration = builder.Build();
            Console.WriteLine("从命令行读取：");
            Console.WriteLine(Configuration["name"]);
        }


    }

}
