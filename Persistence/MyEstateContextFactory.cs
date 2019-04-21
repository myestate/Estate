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
            optionsBuilder.UseSqlServer("Server=tcp:da-sql-07.database.windows.net,1433;Initial Catalog=MyEstateDb;Persist Security Info=False;User ID=zubrytskyiv;Password=moor549&miciCodding9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new MyEstateContext(optionsBuilder.Options);
        }
    } 
}
