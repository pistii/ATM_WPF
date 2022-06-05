using atm_wpf.Commands;
using System.Windows.Input;
using atm_wpf.Models;
using System.IO;
using System.Windows;
using System;
using System.Windows.Controls;

namespace atm_wpf.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private int pin;
        private string username;
        private string password;
        private string kartyaId;
        public BaseViewModel _selectedViewModel;
        private Cliens _Cliens;


        public LoginViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            UpdateCommand = new CliensUpdateCommand(this);

            _Cliens = new Cliens(username, kartyaId, pin, 123);

        }

        public Cliens Cliens
        {
            get
            {
                return _Cliens;
            }
        }

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateCommand { get; private set; }
        public ICommand UpdateViewCommand { get; private set; }



        public bool Login()
        {
            bool belep = false;
            using (StreamReader sr = new StreamReader(@"ATM.txt"))
            {
                foreach (string line in File.ReadLines(@"ATM.txt"))
                {
                    string[] sor = line.Split(',');
                    if (sor[0] == _Cliens.UserName && sor[1] == _Cliens.Pin.ToString() && sor[2] == _Cliens.KartyaId)
                    {
                        belep = true;
                        break;
                    }
                }
            }
            if (belep)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Név, kártyaid vagy pin nem megfelelő.");
                return false;
            }
            
        }

    }
}

