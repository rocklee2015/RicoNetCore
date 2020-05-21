using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S05.EF6_X.CodeFirstSqlServer.Models
{
    public class EF6CodeFirstDbContext : DbContext
    {
        public DbSet<Blog> Blog
        {
            get { return Set<Blog>(); }
        }
    }
}
