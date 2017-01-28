using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogsoftware.Controllers;
using blogsoftware.Models;
using blogsoftware.Security;
using Moq;
using NUnit.Framework;

namespace blogsoftware.Tests.Controllers
{
    [TestFixture]
    class LoginControllerTests
    {
        [Test]
        public void CreateAccount()
        {
            //Arrange
            var data = new List<User>
            {
                new User {PasswordHash = "1", Username = "1"},
                new User {PasswordHash = "2", Username = "2"},
                new User {PasswordHash = "3", Username = "3"},
                new User {PasswordHash = "4", Username = "4"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();

            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());



            var mockContext = new Mock<Context.AppContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var bcryptMock = new Mock<BCryptWrapper>();
            bcryptMock.Setup(m => m.GetSalt()).Returns("salt");
            bcryptMock.Setup(m => m.GetHash("password", "salt")).Returns("Very Secure Password");
            var userToTest = new User()
            {
                Username = "User",
                PasswordHash = "password"
            };

            //Act
            var ctrl = new LoginController(bcryptMock.Object, mockContext.Object);
            var createdAccount = ctrl.CreateAccount(userToTest);


            Assert.AreEqual(true, createdAccount);
        }

        [Test]
        public void UsernameAlreadyTaken()
        {
            //Arrange
            var data = new List<User>
            {
                new User {PasswordHash = "Very Secure Password", Username = "User"},
                new User {PasswordHash = "2", Username = "2"},
                new User {PasswordHash = "3", Username = "3"},
                new User {PasswordHash = "4", Username = "4"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();

            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Context.AppContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var bcryptMock = new Mock<BCryptWrapper>();
            bcryptMock.Setup(m => m.GetSalt()).Returns("salt");
            bcryptMock.Setup(m => m.GetHash("password", "salt")).Returns("Very Secure Password");
            var userToTest = new User()
            {
                Username = "User",
                PasswordHash = "password"
            };

            //Act
            var ctrl = new LoginController(bcryptMock.Object, mockContext.Object);
            var createdAccount = ctrl.CreateAccount(userToTest);


            Assert.AreEqual(false, createdAccount);
        }
    }
}
