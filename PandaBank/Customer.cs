using System;
using System.Collections.Generic;
using System.Text;

namespace PandaBank
{
    class Customer : LoginUser
    {
        public List<Accounts> ListOfAccounts = new List<Accounts>();

        public void AddAccounts(Accounts _Account)
        {
            ListOfAccounts.Add(_Account);
        }

        public Customer(List<Accounts> _ListofAccounts, string _userName, string _password)
        {
            userName = _userName;
            password = _password;
            ListOfAccounts = _ListofAccounts;
        }

        public void ShoweAccounts()
        {
            foreach (var item in ListOfAccounts)
            {
                item.PrintInfo();
            }
        }

        public void TransferAccounts()
        {
            Console.WriteLine("Välj ett konto att föra över pengar från:");
            string sendAccount = Console.ReadLine();
            Accounts account = ListOfAccounts.Find(s => s._Name == sendAccount);
            while(account == null)
            {
                sendAccount = Console.ReadLine();
            }

            Console.WriteLine("Välj sen ett konto att föra över pengar till:");
            string recieveAccount = Console.ReadLine();
            Accounts account2 = ListOfAccounts.Find(r => r._Name == recieveAccount);
            while (account2 == null)
            {
                sendAccount = Console.ReadLine();
            }

            Console.WriteLine("Hur mycket pengar vill du föra över?");
            int moneyamount;

            try
            {
                moneyamount = int.Parse(Console.ReadLine());
                
            }
            catch (Exception)
            {
                Console.WriteLine("Ogiltigt format!");
                throw;
            }

            account._Balance -= moneyamount;
            account2._Balance += moneyamount;
            Console.WriteLine("Uppdaterad info:");
            account.PrintInfo();
            account2.PrintInfo();
        }
    }
}
