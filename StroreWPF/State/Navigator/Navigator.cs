using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using StoreWPF.Annotations;
using StoreWPF.Commands;
using StoreWPF.Models;
using StoreWPF.ViewModel;

namespace StoreWPF.State.Navigator
{
 public   class Navigator :ObservableObject , INavigator
 {
     private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }

        }
        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
       

    }
}
