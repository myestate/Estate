using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
   public class MyEstateContextFactory : IDesignTimeDbContextFactory<MyEstateContext>
    {
        public MyEstateContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyEstateContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyEstateDB");

            return new MyEstateContext(optionsBuilder.Options);
        }
    }
}
