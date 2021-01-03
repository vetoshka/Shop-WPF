using Prism.Commands;
using Store.Domain.Services.AuthenticationServices;
using System.Windows;

namespace StoreWPF.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            Register = new DelegateCommand(() =>
            {
                RegistrationResult result = _authenticationService.Register(Email, UserName, Password, RepeatPassword);
                MessageBox.Show(result.ToString());
            });
        }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public DelegateCommand Register { get; }
    }
}
