using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Store.Domain;
using Store.Domain.Data;
using Store.Services;
using StoreWPF.View;
using StoreWPF.ViewModel;

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
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }




        private void Back_Click(object sender, RoutedEventArgs e)
        { 
            
            this.Hide();
            _mainWindow.ShowMe();
        }
    }
}
