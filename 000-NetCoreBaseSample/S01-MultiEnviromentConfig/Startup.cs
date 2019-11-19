using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace S01_MultiEnviromentConfig
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseExceptionHandler("/Error");
            }

            //var builder = new ConfigurationBuilder()
            // .SetBasePath(Directory.GetCurrentDirectory())
            // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            //Configuration = builder.Build();

            app.Run(async (context) =>
            {

                context.Response.ContentType = "text/plain; charset=utf-8";

                await context.Response.WriteAsync($"进程内环境变量：env.EnvironmentName={env.EnvironmentName}\n");

                var myEnvironmentValue = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Machine);

                await context.Response.WriteAsync($"操作系统环境变量 ASPNETCORE_ENVIRONMENT={myEnvironmentValue ?? "没有找到"}\n");

                var connectionString = Configuration["ConnectionStrings:RicoDbContext"];

                await context.Response.WriteAsync($"数据库库连接字符串：{connectionString}\n");

                var appId = Configuration["AppId"];

                await context.Response.WriteAsync($"appId={appId ?? "没找到"}\n");
            });
        }
    }
}
