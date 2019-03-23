using Microsoft.EntityFrameworkCore;
using MyEstate.Domain.Entities;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
