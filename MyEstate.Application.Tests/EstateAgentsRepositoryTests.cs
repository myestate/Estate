using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
using Persistence;
using System;

namespace MyEstate.Application.Tests
{
    public class EstateAgentsRepositoryTests : MyEstateTestBase
    {
        [Test]
        public void Should_AddAndReturnAgent_When_AddAgent()
        {
            // Arrange
            var agentsRepo = new EstateAgentsRepository(_context);
            var agent = new Domain.Entities.EstateAgent {Id = 5, Name = "test" };

            // Act
            var result = agentsRepo.AddEstateAgent(agent);

            // Assert
            Assert.AreEqual(agent.Name, result.Result.Name);
        }

        [Test]
        public void Should_ReturnNull_When_AddAgentEqualNull()
        {
            // Arrange
            var agentsRepo = new EstateAgentsRepository(_context);
            var agent = new Domain.Entities.EstateAgent {Id=6 };

            // Act
            var result = agentsRepo.AddEstateAgent(agent);

            // Assert
            Assert.AreEqual(agent.Name, result.Result.Name);
        }

        [Test]
        public void Should_ReturnAgentById_When_GetEstateAgent()
        {
            // Arrange
            var agentsRepo = new EstateAgentsRepository(_context);
            var agent = new Domain.Entities.EstateAgent { Id = 1, Name = "test" };

            // Act
            var result = agentsRepo.GetEstateAgent(1);

            // Assert
            Assert.AreEqual(agent.Id, result.Result.Id);
        }   
    }
}