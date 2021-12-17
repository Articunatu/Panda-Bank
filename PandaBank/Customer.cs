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
            UserName = _userName;
            Password = _password;
        }

        public void ShoweAccounts()
        {
            if (ListOfAccounts.Count > 0)
            {
                foreach (var item in ListOfAccounts)
                {
                    item.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("Du har inga konton...");
            }

        }

        public void ShoweAccountsNames()
        {
            foreach (var item in ListOfAccounts)
            {
                item.PrintAccountName();
            }
        }

        public void TransferAccounts()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj ett konto att föra över pengar från: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string sendAccount = Console.ReadLine();
            Accounts account = ListOfAccounts.Find(s => s._Name == sendAccount);
            while (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                sendAccount = Console.ReadLine();
                account = ListOfAccounts.Find(s => s._Name == sendAccount);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj sen ett konto att föra över pengar till: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string recieveAccount = Console.ReadLine();
            Accounts account2 = ListOfAccounts.Find(r => r._Name == recieveAccount);
            while (account2 == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                recieveAccount = Console.ReadLine();
                account2 = ListOfAccounts.Find(r => r._Name == recieveAccount);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Skriv hur mycket pengar du vill överföra: ");
            float moneyamount = 0;
            bool isException = false;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    moneyamount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }
            }
            while (isException);

            while (moneyamount > account._Balance)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Det finns för lite pengar på kontot...");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Skriv in ett nytt belopp: ");
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    moneyamount = float.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                }
            }

            ///Calculations and display before the timer was implemented
            //account._Balance -= moneyamount;
            //account._Balance = (float)Math.Round(account._Balance, 3);
            //account2._Balance += (float)ExchangeRate(account, account2, moneyamount);
            //account2._Balance = (float)Math.Round(account2._Balance, 3);

            //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine("Uppdaterad info:");
            //account.PrintInfo();
            //account2.PrintInfo();

            SaveCalculations(moneyamount, (float)ExchangeRate(account, account2, moneyamount), account, account2);
            SaveTranscation(moneyamount, account, false, $"Överföring till annat konto: {account2._Name}");
            SaveTranscation((float)ExchangeRate(account, account2, moneyamount), account2, true, $"Överföring från annat konto: {account._Name}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Transaktionerna går egenom om 15 sekunder.");
        }

        public void TransferMoneyToUser(List<Customer> ListUser)
        {
            ShoweAccounts();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj ett konto att överföra pengar från: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string fromAccount = Console.ReadLine();
            Accounts fromAcc = ListOfAccounts.Find(s => s._Name == fromAccount);
            while (fromAcc == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ogiltigt konto! Skriv in ett nytt: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                fromAccount = Console.ReadLine();
                fromAcc = ListOfAccounts.Find(s => s._Name == fromAccount);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Skriv användare att skicka pengar till: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string toUser = Console.ReadLine();
            Customer toUser2 = ListUser.Find(u => u.UserName == toUser);
            while (toUser2 == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ogiltig användare! Skriv in en ny: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                toUser = Console.ReadLine();
                toUser2 = ListUser.Find(u => u.UserName == toUser);
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n{toUser2.UserName}s konton: ");
            toUser2.ShoweAccountsNames();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj ett konto: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string toAcc = Console.ReadLine();
            Accounts toAccount = toUser2.ListOfAccounts.Find(s => s._Name == toAcc);
            while (toAccount == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ogiltigt konto! Skriv in ett nytt: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                toAcc = Console.ReadLine();
                toAccount = toUser2.ListOfAccounts.Find(s => s._Name == toAcc);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj belopp att överföra: ");
            float amount = 0;
            bool isException = false;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    amount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ogiltigt format! Skriv in ett nytt belopp: ");
                    TransferMoneyToUser(ListUser);
                    isException = true;
                }
            }
            while (isException);

            while (amount > fromAcc._Balance)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Otillräckligt belopp på konto! Vänligen välj nytt belopp: ");
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    amount = float.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ogiltigt format! Vänligen välj nytt belopp: ");
                }
            }

            //fromAcc._Balance -= amount;
            //toAccount._Balance += (float)ExchangeRate(fromAcc, toAccount, amount);
            //fromAcc.PrintInfo();

            SaveTranscation(amount, fromAcc, false, $"Överföring till användare: {toUser2.UserName}");
            toUser2.SaveTranscation((float)ExchangeRate(fromAcc, toAccount, amount), toAccount, true, $"Överföring från användare: {this.UserName}");
            SaveCalculations(amount, (float)ExchangeRate(fromAcc, toAccount, amount), fromAcc, toAccount);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Transaktionerna går egenom om 15 sekunder.");
        }

        public enum Currency
        {
            SEK,
            USD,
            GBP,
            EUR
        }

        public void CreateAccount()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Namnge konto: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string accountName = Console.ReadLine();
            float accountAm = 0;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Svenska krona: SEK | US dollar: USD | Brittisk pund: GBP | Euro: EUR");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj valuta: ");
            string chooseCurrency = "";
            bool isException = true;
            while (isException)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    chooseCurrency = Console.ReadLine().ToUpper();
                    Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);
                    isException = false;
                    Accounts createAccounts = new Accounts(accountName, accountAm, chooseCurrency);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ska det vara ett sparkonto, skriv då JA: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string savingsAnswer = Console.ReadLine().ToUpper();
                    if (savingsAnswer == "JA")
                    {
                        createAccounts.IsSavings = true;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Vill du göra en insättning nu, skriv då JA: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string depositAnswer = Console.ReadLine().ToUpper();
                        if (depositAnswer == "JA")
                        {
                            float InsertedAmount = IntrestAmount(createAccounts);
                            SaveCalculations(InsertedAmount, 0, null, createAccounts);
                            SaveTranscation(InsertedAmount, createAccounts, true, "Insättning på skapat konto\t");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Din insättning går igenom om 15 sekunder");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine(createAccounts._Name + "\t" + createAccounts._Balance + " " + createAccounts._Currency);
                        }
                    }
                    else
                    {
                        createAccounts.IsSavings = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Vill du göra en insättning nu, skriv då JA: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string depositAnswer = Console.ReadLine().ToUpper();
                        if (depositAnswer == "JA")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Skriv hur mycket pengar du vill sätta in: ");
                            float moneyAmount = 0;
                            do
                            {
                                try
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    moneyAmount = float.Parse(Console.ReadLine());
                                    isException = false;
                                }
                                catch (Exception)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                                    isException = true;
                                }
                            }
                            while (isException);
                            SaveCalculations(moneyAmount, 0, null, createAccounts);
                            SaveTranscation(moneyAmount, createAccounts, true, "Insättning på skapat konto\t");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Din insättning går igenom om 15 sekunder");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine(createAccounts._Name + "\t" + createAccounts._Balance + " " + createAccounts._Currency);
                        }
                    }
                    ListOfAccounts.Add(createAccounts);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ogiltigt format! Vänligen välj giltig valuta: ");
                    isException = true;
                }
            }
        }

        public decimal ExchangeRate(Accounts firstAccount, Accounts secondAccount, float moneyAmount)
        {
            decimal result;
            decimal result1 = 0;
            switch (firstAccount._Currency)
            {
                case "SEK":
                    if (secondAccount._Currency == "USD")
                    {
                        result = currencyChange[1] / currencyChange[0];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "GBP")
                    {
                        result = currencyChange[2] / currencyChange[0];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "EUR")
                    {
                        result = currencyChange[3] / currencyChange[0];
                        result1 = (decimal)moneyAmount * result;
                    }
                    break;
                case "USD":
                    if (secondAccount._Currency == "SEK")
                    {
                        result = currencyChange[0] / currencyChange[1];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "GBP")
                    {
                        result = currencyChange[2] / currencyChange[1];
                        result1 = (decimal)moneyAmount / result;
                    }
                    else if (secondAccount._Currency == "EUR")
                    {
                        result = currencyChange[3] / currencyChange[1];
                        result1 = (decimal)moneyAmount / result;
                    }
                    break;
                case "GBP":
                    if (secondAccount._Currency == "SEK")
                    {
                        result = currencyChange[0] / currencyChange[2];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "USD")
                    {
                        result = currencyChange[1] / currencyChange[2];
                        result1 = (decimal)moneyAmount / result;
                    }
                    else if (secondAccount._Currency == "EUR")
                    {
                        result = currencyChange[3] / currencyChange[2];
                        result1 = (decimal)moneyAmount / result;
                    }
                    break;
                case "EUR":
                    if (secondAccount._Currency == "SEK")
                    {
                        result = currencyChange[0] / currencyChange[3];
                        result1 = (decimal)moneyAmount * result;
                    }
                    else if (secondAccount._Currency == "USD")
                    {
                        result = currencyChange[1] / currencyChange[3];
                        result1 = (decimal)moneyAmount / result;
                    }
                    else if (secondAccount._Currency == "GBP")
                    {
                        result = currencyChange[2] / currencyChange[3];
                        result1 = (decimal)moneyAmount / result;
                    }
                    break;
                default:
                    break;
            }
            if (firstAccount._Currency == secondAccount._Currency)
            {
                return (decimal)moneyAmount;
            }
            else
            {
                return result1;
            }
        }
    }
}