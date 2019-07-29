
```
Scaffold-DbContext "Data Source=.;Initial Catalog=ricotest;User ID=sa;Password=1qaz~xsw2;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force -Context RicoDbfirstMsSqlDb
```


确定当前项目时启动项

不然报错：
```
Could not load assembly 'S02.EFCoreDbFirstMsSql'. Ensure it is referenced by the startup project 'S01.EFCoreMySqlDbFirst'.
```

生成实体：
```cs
public partial class Menu
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public bool IsDeleted { get; set; }
}
```


```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ricotest;User ID=sa;Password=1qaz~xsw2;");
    }
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

    modelBuilder.Entity<Menu>(entity =>
    {
        entity.ToTable("menu");

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Icon).HasMaxLength(50);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Url)
            .IsRequired()
            .HasMaxLength(500);
    });
}
```

