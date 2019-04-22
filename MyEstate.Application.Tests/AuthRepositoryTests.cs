// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Moq;
// using MyEstate.Application.Interfaces;
// using NUnit.Framework;
// using Persistence;

// namespace MyEstate.Application.Tests
// {
//     public class AuthRepositoryTests
//     {
//         private IAuthRepository _authRepository;
//         private Domain.Entities.User _user;
//         private string _password;
//         [SetUp]
//         public void Setup()
//         {
//             var data = new[]
//             {
//                 new Domain.Entities.User() { UserName = "George" },
//                 new Domain.Entities.User() { UserName = "Susan" }
//             }.AsQueryable();

//              _user = GetTestUsers()[0];
//              _password = GetTestPasswords()[0];
//              _authRepository = new AuthRepository(GetUsersContext(data).Object);
//         }

//         [Test]
//         public void Register_HappyPath()
//         {
//             // Arrange

//             // Act
//             var result = _authRepository.Register(_user, _password);

//             // Assert
//             Assert.AreEqual(_user.UserName, result.Result.UserName);
//         }

//         [Test]
//         public void Register_UsernameAndPassword_CheckIsPasswordsNotEmpty()
//         {
//             // Arrange

//             // Act
//             var register = _authRepository.Register(_user, _password);

//             // Assert
//             Assert.IsNotEmpty(register.Result.PasswordHash);
//             //Assert.IsNotEmpty(register.Result.PasswordSalt);
//         }

//         private Mock<MyEstateContext> GetUsersContext(IQueryable<Domain.Entities.User> data) 
//         {
//             var mockSet = new Mock<DbSet<Domain.Entities.User>>();
//             var mockContext = new Mock<MyEstateContext>();

//             mockSet.As<IQueryable<Domain.Entities.User>>().Setup(m => m.Provider).Returns(data.Provider);
//             mockSet.As<IQueryable<Domain.Entities.User>>().Setup(m => m.Expression).Returns(data.Expression);
//             mockSet.As<IQueryable<Domain.Entities.User>>().Setup(m => m.ElementType).Returns(data.ElementType);
//             mockSet.As<IQueryable<Domain.Entities.User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

//             mockContext.Setup(c => c.Users).Returns(mockSet.Object);

//             return mockContext;
//         }

//         private List<Domain.Entities.User> GetTestUsers()
//         {
//             var users = new List<Domain.Entities.User>
//             {
//                 new Domain.Entities.User { UserName = "Test12" },
//                 new Domain.Entities.User { UserName = "Test2" },
//                 new Domain.Entities.User { UserName = "Test3" },
//                 new Domain.Entities.User { UserName = "Test4" },
//                 new Domain.Entities.User { UserName = "Test5" }
//             };

//             return users;
//         }

//         private List<string> GetTestPasswords()
//         {
//             var passwords = new List<string>
//             {
//              "password1",
//              "password2",
//              "password3",
//              "password4",
//              "password5",
//             };

//             return passwords;
//         }
//     }
// }