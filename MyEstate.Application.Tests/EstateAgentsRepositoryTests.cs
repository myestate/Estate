<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 589d1eaa2cf9ea9b8b2444116769d51183e31c8e
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
<<<<<<< HEAD
using Persistence;
using System;
=======
using Persistence.Helpers;
>>>>>>> 589d1eaa2cf9ea9b8b2444116769d51183e31c8e

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
