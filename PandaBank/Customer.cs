using System;
using System.Collections.Generic;

namespace PandaBank
{
    class Customer : LoginUser
    {
        public List<Accounts> ListOfAccounts = new List<Accounts>();

        public void AddAccounts(Accounts _Account)
        {
            ListOfAccounts.Add(_Account);
        }

        public Customer(string _userName, string _password)
        {
            userName = _userName;
            password = _password;
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
            while (account == null)
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

            while (moneyamount > account._Balance)
            {
                Console.WriteLine("Det finns för lite pengar på kontot...\nSkriv in ett nytt belopp:");
                try
                {
                    moneyamount = int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Ogiltigt format!");
                    TransferAccounts();
                }
            }

            account._Balance -= moneyamount;
            account2._Balance += moneyamount;

            Console.WriteLine("Uppdaterad info:");
            account.PrintInfo();
            account2.PrintInfo();
        }
        public void TransferMoneyToUser(List<Customer>ListUser)
        {
            Console.WriteLine("Välj ett konto att överföra pengar från: ");
            Console.WriteLine(" ");
            ShoweAccounts();
            Console.Write("Konto: ");
            string fromAccount = Console.ReadLine();
            Accounts fromAcc = ListOfAccounts.Find(s => s._Name == fromAccount);
            while (fromAcc == null)
            {
                fromAccount = Console.ReadLine();
            }

            Console.Write("Skriv användare att skicka pengar till: ");
            string toUser = Console.ReadLine();
            LoginUser toUser2 = ListUser.Find(u => u.userName == toUser);
            while (toUser2 == null)
            {
                fromAccount = Console.ReadLine();
            }
            Console.WriteLine("Välj konto att skicka till");
                Console.WriteLine("");
           // ShoweAccounts();
                Console.Write("Konto: ");
                string toAcc = Console.ReadLine();
                Accounts toAccount = ListOfAccounts.Find(s => s._Name == toAcc);
            while (toAccount == null)
            {
                fromAccount = Console.ReadLine();
            }

            Console.Write("Välj summa att överföra: ");
                string am = Console.ReadLine();
                int amount = Convert.ToInt32(am);
                if (amount > fromAcc._Balance)
                {
                    Console.Write("Otillräckligt belopp på konto! Vänligen välj nytt belopp: ");
                }
                else
                {
                    fromAcc._Balance -= amount;
                    toAccount._Balance += amount;

                    Console.WriteLine($"Nuvarande belopp: ");
                    fromAcc.PrintInfo();
                }
            

        }
    }
}
