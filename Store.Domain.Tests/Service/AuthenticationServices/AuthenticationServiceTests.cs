using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        [Test]
        public void Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            string password = "testpassword";
            string confirmPassword = "confirmPassword";
            RegistrationResult expected = RegistrationResult.PasswordsDoNotMatch;

            RegistrationResult actual = _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            Assert.AreEqual(expected,actual);
        }


        [Test]
        public void Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            string email = "test@gmail.com";
            _mockAccountService.Setup(s => s.GetByEmail(email)).Returns(new Account());
            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            RegistrationResult actual = _authenticationService.Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            string username = "tests";
            _mockAccountService.Setup(s => s.GetByUserName(username)).Returns(new Account());
            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            RegistrationResult actual = _authenticationService.Register( It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Register_WithNonExistingUserAndMatchingPasswords_ReturnsSuccess()
        {

            RegistrationResult expected = RegistrationResult.Success;

            RegistrationResult actual = _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }
    }
}
