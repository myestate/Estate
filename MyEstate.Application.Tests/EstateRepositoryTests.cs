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
        public void GetEstates_Filtering_TypeRent()
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
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_TypeDailyRent()
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
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_TypeSelling()
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
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_OrderByPriceUp()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams(); 
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .OrderBy(e => e.Price)
                .ToList();
            estateParams.OrderBy = "priceUp";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_OrderByPriceDown()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .OrderByDescending(e => e.Price)
                .ToList();
            estateParams.OrderBy = "priceDown";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_SquareMinMax()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.Square >= 50 && e.Square <= 100)
                .ToList();
            estateParams.MinSquare = 50;
            estateParams.MaxSquare = 100;
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_RoomsMinMax()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.Rooms >= 1 && e.Rooms <= 2)
                .ToList();
            estateParams.MinRooms = 1;
            estateParams.MaxRooms = 2;
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_FloorsMinMax()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.Floors >= 1 && e.Floors <= 2)
                .ToList();
            estateParams.MinFloors = 1;
            estateParams.MaxFloors = 2;
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_OrderByRoomsUp()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .OrderBy(e => e.Rooms)
                .ToList();
            estateParams.OrderBy = "roomsUp";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_OrderByRoomsDown()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .OrderByDescending(e => e.Rooms)
                .ToList();
            estateParams.OrderBy = "roomsDown";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_OrderBySquareUp()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .OrderBy(e => e.Square)
                .ToList();
            estateParams.OrderBy = "squareUp";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_OrderBySquareDown()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .OrderByDescending(e => e.Square)
                .ToList();
            estateParams.OrderBy = "squareDown";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_ByCountry()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e=>e.Country=="Ukraine")
                .ToList();
            estateParams.Country = "Ukraine";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_ByCity()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.City == "Lviv")
                .ToList();
            estateParams.City = "Lviv";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Filtering_ByStreet()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .Where(e => e.Street == "Shevchenka")
                .ToList();
            estateParams.Street = "Shevchenka";
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            CollectionAssert.AreEqual(resultExpected, result.Result);
        }

        [Test]
        public void GetEstates_Pagination_OneAdToPage()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);

            EstateParams estateParams = new EstateParams() { PageSize=1};
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            Assert.IsTrue(result.Result.Count==1);
        }

        [Test]
        public void GetEstates_Pagination_OneAdToPage_SecondPage()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);
            EstateParams estateParams = new EstateParams();
            var resultExpected = estateRepo.GetEstates(estateParams)
                .Result
                .ToList();
            estateParams.PageSize = 1;
            estateParams.PageNumber = 2;
            // Act
            var result = estateRepo.GetEstates(estateParams);
            // Assert
            Assert.AreEqual(resultExpected[1], result.Result[0]);
        }

        [Test]
        public void GetEstate_ById()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);
            var resultExpected = estateRepo.GetAllEstates();
            // Act
            var result = estateRepo.GetEstate(resultExpected.Result.First().Id);
            // Assert
            Assert.AreEqual(resultExpected.Result.First(), result.Result);
        }

        [Test]
        public async System.Threading.Tasks.Task DeleteEstate_SuccessAsync()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);
            var resultBeforeDelete = estateRepo.GetAllEstates();
            // Act
            await estateRepo.DeleteEstate(resultBeforeDelete.Result.First().Id);
            var resultAfterDelete = estateRepo.GetAllEstates();
            // Assert
            CollectionAssert.AreNotEqual(resultBeforeDelete.Result, resultAfterDelete.Result);
        }

        [Test]
        public async System.Threading.Tasks.Task DeleteEstate_NotSuccessAsync()
        {
            // Arrange
            var estateRepo = new EstatesRepository(_context);
            var resultBeforeDelete = estateRepo.GetAllEstates();
            // Act
            await estateRepo.DeleteEstate(-1);
            var resultAfterDelete = estateRepo.GetAllEstates();
            // Assert
            CollectionAssert.AreEqual(resultBeforeDelete.Result, resultAfterDelete.Result);
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
