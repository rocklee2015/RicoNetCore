using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace S01.EFCoreDbFirstMySql.Models
{
    public partial class RicoTestDbContext : DbContext
    {
        public RicoTestDbContext()
        {
        }

        public RicoTestDbContext(DbContextOptions<RicoTestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Menu> Menu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;User Id=root;Password=1qaz~xsw2;Database=ricotest;TreatTinyAsBoolean=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasColumnType("int(11)");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.Icon).HasColumnType("varchar(255)");

                entity.Property(e => e.IsDeleted).HasColumnType("bit(1)");

                entity.Property(e => e.ModifyBy).HasColumnType("int(11)");

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Parent).HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("varchar(500)");
            });
        }
    }
}
