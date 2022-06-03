using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using atm_wpf.ViewModels;

namespace atm_wpf.Commands
{
    class CliensUpdateCommand : ICommand
    {
        private RegistrationViewModel registrationViewModel;
        private MainViewModel mainviewModel;
        private LoginViewModel loginviewModel;

        public CliensUpdateCommand(RegistrationViewModel viewmodel)
        {
            registrationViewModel = viewmodel;
        }

        public CliensUpdateCommand(MainViewModel mainViewModel)
        {
            mainviewModel = mainViewModel;
        }
        
        public CliensUpdateCommand(LoginViewModel loginViewModel)
        {
            loginviewModel = loginViewModel;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
