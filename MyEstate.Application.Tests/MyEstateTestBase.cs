using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace MyEstate.Application.Tests
{
    public class MyEstateTestBase : IDisposable
    {
        protected readonly MyEstateContext _context;

        public MyEstateTestBase()
        {
            var options = new DbContextOptionsBuilder<MyEstateContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new MyEstateContext(options);

            _context.Database.EnsureCreated();

            MyEstateInitializer.Initialize(_context);
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();
             
            _context.Dispose();
        }

        private static class MyEstateInitializer
        {
            internal static void Initialize(MyEstateContext context)
            {
                var users = new[]
                {
                    new Domain.Entities.User { Username =  "test1"},
                    new Domain.Entities.User { Username =  "test2"},
                    new Domain.Entities.User { Username =  "test3"},
                    new Domain.Entities.User { Username =  "test4"}
                };

                context.Users.AddRange(users);

                context.SaveChanges();
            }
        }
    }
}
