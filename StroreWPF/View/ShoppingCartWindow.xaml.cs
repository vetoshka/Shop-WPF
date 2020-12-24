using StoreWPF.ViewModel;
using System.Windows;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for ShoppingCartWindow.xaml
    /// </summary>
    public partial class ShoppingCartWindow : Window
    {
        private readonly MainWindow _mainWindow;
        public ShoppingCartWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = new ShoppingCartVM(ApplicationService.Instance.EventAggregator);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(_mainWindow);
            orderWindow.Show();
            Close();
        }
    }
}
