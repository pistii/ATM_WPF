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
        private int amount;

        public Cliens(string _name, string _cardId, int pin, int _balance)
        {
            UserName = _name;
            KartyaId = _cardId;
            Pin = pin;
            Balance = _balance;
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
        public int Balance
        {
            get { return balance; }
            set
            {
                balance += value;
                OnPropertyChanged("Balance");
            }
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                Balance += value;
                /*
                if (int.TryParse(value, out value))
                {
                    if (amount >= 1)
                    {
                        Balance += value;

                    }
                    else if (amount <= -1)
                    {
                        Balance -= value;
                    }
                } else { Int32.Parse(value)};
                */
            }
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
