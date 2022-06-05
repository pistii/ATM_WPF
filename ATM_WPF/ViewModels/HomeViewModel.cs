
using System.Collections.Generic;
using atm_wpf.Models;
using atm_wpf.Commands;
using System.Windows.Input;
using System;
using System.IO;

namespace atm_wpf.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        public Cliens _Cliens;
        private int pin;
        private string username;
        private string password;
        private string kartyaId;
        public BaseViewModel _selectedViewModel;

        public ICommand UpdateCommand { get; private set; }
        public ICommand UpdateViewCommand { get; private set; }

        public HomeViewModel()
        {
            UpdateCommand = new UpdateViewCommand(this);
            _Cliens = new Cliens(username, kartyaId, pin, 123);
        }

        public Cliens Cliens {
            get {
                return _Cliens;
            }
        }

        public void Withdraw()
        {
            int amount = 3;
            if (Cliens.Balance < amount)
            {
                Console.WriteLine("Nincs elég fedezet a kártyán.");
            }
            if ((amount - Cliens.Balance == 0) || (amount < Cliens.Balance))
            {
                Cliens.Balance = Cliens.Balance - amount;
            }
        }

        public void Deposit()
        {
            Console.WriteLine("írd be mennyit szeretnél betenni: ");
            int amount = Int32.Parse(Console.ReadLine()); //amount = the user required to withdraw the amount of money

            if (Cliens.Balance < amount)
            {
                Console.WriteLine("Nincs elég fedezet.");
            }
            if ((amount - Cliens.Balance == 0) || (amount < Cliens.Balance))
            {
                Cliens.Balance = Cliens.Balance - amount;
            }
        }

        public void Send()
        {
            Console.WriteLine("Mennyi pénzt szeretnél küldeni? ");
            int send = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Cél ID: ");
            int target = Int32.Parse(Console.ReadLine());
            string[] bank = new string[10];
            List<string> ls = new List<string>();


            using (StreamReader sr = new StreamReader("ATM.txt"))
            {
                foreach (string line in File.ReadLines("ATM.txt"))
                {
                    string[] words = line.Split(',');

                    for (int i = 0; i < words.Length; i++)
                    {
                        ls.Add(words[i]);
                    }


                    Console.WriteLine();
                }
            }
        }
    }
}