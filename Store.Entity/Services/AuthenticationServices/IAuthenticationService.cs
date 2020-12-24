using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Services.AuthenticationServices
{

    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }
    public interface IAuthenticationService
    {
        RegistrationResult Register(string email, string username, string password, string confirmPassword);
        Account Login(string username, string password);
    }
}
