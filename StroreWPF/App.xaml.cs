using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.Design;
using System.Windows;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prism.Events;
using Store.Domain;
using Store.Domain.Services;
using Store.EntityFramework;
using StoreWPF.View;
using StoreWPF.ViewModel;

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

            Window window = new MainWindow
            {
                DataContext = serviceProvider.GetService<MainWindowVM>(),
                AdminPanelVm = serviceProvider.GetService<AdminPanelVM>()
            };
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider СreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<StoreDbContextFactory>();
            services.AddScoped<IDataService<Warehouse>, GenericDataService<Warehouse>>();
            services.AddScoped<IDataService<Product>, GenericDataService<Product>>();
            services.AddScoped<IDataService<Vendor>, GenericDataService<Vendor>>();
            services.AddScoped<IDataService<Order>, GenericDataService<Order>>();
            services.AddScoped<IDataService<ShoppingCart>, GenericDataService<ShoppingCart>>();
            services.AddScoped<IDataService<ShoppingCartItem>, GenericDataService<ShoppingCartItem>>();
            services.AddScoped<AdminPanelVM>();
            services.AddScoped<MainWindowVM>();

            return services.BuildServiceProvider();
        }
    }
}
