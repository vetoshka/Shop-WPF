using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StoreWPF.State.Navigator;
using StoreWPF.ViewModel;

namespace StoreWPF.Commands
{
   public class UpdateCurrentViewModelCommand : ICommand
   {
       private INavigator _navigator;

       public UpdateCurrentViewModelCommand(INavigator navigator)
       {
           _navigator = navigator;
       }

       public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Main:
                        _navigator.CurrentViewModel = new MainViewModel();
                        break;
                    case ViewType.Register:
                        break;
                    case ViewType.Log:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
