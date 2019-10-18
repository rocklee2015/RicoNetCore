

.net framework 把应用程序的配置信息放在了`web.config`中,.net core则把配置信息放在了`appsettings.json`文件中。放在JSON中就是键值对形式存储了。

对于读取文件配置除了支持`json`文件,还支持`xml`和`ini`文件。

.net core 配置参数的数据源除了支持文件，还增加了支持**命令行参数**， **内存配置**。要是以上都不能满足开发需求，还可以自定义。

## nuget 包

微软提供的配置文件读取的包：
```
Microsoft.Extensions.Configuration
```

可以看见相关的包有：
```
Microsoft.Extensions.Configuration.Json
Microsoft.Extensions.Configuration.FileExtensions
Microsoft.Extensions.Configuration.UserSecrets
Microsoft.Extensions.Configuration.CommandLine
Microsoft.Extensions.Configuration.EnvironmentVariables
```
## 使用到的类

读取配置文件涉及到三个类:
- Configuration：
- ConfigurationBuilder：用来构建Configuration对象
- ConfigurationSource：数据来源

![190924-configuration-01.png](https://img2018.cnblogs.com/blog/376223/201909/376223-20190924173538430-1964101661.png)

在包中对应的接口分别是：（IConfiguration、IConfigurationSource和IConfigurationBuilder）

## 控制台程序获取JSON配置

获取JSON配置文件有三种方式：

安装好`Microsoft.Extensions.Configuration.Json`nuget包

在项目下加了`appsetting.json`文件：
```json

```

```cs
public static IConfigurationRoot Configuration { get; set; }
static void ReadWithKey()
{
    var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

    Configuration = builder.Build();
}
```


在.net core 中提供
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

- [.NET Core采用的全新配置系统[1]: 读取配置数据](https://www.cnblogs.com/artech/p/new-config-system-01.html)
- [10分钟就能学会的.NET Core配置](https://www.cnblogs.com/nianming/p/7083964.html)