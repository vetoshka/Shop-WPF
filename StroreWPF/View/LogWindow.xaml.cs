using StoreWPF.ViewModel;
using System.Threading;
using System.Windows;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public RegisterWindow registerWindow;
        public MainWindow MainWindow;
        public LogWindow(LogViewModel logViewModel)
        {
            InitializeComponent();
            DataContext = logViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registerWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new ThreadStart(delegate ()
            {

                MainWindow.Show();
                Close();

            }), null);
        }
    }
}
