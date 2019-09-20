

nuget

Microsoft.Extensions.Configuration.Json


```cs
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.Run(async (context) =>
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true);
        //.AddJsonFile("appsettings.{env.EnvironmentName}.json", true, true);
        Configuration = builder.Build();

        var connectionString = Configuration["ConnectionStrings:RicoDbContext"];

        await context.Response.WriteAsync(connectionString);
    });
}
```

```
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

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
    Configuration = builder.Build();

    app.Run(async (context) =>
    {

        var connectionString = Configuration["ConnectionStrings:RicoDbContext"];

        await context.Response.WriteAsync(connectionString);
    });
}
```

## 参考

- [10分钟就能学会的.NET Core配置](https://www.cnblogs.com/nianming/p/7083964.html)