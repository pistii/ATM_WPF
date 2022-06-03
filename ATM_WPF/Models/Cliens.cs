using System;
using System.ComponentModel;

namespace atm_wpf.Models
{

    public class Cliens : INotifyPropertyChanged
    {

        private string username;
        private string kartyaId;
        private int pin;
        private int balance;
        private string password;
        private int amount;

        public Cliens(string _name, string _id, int pin, int _balance)
        {
            UserName = _name;
            KartyaId = _id;
            Pin = pin;
            Balance = _balance;
        }

        public int Balance
        {
            get { return balance; }
            set { 
                balance += value;
                OnPropertyChanged("Balance");
            }
        }
        
        public string UserName
        {
            get { return username; }
            set { username = value;
            }
        }

        public string KartyaId
        {
            get { return kartyaId; }
            set { kartyaId = value; }
        }

        public int Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }

    }
}
