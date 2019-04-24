﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEstate.Domain.Entities;

namespace Persistence
{
    public class MyEstateContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MyEstateContext()
        {
        }

        public MyEstateContext(DbContextOptions options) : base(options)
        {
        }

        //public  DbSet<User> Users { get; set; }

        public DbSet<EstatePhoto> EstatePhotos { get; set; }

        public DbSet<Estate> Estates { get; set; }

         public DbSet<EstateAgent> EstateAgents { get; set; }

         public DbSet<Message> Messages { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
         {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

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
