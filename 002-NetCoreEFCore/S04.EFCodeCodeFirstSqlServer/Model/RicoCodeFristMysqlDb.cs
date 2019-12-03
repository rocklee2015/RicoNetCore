using Microsoft.EntityFrameworkCore;

namespace S04.EFCodeCodeFirstSqlServer.Model
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

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=rico_efcore_source;User ID=sa;Password=1qaz~xsw2;");

      
            base.OnConfiguring(optionsBuilder);
        }
    }
}
