using System.Linq;
using NUnit.Framework;


namespace MyEstate.Application.Tests
{
    public class EstateAgentsRepositoryTests : MyEstateTestBase
    {
        [Test]
        public void Should_AddAndReturnAgent_When_AddAgent()
        {
            // Arrange
            var agentsRepo = new EstateAgentsRepository(_context);
            var agent = new Domain.Entities.EstateAgent {Id = 50, Name = "test" };

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
            var agent = new Domain.Entities.EstateAgent {Id=60 };

            // Act
            var result = agentsRepo.AddEstateAgent(agent);

            // Assert
            Assert.AreEqual(agent.Name, result.Result.Name);
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
