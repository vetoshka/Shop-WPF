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
        public MainWindow()
        {


            InitializeComponent();
            this.DataContext = new MainWindowVM(ApplicationService.Instance.EventAggregator);
            shoppingCartWindow = new ShoppingCartWindow(this);

        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            var adminPanel = new AdminPanel(this);
            Hide();
            adminPanel.Show();

        }

        private void ShoppingCartButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            shoppingCartWindow.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
