using System.Collections.Generic;
using Moq;
using MyEstate.Application.Interfaces;
using NUnit.Framework;
using Persistence;

namespace MyEstate.Application.Tests
{
    public class AuthRepositoryTests
    {
        private IAuthRepository _authRepository;
        private Domain.Entities.User _user;
        private string _password;
        [SetUp]
        public void Setup()
        {
            var mockDbContext = new Mock<MyEstateContextFactory>().Object;
             _authRepository = new AuthRepository(mockDbContext.CreateDbContext(new[] { "myDb" }));
             _user = GetTestUsers()[0];
             _password = GetTestPasswords()[0];
        }

        [Test]
        public void Register_HappyPath()
        {
            // Arrange

            // Act
            var register = _authRepository.Register(_user, _password);

            // Assert
            Assert.AreEqual(_user.Username, register.Result.Username);
        }

        [Test]
        public void Register_UsernameAndPassword_CheckIsPasswordsNotEmpty()
        {
            // Arrange

            // Act
            var register = _authRepository.Register(_user, _password);

            // Assert
            Assert.IsNotEmpty(register.Result.PasswordHash);
            Assert.IsNotEmpty(register.Result.PasswordSalt);
        }

        [Test]
        public void Login_UsernameAndPassword_IsUserExist()
        {
            // Arrange

            // Act
            var login = _authRepository.Login(_user.Username, _password);

            // Assert
            Assert.IsNotNull(login);
        }

        private List<Domain.Entities.User> GetTestUsers()
        {
            var users = new List<Domain.Entities.User>
            {
                new Domain.Entities.User { Username = "Test1" },
                new Domain.Entities.User { Username = "Test2" },
                new Domain.Entities.User { Username = "Test3" },
                new Domain.Entities.User { Username = "Test4" },
                new Domain.Entities.User { Username = "Test5" }
            };

            return users;
        }

        private List<string> GetTestPasswords()
        {
            var passwords = new List<string>
            {
             "password1",
             "password2",
             "password3",
             "password4",
             "password5",
            };

            return passwords;
        }
    }
}