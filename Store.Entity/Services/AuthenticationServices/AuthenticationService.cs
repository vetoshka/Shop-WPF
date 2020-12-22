using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            var emailAccount = await _accountService.GetByEmail(email);

            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }


            var usernameAccount = await _accountService.GetByUserName(username);

            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                var user = new User()
                {
                    Email = email,
                    UserName = username,
                    PasswordHash = hashedPassword
                };

                Account account = new Account()
                {
                    AccountHolder = user
                };
                await _accountService.Insert(account);
            }

            return result;
        }

        public  async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountService.GetByUserName(username);
            var  passwordsResult =
                _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);


            if (passwordsResult == PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }
    }
}
