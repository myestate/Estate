using Microsoft.EntityFrameworkCore;
using MyEstate.Domain.Entities;

namespace Persistence
{
    public class MyEstateContext : DbContext
    {
        public MyEstateContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<EstatePhoto> EstatePhotos { get; set; }

        public DbSet<Estate> Estates { get; set; }

         public DbSet<EstateAgent> EstateAgents { get; set; }

         public DbSet<Message> Messages { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
         {
             builder.Entity<Message>()
             .HasOne(u => u.Sender)
             .WithMany(m => m.MessagesSent)
             .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Message>()
             .HasOne(u => u.Recipient)
             .WithMany(m => m.MessagesReceived)
             .OnDelete(DeleteBehavior.Restrict);
         }
    }
}
