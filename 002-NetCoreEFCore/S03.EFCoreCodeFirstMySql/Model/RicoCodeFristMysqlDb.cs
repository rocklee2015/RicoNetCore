using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace S03.EFCoreCodeFirstMySql.Model
{
    public class RicoCodeFristDb : DbContext
    {
        //public RicoCodeFristDb(DbContextOptions<RicoCodeFristDb> options)
        //   : base(options)
        //{
        //}


       
        public DbSet<Menu> Menus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().ToTable("Menu");
            //base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //配置连接字符串 必须TreatTinyAsBoolean=true  如果不加 bool类型会自动转化成bit类型 疯狂报错
            optionsBuilder.UseMySql("Server=127.0.0.1;User Id=root;Password=1qaz~xsw2;Database=RicoCodeFistDb;TreatTinyAsBoolean=true");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
