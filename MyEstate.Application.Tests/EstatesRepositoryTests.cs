using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
using Persistence;

namespace MyEstate.Application.Tests
{
    class EstatesRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            var mockDbContext = new Mock<MyEstateContextFactory>().Object;
            _estatesRepository = new EstatesRepository(mockDbContext.CreateDbContext(new[] { "myDb" }));
            _idAddDeleteEstate = 2;
        }

        [TestCase(1)]
        public void GetEstate_ById_HappyPath(int id)
        {
            // Arrange
            var actualeEstate = EstateDataProvider.EstatesForChechConteinsInDb()
                .ContainsKey(id) ? EstateDataProvider.EstatesForChechConteinsInDb()[id] : null;
            // Act
            var expectedEstate = _estatesRepository.GetEstate(id);

            // Assert
            Assert.AreEqual(actualeEstate.Id, expectedEstate.Result.Id);
            Assert.AreEqual(actualeEstate.City, expectedEstate.Result.City);
            Assert.AreEqual(actualeEstate.Country, expectedEstate.Result.Country);
        }

        [Test]
        public void GetEstates_GetAll_CompareOne_HappyPath()
        {
            // Arrange
            int id = 1;
            var actualeEstate = EstateDataProvider.EstatesForChechConteinsInDb()
                .ContainsKey(id) ? EstateDataProvider.EstatesForChechConteinsInDb()[id] : null;
            // Act
            IEnumerable<Domain.Entities.Estate> expectedEstates = _estatesRepository.GetEstates().Result;

            var expectedOneEstate = expectedEstates.FirstOrDefault(estate => estate.Id == id);
            // Assert
            Assert.IsNotEmpty(expectedEstates);

            Assert.AreEqual(actualeEstate.Title, expectedOneEstate.Title);
            Assert.AreEqual(actualeEstate.City, expectedOneEstate.City);
            Assert.AreEqual(actualeEstate.Country, expectedOneEstate.Country);
            Assert.AreEqual(actualeEstate.Street, expectedOneEstate.Street);
            Assert.AreEqual(actualeEstate.Floors, expectedOneEstate.Floors);
            Assert.AreEqual(actualeEstate.Rooms, expectedOneEstate.Rooms);
            Assert.AreEqual(actualeEstate.Square, expectedOneEstate.Square);
        }

        [Test]
        public void SaveAll_DoNothing_ReturnFalse()
        {
            // arrange
            //Act
            bool saved = _estatesRepository.SaveAll().Result;
            //Assert
            Assert.IsFalse(saved);
        }

        [Test]
        public void AddEstate_HappyPath()
        {
            // arrange
            IEnumerable<Domain.Entities.Estate> start_estates = _estatesRepository.GetEstates().Result;
            //Act

            var estate = _estatesRepository.
                AddEstate(EstateDataProvider.EstateWithoutIDToAdd()[0])
                .Result;
            IEnumerable<Domain.Entities.Estate> finish_estates = _estatesRepository.GetEstates().Result;
            
            bool conditions = (finish_estates.Count() - start_estates.Count()) == 1;
            //Assert
            Assert.IsTrue(conditions);
        }

        [TearDown]
        public void TearDown()
        {
            _estatesRepository = null;
        }

        private IEstatesRepository _estatesRepository;
        private int _idAddDeleteEstate;
    }
}
