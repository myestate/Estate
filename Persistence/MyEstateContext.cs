using Microsoft.EntityFrameworkCore;
using MyEstate.Domain.Entities;

namespace Persistence
{
    public class MyEstateContext : DbContext
    {
        public MyEstateContext()
        {
        }

        public MyEstateContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Estate> Estates { get; set; }

         public DbSet<EstateAgent> EstateAgents { get; set; }
    }
}
