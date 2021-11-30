using System;

namespace PandaBank
{
    public class Accounts
    {
        private string name;
        private float balance;

        public string _Name { get => name; set => name = value; }
        public float _Balance { get => balance; set => balance = value; }

        public Accounts(string _name, float _balance)
        {
            name = _name;
            balance = _balance;
        }

        public void PrintInfo()
        {
            Console.WriteLine(name + ": "+ balance);
        }
    }
}
