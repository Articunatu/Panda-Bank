using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaBank
{
    partial class Customer : LoginUser
    {
        List<string> Transactions = new List<string>();

        public void SaveTranscation(float transaction, Accounts transferAccount, bool plusOrMinus, string changedTransfer)
        {
            char mathSign = plusOrMinus ? '+' : '-';
            string savedTransfer = $"{transferAccount._Name}\t {changedTransfer}\t {mathSign}{transaction} {transferAccount._Currency}";
            Transactions.Add(savedTransfer);
        }

        public void ShowTransactions()
        {
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
            if (Transactions.Count == 0)
            {
                Console.WriteLine("Inga transaktioner ännu genomförts");
            }
        }

        //Call on CreateAccount instead
        //public void CreateSavingsAccount()
        //{
        //    Console.Write("Namnge sparkonto: ");
        //    string accountName = Console.ReadLine();
        //    float accountAm = 0;
        //    Console.WriteLine("Svenska krona: kr | US dollar: dollar | Brittisk pund: pund | Euro: euro ");
        //    Console.Write("Välj valuta: ");
        //    string chooseCurrency = Console.ReadLine();
        //    Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);  
        //    Accounts createAccounts = new Accounts(accountName, accountAm, chooseCurrency);
        //    createAccounts.IsSavings = true;
        //    ListOfAccounts.Add(createAccounts);
        //    Console.WriteLine(createAccounts._Name + " " + createAccounts._Balance + " " + createAccounts._Currency);
        //}

        public void DepositMoney()
        {
            ShoweAccounts();
            Console.Write("Välj ett konto att sätta in pengar på: ");
            string depositText = Console.ReadLine();
            Accounts depositAccount = ListOfAccounts.Find(s => s._Name == depositText);
            while (depositAccount == null)
            {
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                depositText = Console.ReadLine();
                depositAccount = ListOfAccounts.Find(s => s._Name == depositText);
            }

            Console.Write("Skriv hur mycket pengar du vill sätta in: ");
            float moneyAmount = 0;
            bool isException = false;
            do
            {
                try
                {
                    moneyAmount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }
            }
            while (isException);

            if (depositAccount.IsSavings == true)
            {
                decimal IntrestRate = 0.01M;
                decimal YearlyAmount = IntrestRate * (decimal)moneyAmount;
                Console.WriteLine("Om räntan är " + IntrestRate*100 + "% kommer du att få en årlig summa på: " + Math.Round(YearlyAmount, 2));
            }

            depositAccount._Balance += moneyAmount;
            depositAccount.PrintInfo();
            SaveTranscation(moneyAmount, depositAccount, true, "Insättning på bankomat");
        }

        public void WithdrawMoney()
        {
            ShoweAccounts();
            Console.Write("Välj ett konto att ta ut pengar ifrån: ");
            string withdrawText = Console.ReadLine();
            Accounts withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
            while (withdrawAccount == null)
            {
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                withdrawText = Console.ReadLine();
                withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
            }

            Console.Write("Skriv hur mycket pengar vill du ta ut: ");
            float moneyAmount = 0;
            bool isException = false;
            do
            {
                try
                {
                    moneyAmount = float.Parse(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }
            }
            while (isException);

            withdrawAccount._Balance -= moneyAmount;
            withdrawAccount.PrintInfo();
            SaveTranscation(moneyAmount, withdrawAccount, false, "Uttag genom bankomat");
        }

        public float IntrestAmount()
        {
            decimal IntrestRate = 0.01M;
            Console.Write("Skriv hur mycket vill du sätta in: ");
            decimal InsertedAmount = Convert.ToDecimal(Console.ReadLine());
            decimal YearlyAmount = IntrestRate * InsertedAmount;
            Console.WriteLine("Om ränta är " + IntrestRate + " kommer du att få en årlig summa på:" + YearlyAmount);
            return (float)InsertedAmount; 

        }

        public void Loan()
        {
            Console.WriteLine("I vilken valuta Svenska kronor: SEK | US dollar: USD | Brittisk pund: GBP | Euro: EUR ");
            Console.Write("Välj valuta: ");
            bool isException = true;
            string chooseCurrency = "";
            while (isException)
            {
                try
                {
                    chooseCurrency = Console.ReadLine().ToUpper();
                    Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltig valuta, vänligen skriv in en ny: ");
                    isException = true;
                }
            }
            float Moneylimit = 0;
            foreach (var item in ListOfAccounts)
            {
                Moneylimit += item._Balance;
            }
            decimal MoneyLimit2 = Convert.ToDecimal(Moneylimit);
            Console.WriteLine("Totalt kan man låna fem gånger så mycket pengar som man själv äger (summan av alla ens kontons saldon).");
            Console.Write("Skriv in hur mycket du vill låna: ");
            decimal BorrowAmount = 0;
            isException = true;
            while (isException)
            {
                try
                {
                    BorrowAmount = Convert.ToDecimal(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.Write("Ogiltigt format! Vänligen välj nytt belopp: ");
                    isException = true;
                }
            }
            
            MoneyLimit2 = MoneyLimit2*5;
            while (BorrowAmount > MoneyLimit2)
            {
                Console.WriteLine("Du har för lite pengar för att låna så mycket");
                Console.Write("Skriv in et nytyt belopp på hur mycket du vill låna: ");
                BorrowAmount = Convert.ToDecimal(Console.ReadLine());
            }

            decimal LoanintrestRate = 0.10M;
            decimal YearlyIntrest = BorrowAmount * LoanintrestRate;
            Console.WriteLine("Kostnaden på lånet blir {0} {1} per år, vid en ränta på {2}%.", YearlyIntrest, chooseCurrency, LoanintrestRate*100);
            Console.ReadKey();
        }
        public void ChangePassword()
        {
            Console.Write("Ange ett nytt Lösenord: ");

            string passwordCreated = Console.ReadLine();

            while(!passwordCreated.Any(char.IsLetter) || !passwordCreated.Any(char.IsNumber))
            {
                Console.WriteLine("Ditt lösenord måste innehålla både siffror och bokstäver");
                Console.Write("Var god ange ett nytt lösenord: ");
                passwordCreated = Console.ReadLine();
            }
           
            while (passwordCreated.Length < 8)
            {
                Console.WriteLine("Lösenordet var för kort, det måste innehålla minst 8 tecken.");
                Console.Write("Var god ange ett nytt lösenord: ");
                passwordCreated = Console.ReadLine();
            }
            password = passwordCreated;
        }
    }
}