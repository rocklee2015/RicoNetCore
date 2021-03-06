﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using S03.EFCoreCodeFirstMySql.Loggers;
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

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<User>().ToTable("User");
            //base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //配置连接字符串 必须TreatTinyAsBoolean=true  如果不加 bool类型会自动转化成bit类型 疯狂报错
            optionsBuilder.UseMySql("Server=127.0.0.1;User Id=root;Password=1qaz~xsw2;Database=RicoCodeFistDb;TreatTinyAsBoolean=true");

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);


            base.OnConfiguring(optionsBuilder);
        }
    }
}
