using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using Store.Domain.Exceptions;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.Domain.Services.AuthenticationServices;

namespace Store.Domain.Tests.Service.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IAccountService> _mockAccountService;
        private AuthenticationService _authenticationService;
        [SetUp]
        public void SetUp()
        {
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockAccountService = new Mock<IAccountService>();
            _authenticationService = new AuthenticationService( _mockAccountService.Object, _mockPasswordHasher.Object);
        }
        [Test]
        public void Login_WithCorrectPasswordForExistUserUsername_ReturnsAccountForCorrectUsername()
        {
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).Returns(new Account()
                {User = new User() {UserName = expectedUsername}});
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);
           
            Account account= _authenticationService.Login(expectedUsername, password);
            string actualUsername = account.User.UserName;
          
            Assert.AreEqual( expectedUsername, actualUsername);
        }

        [Test]
        public void Login_WithInCorrectPasswordForExistUserUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).Returns(new Account()
                { User = new User() { UserName = expectedUsername } });
           _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            InvalidPasswordException exception = Assert.Throws<InvalidPasswordException>(() => _authenticationService.Login(expectedUsername, password));

            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void Login_WithNotExistUserUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            UserNotFoundException exception = Assert.Throws<UserNotFoundException>(() => _authenticationService.Login(expectedUsername, password));

            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }
    }
}
