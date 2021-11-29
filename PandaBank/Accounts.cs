using System;

namespace PandaBank
{
    public class Accounts
    {
        public string _Name;
        public float _Balance;

        public Accounts(string Name, float Balance)
        {
            _Name = Name;
            _Balance = Balance;
        }

        public void PrintInfo()
        {
            Console.WriteLine(_Name +": "+ _Balance);
        }
    }
}
