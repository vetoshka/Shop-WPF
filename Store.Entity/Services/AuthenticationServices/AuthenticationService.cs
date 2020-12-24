using Microsoft.AspNet.Identity;
using Store.Domain.Exceptions;
using Store.Domain.Models;

namespace Store.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public RegistrationResult Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            Account emailAccount = _accountService.GetByEmail(email);

            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }


            Account usernameAccount = _accountService.GetByUserName(username);

            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                User user = new User()
                {
                    Email = email,
                    UserName = username,
                    PasswordHash = hashedPassword
                };

                Account account = new Account()
                {
                    User = user
                };
                _accountService.Insert(account);
            }

            return result;
        }

        public Account Login(string username, string password)
        {
            Account storedAccount = _accountService.GetByUserName(username);
            if (storedAccount == null)
            {
                throw new InvalidPasswordException(username, password);
            }
            PasswordVerificationResult passwordsResult =
                _passwordHasher.VerifyHashedPassword(storedAccount.User.PasswordHash, password);


            if (passwordsResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }
    }
}
