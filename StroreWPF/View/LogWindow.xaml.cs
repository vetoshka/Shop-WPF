using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StoreWPF.ViewModel;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public RegisterWindow registerWindow;
        public MainWindow MainWindow;
        public LogWindow( LogViewModel logViewModel)
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
