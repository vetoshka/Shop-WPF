using StoreWPF.ViewModel;
using System.Windows;

namespace StoreWPF.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            DataContext = registerViewModel;
        }

    }
}
