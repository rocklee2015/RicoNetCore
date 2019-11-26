using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace S03.UserSecrets.ApiV2_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            SqlConfiguration = configuration;
        }
        public static IConfigurationRoot Configuration { get; set; }

        public static IConfiguration SqlConfiguration { get; set; }
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

            var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();

            string _connection = string.Empty;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment == "Development")
            {
                builder.AddUserSecrets<Program>();

                var sqlBuilder = new SqlConnectionStringBuilder(SqlConfiguration.GetConnectionString("Movies"));
                sqlBuilder.Password = SqlConfiguration["DbPassword"];
                _connection = sqlBuilder.ConnectionString;
            }
            Configuration = builder.Build();

            app.Run(async (context) =>
            {
                var appKey = Configuration["AppKey"];
                await context.Response.WriteAsync($"{appKey ?? "null"}\n");

                var connectionString = Configuration["ConnectionStrings:DbContext"];
                await context.Response.WriteAsync($"{connectionString}\n");

                await context.Response.WriteAsync($"{_connection}\n");
            });
        }
    }
}
