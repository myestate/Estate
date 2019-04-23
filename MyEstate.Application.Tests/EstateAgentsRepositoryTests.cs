using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
using Persistence.Helpers;

namespace MyEstate.Application.Tests
{
    public class EstateAgentsRepositoryTests : MyEstateTestBase
    {
        [Test]
        public void AddEstateAgent_HappyPath()
        {
            // Arrange
            var estateRepo = new EstateAgentsRepository(_context);
            var estateAgent = new Domain.Entities.EstateAgent()
            {
                Name= "Vova",
                Age = 54,
                Gender = "Male",
                City = "Lviv"
            };

            // Act
            var result = estateRepo.AddEstateAgent(estateAgent);

            // Assert
            Assert.AreEqual(estateAgent, result.Result);
        }

        [Test]
        public void GetEstateAgent_ById()
        {
            // Arrange
            var estateRepo = new EstateAgentsRepository(_context);
            var resultExpected = estateRepo.GetEstateAgents();
            

            // Act
            var result = estateRepo.GetEstateAgent(resultExpected.Result.First().Id);
            // Assert
            Assert.AreEqual(resultExpected.Result.First().Id, result.Result.Id);
        }

        [Test]
        public void GetEstateAgents()
        {
            // Arrange
            var estateRepo = new EstateAgentsRepository(_context);
            var resultExpected = estateRepo.GetEstateAgents();


            // Act
            var result = estateRepo.GetEstateAgent(resultExpected.Result.First().Id);
            // Assert
            Assert.IsTrue(resultExpected.Result.ToList().Count > 0);
        }

    }
}
