using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StoreWPF.ViewModel;

namespace StoreWPF.State.Navigator
{
    public enum ViewType
    {
        Main,
        Register,
        Log
    }
   public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
