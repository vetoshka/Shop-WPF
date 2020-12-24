using Prism.Commands;
using Store.Domain.Models;
using Store.Domain.Services.AuthenticationServices;
using System;
using System.Windows;

namespace StoreWPF.ViewModel
{
    public class LogViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public Account Account { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LogViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LogIn = new DelegateCommand(() =>
            {
                try
                {
                    Account = _authenticationService.Login(Username, Password);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "Error");
                }

            });

        }
        public DelegateCommand LogIn { get; }
    }
}
