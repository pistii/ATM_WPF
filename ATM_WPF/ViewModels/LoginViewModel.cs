using atm_wpf.Commands;
using System.Windows.Input;
using atm_wpf.Models;
using System.IO;
using System.Windows;
using System;
using System.Windows.Controls;

namespace atm_wpf.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private int pin;
        private string username;
        private string password;
        private string kartyaId;
        public Cliens _Cliens;

        public BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public LoginViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public bool Login()
        {
            bool belep = false;
            //fullname, pin, kartyaId, balance

            using (StreamReader sr = new StreamReader(@"ATM.txt"))
            {
                foreach (string line in File.ReadLines(@"ATM.txt"))
                {
                    string[] sor = line.Split(',');
                    if (sor[0] == UserName && sor[1] == Pin.ToString() && sor[2] == KartyaId)
                    {
                        belep = true;
                        break;
                    }
                }
                MessageBox.Show("    " + KartyaId);
            }
            if (belep)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool CanUpdate
        {
            get
            {
                if (Cliens.UserName == null && Cliens.KartyaId == null && Cliens.Pin == 0)
                {
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Cliens.UserName);
            }
        }

        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public int Pin
        {
            get
            {
                MessageBox.Show(pin.ToString());
                return pin;
            }
            set
            {
                MessageBox.Show(value.ToString());
                pin = value;
            }
        }

        public string KartyaId
        {
            get
            {
                return kartyaId;
            }
            set
            {
                kartyaId = value;
            }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Balance { get; private set; }


        public Cliens Cliens
        {
            get
            {
                return _Cliens;
            }
        }

    }
}

