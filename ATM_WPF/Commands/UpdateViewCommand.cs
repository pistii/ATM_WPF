﻿using atm_wpf.ViewModels;
using System;
using System.Windows.Input;
using atm_wpf.Models;
using System.Windows;

namespace atm_wpf.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;
        private RegistrationViewModel registrationViewModel;
        private LoginViewModel loginViewModel;


        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public UpdateViewCommand(RegistrationViewModel registrationViewModel)
        {
            this.registrationViewModel = registrationViewModel;
        }

        public UpdateViewCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
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
            if (parameter.ToString() == "Registration")
            {
                viewModel.SelectedViewModel = new RegistrationViewModel();
            }

            else if (parameter.ToString() == "Login")
            {
                if (loginViewModel.Login())
                {
                    viewModel.SelectedViewModel = new LoginViewModel();
                } else
                {
                    MessageBox.Show("Hibás adatok.");
                }
               
            }
            else if (parameter.ToString() == "RegistOK")
            {
                if (registrationViewModel.CheckRegistrationFields())
                {
                    registrationViewModel.SelectedViewModel = new HomeViewModel();
                }
            }
        } 
    }
}
