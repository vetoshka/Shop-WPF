﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
            _mainWindow.ShowMe();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderWindow(_mainWindow);
            orderWindow.Show();
            Close();
        }
    }
}
