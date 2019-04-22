using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
using Persistence.Helpers;

namespace MyEstate.Application.Tests
{
    public class EstateRepositoryTests : MyEstateTestBase
    {
        [Test]
        public void AddEstate_HappyPath()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);
            var estate = new Domain.Entities.Estate
            {
                AdType = "Selling",
                Title = "Test1",
                Description = "Test1Description",
                Price = 10,
                Square = 10,
                Rooms = 1,
                Floors = 1,
                Country = "Ukraine",
                City = "Lviv",
                Street = "First"
            };

            // Act
            var result = estateRepo.AddEstate(estate);

            // Assert
            Assert.AreEqual(estate, result.Result);
        }

        [Test]
        public void Filtering_TypeRent()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);
            
            EstateParams estateParams = new EstateParams() { Type="Rent"};
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.AdType == "Rent")
                .ToList();
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            Assert.AreEqual(resultExpected.Count, result.Result.Count);
        }

        [Test]
        public void Filtering_TypeDailyRent()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);
            EstateParams estateParams = new EstateParams() { Type = "Daily rent" };

            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.AdType == "Daily rent")
                .ToList();
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            Assert.AreEqual(resultExpected.Count, result.Result.Count);
        }

        [Test]
        public void Filtering_TypeSelling()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams() { Type = "Selling" };
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.AdType == "Selling")
                .ToList();
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            Assert.AreEqual(resultExpected.Count, result.Result.Count);
        }

        [Test]
        public void GetEstatesById()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            // Act
            var result = estateRepo.GetEstate(1);
            // Assert
            Assert.AreEqual(result.Result.Id, 1);
        }

        private List<Domain.Entities.Estate> GetTestEstates()
        {
            var users = new List<Domain.Entities.Estate>
            {
                new Domain.Entities.Estate{
                    AdType="Selling",
                    Title = "Test1",
                    Description="Test1Description",
                    Price = 10,
                    Square =10,
                    Rooms =1,
                    Floors =1,
                    Country="Ukraine",
                    City="Lviv",
                    Street="First"
                },
                new Domain.Entities.Estate {
                    AdType="Rent",
                    Title = "Test2",
                    Description="Test2Description",
                    Price = 20,
                    Square =20,
                    Rooms =2,
                    Floors =2,
                    Country="Ukraine",
                    City="Lviv",
                    Street="Second"
                },
                new Domain.Entities.Estate {
                    AdType="Rent",
                    Title = "Test3",
                    Description="Test3Description",
                    Price = 30,
                    Square =30,
                    Rooms =3,
                    Floors =3,
                    Country="Ukraine",
                    City="Lviv",
                    Street="Third"
                },
                new Domain.Entities.Estate {
                    AdType="Daily rent",
                    Title = "Test4",
                    Description="Test4Description",
                    Price = 40,
                    Square =40,
                    Rooms =4,
                    Floors =4,
                    Country="Ukraine",
                    City="Lviv",
                    Street="Fourth"
                }
            };

            return users;
        }
    }
}
