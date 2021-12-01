using System;
using System.Collections.Generic;

namespace PandaBank
{
    partial class Customer : LoginUser
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
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                sendAccount = Console.ReadLine();
                account = ListOfAccounts.Find(s => s._Name == sendAccount);
            }

            Console.WriteLine("Välj sen ett konto att föra över pengar till:");
            string recieveAccount = Console.ReadLine();
            Accounts account2 = ListOfAccounts.Find(r => r._Name == recieveAccount);
            while (account2 == null)
            {
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                recieveAccount = Console.ReadLine();
                account2 = ListOfAccounts.Find(r => r._Name == recieveAccount);
            }

            Console.WriteLine("Hur mycket pengar vill du föra över?");
            float moneyamount = 0;
            bool isException = false;
            do
            {
                try
                {
                    moneyamount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }
            }
            while (isException);

            while (moneyamount > account._Balance)
            {
                Console.Write("Det finns för lite pengar på kontot...\nSkriv in ett nytt belopp: ");
                try
                {
                    moneyamount = float.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                }
            }

            account._Balance -= moneyamount;
            account._Balance = (float)Math.Round(account._Balance, 3);
            account2._Balance += moneyamount;
            account2._Balance = (float)Math.Round(account2._Balance, 3);


            Console.WriteLine("Uppdaterad info:");
            account.PrintInfo();
            account2.PrintInfo();

            SaveTranscation(moneyamount, account, false);
            SaveTranscation(moneyamount, account2, true);
        }
        public void TransferMoneyToUser(List<Customer> ListUser)
        {
            Console.WriteLine("Välj ett konto att överföra pengar från: ");
            Console.WriteLine(" ");
            ShoweAccounts();
            Console.Write("Konto: ");
            string fromAccount = Console.ReadLine();
            Accounts fromAcc = ListOfAccounts.Find(s => s._Name == fromAccount);
            while (fromAcc == null)
            {
                Console.Write("Ogiltigt konto! Skriv in ett nytt: ");
                fromAccount = Console.ReadLine();
                fromAcc = ListOfAccounts.Find(s => s._Name == fromAccount);
            }

            Console.Write("Skriv användare att skicka pengar till: ");
            string toUser = Console.ReadLine();
            Customer toUser2 = ListUser.Find(u => u.userName == toUser);
            while (toUser2 == null)
            {
                Console.Write("Ogiltig användare! Skriv in en ny: ");
                toUser = Console.ReadLine();
                toUser2 = ListUser.Find(u => u.userName == toUser);
            }

            Console.WriteLine("Välj konto att skicka till\n");
            toUser2.ShoweAccounts();
            Console.Write("Konto: ");
            string toAcc = Console.ReadLine();
            Accounts toAccount = toUser2.ListOfAccounts.Find(s => s._Name == toAcc);
            while (toAccount == null)
            {
                Console.Write("Ogiltigt konto! Skriv in ett nytt: ");
                toAcc = Console.ReadLine();
                toAccount = toUser2.ListOfAccounts.Find(s => s._Name == toAcc);
            }

            Console.Write("Välj summa att överföra: ");
            float amount = 0;
            bool isException = false;
            do
            {
                try
                {
                    amount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Skriv in ett nytt belopp: ");
                    TransferMoneyToUser(ListUser);
                    isException = true;
                }
            }
            while(isException);

            while (amount > fromAcc._Balance)
            {
                Console.Write("Otillräckligt belopp på konto! Vänligen välj nytt belopp: ");
                try
                {
                    amount = float.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen välj nytt belopp: ");
                }
            }

            fromAcc._Balance -= amount;
            toAccount._Balance += amount;

            fromAcc.PrintInfo();

            SaveTranscation(amount, fromAcc, false);
            toUser2.SaveTranscation(amount, toAccount, true);
        }
        public void CreateAccount()
        {
            Console.Write("Namnge konto: ");
            string accountName = Console.ReadLine();
            float accountAm = 0;
            Accounts createAccounts = new Accounts(accountName, accountAm);
            ListOfAccounts.Add(createAccounts);
            Console.WriteLine(createAccounts._Name + " " + createAccounts._Balance);
        }
    }
}
