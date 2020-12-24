using StoreWPF.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {

        private MainWindow _mainWindow;
        public AdminPanel(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            this.DataContext = new AdminPanelVM(ApplicationService.Instance.EventAggregator);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }




        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Hide();
            _mainWindow.Show();
        }
    }
}
