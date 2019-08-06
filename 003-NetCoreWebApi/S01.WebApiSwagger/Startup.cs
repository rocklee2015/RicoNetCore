using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using S01.WebApiSwagger.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace S01.WebApiSwagger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                //c.OrderActionsBy(apiDesc => apiDesc.GetAreaName());
                c.SwaggerDoc("v1.0", new Info { Title = "Ricolee Demo API", Version = "1.0" });
                c.IncludeXmlComments(System.IO.Path.Combine(System.AppContext.BaseDirectory, "AppData", "S01.WebApiSwagger.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                //routes.MapAreaRoute(
                //    name: "MyAreaProducts",
                //    areaName: "Product",
                //    template: "Product/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("areaRoute", "{area:exists}/{controller}/{action=Get}/{id?}");
                routes.MapRoute(
                   name: "default",
                   template: "{controller=values}/{action=get}/{id?}"
                   );
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Ricolee Demo API (V 1.0)");
            });
        }
    }
}
