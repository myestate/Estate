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
                    new Domain.Entities.User { UserName =  "test1"},
                    new Domain.Entities.User { UserName =  "test2"},
                    new Domain.Entities.User { UserName =  "test3"},
                    new Domain.Entities.User { UserName =  "test4"}
                };

                var estates = new[]
                {
                    new Domain.Entities.Estate() {
                        AdType="Selling",
                        Title = "TestTitle1",
                        Description = "Description1",
                        Price = 100000,
                        Square=50,
                        Rooms=3,
                        Floors=2,
                        Country="Greece",
                        City="Afina",
                        Street="Firts"
                    },
                    new Domain.Entities.Estate() {
                        AdType="Rent",
                        Title = "TestTitle2",
                        Description = "Description2",
                        Price = 3000,
                        Square=60,
                        Rooms=4,
                        Floors=1,
                        Country="Poland",
                        City="Wroclaw",
                        Street="Second"
                    },
                    new Domain.Entities.Estate() {
                        AdType="Daily rent",
                        Title = "TestTitle3",
                        Description = "Description3",
                        Price = 600,
                        Square=40,
                        Rooms=2,
                        Floors=1,
                        Country="Ukraine",
                        City="Lviv",
                        Street="Shevchenka"
                    }
                };

                var estateAgents = new[]
                {
                    new Domain.Entities.EstateAgent()
                    {
                        Name = "John",
                        Gender = "Male",
                        Age = 25,
                        City = "Lviv"
                    },
                    new Domain.Entities.EstateAgent()
                    {
                        Name = "Julia",
                        Gender = "Female ",
                        Age = 24,
                        City = "Kiev"
                    },
                    new Domain.Entities.EstateAgent()
                    {
                        Name = "Steve",
                        Gender = "Male",
                        Age = 34,
                        City = "Odesa"
                    }
                };

                context.Users.AddRange(users);
                context.Estates.AddRange(estates);
                context.EstateAgents.AddRange(estateAgents);

                context.SaveChanges();
            }
        }
    }
}
