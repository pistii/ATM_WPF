using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using atm_wpf.Commands;
using atm_wpf.Models;

namespace atm_wpf.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        Random random = new Random();
        private string username;
        private int id; //Későbbi kártyaid
        private string kartyaId = "";
        private int pin;
        private bool egyedi = false;
        public BaseViewModel _selectedViewModel;
        private Cliens _Cliens;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public RegistrationViewModel()
        {
            GenerateIds();
            _Cliens = new Cliens(username, kartyaId, pin, 100000);
            UpdateViewCommand = new UpdateViewCommand(this);
            UpdateCommand = new CliensUpdateCommand(this);
        }
        public Cliens Cliens
        {
            get
            {
                return _Cliens;
            }
        }

        public ICommand UpdateCommand {get; private set; }
        public ICommand UpdateViewCommand { get; set; }

        public bool CheckRegistrationFields()
        {
            if (String.IsNullOrWhiteSpace(Cliens.UserName) || Cliens.UserName == "Név")
            {
                MessageBox.Show("Név kitöltése kötelező");
                return false;
            } else
            {
                SaveCliens();
                return true;
            }
        }

        private void GenerateIds()
        {
            int cardL = 0;
            pin = random.Next(100, 999);
            while (cardL < 3)
            {
                Console.WriteLine(cardL);
                id = random.Next(1000, 9999);
                kartyaId += String.Concat(id + "-");
                cardL++;
                if (cardL >= 3)
                {
                    id = random.Next(1000, 9999);
                    kartyaId += String.Concat(id);
                    break;
                }
            }
        }

        private void SaveCliens()
        {
            if (!File.Exists(@"ATM.txt"))
            {
                StreamWriter sw = new StreamWriter(@"ATM.txt");
            }
            else
            {
                while (!egyedi)
                {
                    foreach (string line in File.ReadLines(@"ATM.txt"))
                    {
                        string[] words = line.Split(',');

                        if (Cliens.UserName == words[0])
                        {
                            //MessageBox.Show("Ez a személy már regisztrált.");
                            break;
                        }
                    }
                    break;
                }
            }
            using (StreamWriter sw = new StreamWriter(@"ATM.txt", append: true))
            {
                sw.WriteLine(_Cliens.UserName + "," + _Cliens.Pin + "," + _Cliens.KartyaId + "," + 0 + ",");
            }
        }


        public bool CanUpdate
        {
            get
            {
                if (Cliens.UserName == null)
                {
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Cliens.UserName);
            }
        }
    }
}
