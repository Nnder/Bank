namespace Bank
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            
        }


        abstract class Person
        {
            public string Name;

            public Person(string name)
            {
                Name = name;
            }
            

        }

        class Deposit
        {
            public int Month { get; private set; }
            private int CurrentMonth = 0;
            public int Percentage { get; private set; }
            private int _money = 0;
            
            public Deposit(int month, int percentage, int money)
            {
                Month = month;
                Percentage = percentage;
                _money = money;
            }

            public int NextMonth()
            {
                if (CurrentMonth == Month)
                {
                    
                }
                
                return 
            }
        }

        class Client : Person
        {
            private int _money = 0;

            private int _moneyToGet = 0;
            private Deposit _deposit;

            public Client(string name, int money) : base(name)
            {
                _money = money;
            }

            public void OpenDeposit(Deposit deposit)
            {
                _deposit = deposit;
            }
            
            public void CloseDeposit()
            {
                
                _deposit = null;
            }

          
        }

        class Consultant : Person
        {
            private Client _client;

            public Consultant(string name, Client client) : base(name)
            {
                _client = client;
            }
            
            
        }



        class Statistic
        {
            
        }
    }
}