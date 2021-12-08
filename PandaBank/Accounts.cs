using System;

namespace PandaBank
{
    public class Accounts
    {
        #region Fields
        private string name;
        private float balance;
        private string currency;
        private bool isSavings;

        public string _Name { get => name; set => name = value; }
        public float _Balance { get => balance; set => balance = value; }
        public string _Currency { get => currency; set => currency = value; }
        public bool IsSavings { get => isSavings; set => isSavings = value; }

        #endregion

        public Accounts(string _name, float _balance, string _currency)
        {
            name = _name;
            balance = _balance;
            currency = _currency;
        }

        public void PrintInfo()
        {
            string extender = "";
            if (name.ToCharArray().GetLength(0) < 7)
            {
                extender += "\t";
            }
            Console.WriteLine(name + extender + "\t"+ balance + "\t" + currency);
        }
        
        public void PrintAccountName()
        {
            Console.WriteLine("Bankkonto: "+name);
        }
    }
}
