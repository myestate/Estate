using NUnit.Framework;

namespace MyEstate.Application.Tests
{
    public class AuthRepositoryTests : MyEstateTestBase
    {
        [Test]
        public void Register_HappyPath()
        {
            // Arrange
            var authRepo = new AuthRepository(_context);
            var user = new Domain.Entities.User {Username = "test"};
            var password = "password";

            // Act
            var result = authRepo.Register(user, password);

            // Assert
            Assert.AreEqual(user.Username, result.Result.Username);
        }

        [Test]
        public void Login_Null_CheckIsUserNotExist()
        {
            // Arrange
            var authRepo = new AuthRepository(_context);

            // Act
            var result = authRepo.Login(null, null);

            // Assert
            Assert.IsNull(result.Result);
        }


        [Test]
        public void Register_UsernameAndPassword_CheckIsPasswordsNotEmpty()
        {
            // Arrange
            var authRepo = new AuthRepository(_context);
            var user = new Domain.Entities.User { Username = "test" };
            var password = "password";

            // Act
            var register = authRepo.Register(user, password);

            // Assert
            Assert.IsNotEmpty(register.Result.PasswordHash);
            Assert.IsNotEmpty(register.Result.PasswordSalt);
        }

        [Test]
        public void UserExist_UserName_ReturnTrue()
        {
            // Arrange
            var authRepo = new AuthRepository(_context);

            // Act
            var result = authRepo.UserExists("test1");

            // Assert
            Assert.IsTrue(result.Result);
        }
    }
}