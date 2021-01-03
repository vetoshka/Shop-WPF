using StoreWPF.ViewModel;
using System.Windows;

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
            DataContext = new MainViewModel(ApplicationService.Instance.EventAggregator);
            shoppingCartWindow = new ShoppingCartWindow(this);

        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel(this);
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
