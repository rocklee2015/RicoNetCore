

=
```
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql
```
### 1 ����ģ��

### 2 �������ݿ�������

### 3 ִ��Ǩ������

#### 1��Enable-Migrations 

#### 2��Add-Migration Initial

#### 3��Update-DataBase

###

EF Core 2.0 NuGet����

Get-Help about_EntityFrameworkCore ��ȡEF Core�������

���һ��Ǩ�����ݿ� Ǩ�Ƶ����� Ŀ¼�������������ռ䣩·�����������ĿĿ¼�� Ĭ��ֵΪ"Migrations"��
Add-Migration -Name <String> -OutputDir <String>	
Add-Migration InitialCreate ��һ��ִ�г�ʼ�������

ɾ���ϴε�Ǩ�����ݿ� ������Բ鿴Ǩ���Ƿ���Ӧ�õ����ݿ⡣
Remove-Migration -Force

Ŀ��Ǩ�ơ� ���Ϊ"0"�����ָ�����Ǩ�ơ� Ĭ�ϵ����һ��Ǩ�ơ�
Update-Database 
Update-Database LastGoodMigration ��ԭǨ��

ɾ�����ݿ� ��ʾ�����ݿ�ᱻ��������û��ɾ����
Drop-Database -WhatIf

Get-DbContext ��ȡ�й� DbContext ���͵���Ϣ

�����ݿ����DbContext��ʵ�������
Scaffold-DbContext 
-Connection <String>	���ݿ�������ַ�����
-Provider <String>	Ҫʹ�õ��ṩ���� ������ Microsoft.EntityFrameworkCore.SqlServer)
-OutputDir <String >	Ҫ���ļ������Ŀ¼�� ·�����������ĿĿ¼��
--Context <String >	��Ҫ���ɵ� dbcontext ���ơ�
-Schemas <String[]>	Ҫ����ʵ�����͵ı�ܹ���
-Tables <String[]>	Ҫ����ʵ�����͵ı�
-DataAnnotations	ʹ�����������ø�ģ�� ��������ܣ��� ���ʡ�ԣ���ʹ�ý� fluent API��
-UseDatabaseNames	ʹ��ֱ�Ӵ����ݿ��������ơ�
-Force ���������ļ���

��Ǩ�������ɵ� SQL �ű�
Script-Migration
-From <String>	��ʼǨ�ơ� Ĭ��ֵΪ 0 ����ʼ���ݿ⣩
-To <String>	������Ǩ�ơ� Ĭ�ϵ����һ��Ǩ��
-Idempotent	���ɿ������κ�Ǩ�Ƶ����ݿ�ʹ�õĽű�
-Output <String>	Ҫ�����д����ļ�


## �ο�

- [EF Core 2.0ʹ��MsSql/MySqlʵ��DB First��Code First](https://www.cnblogs.com/lwc1st/p/8966347.html)
- [EFCore CodeFirst ����MySql](https://www.cnblogs.com/chenzhaoyu/p/7831980.html)