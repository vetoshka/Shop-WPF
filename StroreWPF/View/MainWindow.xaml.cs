using StoreWPF.ViewModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ShoppingCartWindow shoppingCartWindow;
        public AdminPanelVM AdminPanelVm { get; set; }
        public MainWindow(){


            InitializeComponent();

        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            var adminPanel = new AdminPanel(this ,AdminPanelVm);
            Hide();
            adminPanel.Show();

        }

        private void ShoppingCartButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            shoppingCartWindow.Show();

        }
    }
}
