﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S03.EFCoreCodeFirstMySql.Model;

namespace S03.EFCoreCodeFirstMySql.Migrations
{
    [DbContext(typeof(RicoCodeFristDb))]
    partial class RicoCodeFristDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("S03.EFCoreCodeFirstMySql.Model.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateOn");

                    b.Property<string>("Icon");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime>("ModifyOn");

                    b.Property<string>("Name");

                    b.Property<int?>("Parent");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}
