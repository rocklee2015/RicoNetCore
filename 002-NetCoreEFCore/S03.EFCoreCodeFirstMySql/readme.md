

=
```
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql
```
### 1 创建模型

### 2 创建数据库上下文

### 3 执行迁移命令

#### 1、Enable-Migrations 

#### 2、Add-Migration Initial

#### 3、Update-DataBase

###

EF Core 2.0 NuGet命令

Get-Help about_EntityFrameworkCore 获取EF Core命令帮助

添加一个迁移数据库 迁移的名称 目录（及其子命名空间）路径是相对于项目目录。 默认值为"Migrations"。
Add-Migration -Name <String> -OutputDir <String>	
Add-Migration InitialCreate 第一次执行初始化用这个

删除上次的迁移数据库 不检查以查看迁移是否已应用到数据库。
Remove-Migration -Force

目标迁移。 如果为"0"，将恢复所有迁移。 默认到最后一个迁移。
Update-Database 
Update-Database LastGoodMigration 还原迁移

删除数据库 显示的数据库会被丢弃，但没有删除它
Drop-Database -WhatIf

Get-DbContext 获取有关 DbContext 类型的信息

从数据库更新DbContext和实体的类型
Scaffold-DbContext 
-Connection <String>	数据库的连接字符串。
-Provider <String>	要使用的提供程序。 （例如 Microsoft.EntityFrameworkCore.SqlServer)
-OutputDir <String >	要将文件放入的目录。 路径是相对于项目目录。
--Context <String >	若要生成的 dbcontext 名称。
-Schemas <String[]>	要生成实体类型的表架构。
-Tables <String[]>	要生成实体类型的表。
-DataAnnotations	使用属性来配置该模型 （如果可能）。 如果省略，则使用仅 fluent API。
-UseDatabaseNames	使用直接从数据库表和列名称。
-Force 覆盖现有文件。

从迁移中生成的 SQL 脚本
Script-Migration
-From <String>	开始迁移。 默认值为 0 （初始数据库）
-To <String>	结束的迁移。 默认到最后一个迁移
-Idempotent	生成可以在任何迁移的数据库使用的脚本
-Output <String>	要将结果写入的文件


## 参考

- [EF Core 2.0使用MsSql/MySql实现DB First和Code First](https://www.cnblogs.com/lwc1st/p/8966347.html)
- [EFCore CodeFirst 连接MySql](https://www.cnblogs.com/chenzhaoyu/p/7831980.html)