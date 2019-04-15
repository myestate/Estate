using System.Collections.Generic;
using Moq;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
using Persistence;

namespace MyEstate.Application.Tests
{
    class PhotosControllerTests
    {
        private IDatingRepository _datingRepository;
        private Domain.Entities.User _user;
        private Domain.Entities.Photo _photo;
        [SetUp]
        public void Setup()
        {
            var mockDbContext = new Mock<MyEstateContextFactory>().Object;
            _datingRepository = new DatingRepository(mockDbContext.CreateDbContext(new[] { "myDB" }));
            _user = GetTestUsers()[0];
            _photo = GetTestPhotos()[0];
        }

        [Test]
        public void GetPhoto_CheckAreIdsEquals()
        {
            // Arrange

            // Act
            var test = _datingRepository.GetPhoto(_user.Id);

            // Assert
            Assert.AreEqual(_user.Id, test.Result.User.Id);
        }

        private List<Domain.Entities.User> GetTestUsers()
        {
            var users = new List<Domain.Entities.User>
            {
                new Domain.Entities.User { Id=1, Username = "Test1" },
                new Domain.Entities.User { Username = "Test2" },
                new Domain.Entities.User { Username = "Test3" },
                new Domain.Entities.User { Username = "Test4" },
                new Domain.Entities.User { Username = "Test5" }
            };

            return users;
        }

        private List<Domain.Entities.Photo> GetTestPhotos()
        {
            var photos = new List<Domain.Entities.Photo>
            {
                new Domain.Entities.Photo { User=GetTestUsers()[0], UserId = 1, Url = "TestUrl1" },
                new Domain.Entities.Photo { UserId = 2, Url = "TestUrl2" },
                new Domain.Entities.Photo { UserId = 3, Url = "TestUrl3" },
                new Domain.Entities.Photo { UserId = 4, Url = "TestUrl4" },
                new Domain.Entities.Photo { UserId = 5, Url = "TestUrl5" }
            };

            return photos;
        }
    }
}
