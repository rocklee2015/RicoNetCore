
#### 

packages:
```
> Microsoft.EntityFrameworkCore.Tools
> MySql.Data.EntityFrameworkCore
> MySql.Data.EntityFrameworkCore.Design

```

Migration Command:
```
>  Scaffold-DbContext "Server=127.0.0.1;User Id=root;Password=1qaz~xsw2;Database=ricotest;TreatTinyAsBoolean=true" Pomelo.EntityFrameworkCore.MySql -OutputDir Models -Force -Context RicoDbFirstMysqlDb
```

> **错误**  
> 提示要安装这个包 Pomelo.EntityFrameworkCore.MySql，看来还是不支持