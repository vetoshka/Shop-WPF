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
            DataContext = new MainWindowVM(ApplicationService.Instance.EventAggregator);
            shoppingCartWindow = new ShoppingCartWindow(this);

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
