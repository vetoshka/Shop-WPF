using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Store.Domain;
using Store.Domain.Data;
using Store.Services;
using StoreWPF.ViewModel;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ShoppingCartWindow shoppingCartWindow;
        public MainWindow()
        {
            
            
            InitializeComponent();
            this.DataContext = new MainWindowVM(ApplicationService.Instance.EventAggregator);
            shoppingCartWindow=new ShoppingCartWindow(this);

        }
        public void ShowMe()
        {
            (FindResource("showMe") as Storyboard).Begin(this);
        }
        public void HideMe()
        {
            (FindResource("hideMe") as Storyboard).Begin(this);
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            var adminPanel = new AdminPanel(this);
            HideMe();
            adminPanel.Show();

        }

        private void ShoppingCartButton_Click(object sender, RoutedEventArgs e)
        {
            HideMe();
            shoppingCartWindow.Show();
           
        }
    }
}
