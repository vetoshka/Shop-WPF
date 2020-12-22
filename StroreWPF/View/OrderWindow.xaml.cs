using System.Windows;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private readonly MainWindow _mainWindow;
        public OrderWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Show();
           // _mainWindow.shoppingCartWindow = new ShoppingCartWindow(_mainWindow);
            Close();

        }
    }
}
