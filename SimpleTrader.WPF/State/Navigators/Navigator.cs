using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SimpleTrader.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio
    }

    public class Navigator : ObservableObjects, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

    }
}
