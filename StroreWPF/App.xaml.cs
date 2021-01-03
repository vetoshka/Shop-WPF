using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.Domain.Services.AuthenticationServices;
using Store.EntityFramework;
using Store.EntityFramework.Services;
using StoreWPF.View;
using StoreWPF.ViewModel;
using System;
using System.Windows;

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = СreateServiceProvider();

            LogWindow window = new LogWindow(serviceProvider.GetRequiredService<LogViewModel>())
            {
                registerWindow = new RegisterWindow(serviceProvider.GetRequiredService<RegisterViewModel>()),
                MainWindow = new MainWindow()
            };
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider СreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<StoreDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IAccountService, AccountDataService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            //services.AddSingleton<IDataService<Warehouse>, GenericDataService<Warehouse>>();
            //services.AddSingleton<IDataService<Product>, GenericDataService<Product>>();
            //services.AddSingleton<IDataService<Vendor>, GenericDataService<Vendor>>();
            //services.AddSingleton<IDataService<Order>, GenericDataService<Order>>();
            //services.AddSingleton<IDataService<ShoppingCart>, GenericDataService<ShoppingCart>>();
            //services.AddSingleton<IDataService<ShoppingCartItem>, GenericDataService<ShoppingCartItem>>();



            services.AddScoped<RegisterViewModel>();
            //services.AddScoped<AdminPanelVM>();
            //services.AddScoped<ShoppingCartVM>();
            //services.AddScoped<MainViewModel>();

            services.AddScoped<LogViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
