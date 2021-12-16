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
            if (name.ToCharArray().GetLength(0) <= 7)
            {
                extender += "\t";
            }
            string extender2 = "";
            if (balance.ToString().ToCharArray().GetLength(0) <= 7)
            {
                extender2 += "\t";
            }
            Console.WriteLine(name + extender + "\t\t" + Math.Round(balance, 2) + extender2 + currency);
        }

        public void PrintAccountName()
        {
            Console.WriteLine(name);
        }
    }

    public struct Transcation
    {
        #region Fields
        DateTime timeOfTransfer;
        float transaction;
        Accounts transferAccount;
        bool plusOrMinus;
        string changedTransfer;
        Customer user;

        public DateTime TimeOfTransfer { get => timeOfTransfer; set => timeOfTransfer = value; }
        public float MoneyAmount { get => transaction; set => transaction = value; }
        public Accounts TransferAccount { get => transferAccount; set => transferAccount = value; }
        public bool PlusOrMinus { get => plusOrMinus; set => plusOrMinus = value; }
        public string ChangedTransfer { get => changedTransfer; set => changedTransfer = value; }
        internal Customer User { get => user; set => user = value; }
        #endregion

        public string SavedTransfer()
        {
            char mathSign = plusOrMinus ? '+' : '-';
            return $"{transferAccount._Name}\t {changedTransfer}\t {mathSign}{Math.Round(transaction, 2)} {transferAccount._Currency}";
        }
    }

    public struct Calculation
    {
        #region Fields
        private Accounts recieveAccount, sendAccount;
        private float recieveAmount, sendAmount;

        public Accounts RecieveAccount { get => recieveAccount; set => recieveAccount = value; }
        public Accounts SendAccount { get => sendAccount; set => sendAccount = value; }
        public float RecieveAmount { get => recieveAmount; set => recieveAmount = value; }
        public float SendAmount { get => sendAmount; set => sendAmount = value; }
        #endregion

        public void SetCalculatedBalance()
        {
            if (sendAccount == null)///Deposit Money
            {
                recieveAccount._Balance +=  sendAmount; 
                recieveAccount._Balance = (float)Math.Round(recieveAccount._Balance, 2);
            }
            else if (recieveAccount == null)///Withdraw Money
            {
                sendAccount._Balance -= sendAmount;  
                sendAccount._Balance = (float)Math.Round(sendAccount._Balance, 2);
            }
            else///Transcations between accounts
            {
                sendAccount._Balance -= sendAmount;
                sendAccount._Balance = (float)Math.Round(sendAccount._Balance, 2);
                recieveAccount._Balance += recieveAmount;
                recieveAccount._Balance = (float)Math.Round(recieveAccount._Balance, 2);
            }
        }
    }
}