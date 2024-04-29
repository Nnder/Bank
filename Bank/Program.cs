using System;
using System.Collections.Generic;

namespace Bank
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank("AlfaBank");
            
            Client client1 = new Client("Jonh", 50000);
            Deposit deposit1 = new Deposit(12, 7, 50000);
            
            Client client2 = new Client("Roma", 400000);
            Deposit deposit2 = new Deposit(6, 9, 400000);
            
            
            client1.OpenDeposit(deposit1);
            client2.OpenDeposit(deposit2);
            
            bank.AddClient(client1);
            bank.AddClient(client2);
            

            int monthsOfWork = 0;
            while (monthsOfWork != 60)
            {
                monthsOfWork++;
                bank.Work();
                Console.WriteLine($"{bank.Name} Month of work {monthsOfWork} ------------------------------------------");
            }
            

        }


        abstract class Person
        {
            public string Name;

            public Person(string name)
            {
                Name = name;
            }
            

        }

        class Bank
        {
            public string Name;
            private List<Client> _clients = new List<Client>();

            public Bank(string name)
            {
                Name = name;
            }

            public void AddClient(Client client)
            {
                _clients.Add(client);
            }

            private void NextMonth()
            {
                foreach (var client in _clients)
                {
                    client.CheckDeposit();
                }
            }

            public void Work()
            {
                NextMonth();
                
            }
            
        }

        class Deposit
        {
            public int Month { get; private set; }
            private int CurrentMonth = 0;
            public double Percentage { get; private set; }
            private double _money = 0;
            
            public Deposit(int month, double percentage, double money)
            {
                Month = month;
                Percentage = percentage / 100;
                _money = money;
            }

            public int NextMonth()
            {
                _money += Math.Round( _money * Percentage, 2);
                return CurrentMonth++;
            }

            public double Close()
            {
                return _money;
            }
        }

        class Client : Person
        {
            private double _money = 0;

            private double _moneyToGet = 0;
            private Deposit _deposit;

            public Client(string name, double money) : base(name)
            {
                _money = money;
            }

            public void OpenDeposit(Deposit deposit)
            {
                _deposit = deposit;
                for (int i = 0; i < _deposit.Month; i++)
                {
                    _moneyToGet += (_money + _moneyToGet) * _deposit.Percentage;
                    
                }
            }

            public void CheckDeposit()
            {
                if (_deposit != null)
                {
                    int Month = _deposit.NextMonth();
                    
                    if (Month == _deposit.Month)
                    {
                        CloseDeposit();
                    }
                }
            }
            
            public void CloseDeposit()
            {
                if (_deposit != null)
                {
                    double money = _deposit.Close();
                    _money = money;
                    _deposit = null;
                    Console.WriteLine($"For Client {Name} Current Money: {_money}");
                }
            }

          
        }

        class Statistic
        {
            
        }
    }
}
