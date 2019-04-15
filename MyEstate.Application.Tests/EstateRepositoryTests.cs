using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
using Persistence;

namespace MyEstate.Application.Tests
{
    public class EstateRepositoryTests
    {
        private IEstatesRepository _estateRepository;
        private Domain.Entities.Estate _estate;

        [SetUp]
        public void Setup()
        {
            _estate = GetTestEstates()[0];
        }

        [Test]
        public void Register_HappyPath()
        {
            // Arrange

            // Act
            var result = _estateRepository.AddEstate(_estate);

            // Assert
            Assert.AreEqual(_estate.Title, result.Result.Title);
        }

        private List<Domain.Entities.Estate> GetTestEstates()
        {
            var users = new List<Domain.Entities.Estate>
            {
                new Domain.Entities.Estate{
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
