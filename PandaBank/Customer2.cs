using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaBank
{
    partial class Customer : LoginUser
    {
        List<string> Transactions = new List<string>();

        public void SaveTranscation(float moneyAmount, Accounts transferAccount, bool plusOrMinus, string changedTransfer)
        {
            Transcation savedTransaction = new Transcation
            {
                TimeOfTransfer = DateTime.Now,
                PlusOrMinus = plusOrMinus,
                TransferAccount = transferAccount,
                MoneyAmount = moneyAmount,
                ChangedTransfer = changedTransfer,
                User = this
            };
            BankController.queuedTransactions.Enqueue(savedTransaction);
        }

        public void SaveCalculations(float sendAmount, float recieveAmount, Accounts fromAccount, Accounts toAccount)
        {
            Calculation savedCalculation = new Calculation
            {
                RecieveAmount = recieveAmount,
                SendAmount = sendAmount,
                SendAccount = fromAccount,
                RecieveAccount = toAccount
            };
            BankController.queuedCalculations.Enqueue(savedCalculation);
        }

        public void ListTransaction(Transcation transcation )
        {
            string savedTransfer = transcation.SavedTransfer();
            Transactions.Add(savedTransfer);
        }

        public void ShowTransactions()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
            if (Transactions.Count == 0)
            {
                Console.WriteLine("Inga transaktioner ännu genomförts");
            }
        }

        [Obsolete("Use the normal CreateAccount method instead!", true)]
        public void CreateSavingsAccount()
        {
            Console.Write("Namnge sparkonto: ");
            string accountName = Console.ReadLine();
            float accountAm = 0;
            Console.WriteLine("Svenska krona: kr | US dollar: dollar | Brittisk pund: pund | Euro: euro ");
            Console.Write("Välj valuta: ");
            string chooseCurrency = Console.ReadLine();
            Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);
            Accounts createAccounts = new Accounts(accountName, accountAm, chooseCurrency);
            createAccounts.IsSavings = true;
            ListOfAccounts.Add(createAccounts);
            Console.WriteLine(createAccounts._Name + " " + createAccounts._Balance + " " + createAccounts._Currency);
        }

        public void DepositMoney()
        {
            ShoweAccounts();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj ett konto att sätta in pengar på: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string depositText = Console.ReadLine();
            Accounts depositAccount = ListOfAccounts.Find(s => s._Name == depositText);
            while (depositAccount == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                depositText = Console.ReadLine();
                depositAccount = ListOfAccounts.Find(s => s._Name == depositText);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Skriv hur mycket pengar du vill sätta in: ");
            float moneyAmount = 0;
            bool isException = false;
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

            if (depositAccount.IsSavings == true)
            {
                decimal IntrestRate = 0.01M;
                decimal YearlyAmount = IntrestRate * (decimal)moneyAmount;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Om räntan är " + IntrestRate*100 + "% kommer du att få en årlig bonus på: " + Math.Round(YearlyAmount, 2));
            }

            SaveCalculations(moneyAmount, 0, null, depositAccount);
            SaveTranscation(moneyAmount, depositAccount, true, "Insättning på bankomat\t\t");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Uppdatering går igenom om 15 sekunder!");
        }

        public void WithdrawMoney()
        {
            ShoweAccounts();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj ett konto att ta ut pengar ifrån: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string withdrawText = Console.ReadLine();
            Accounts withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
            while (withdrawAccount == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ogiltigt konto! Vänligen skriv in ett nytt: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                withdrawText = Console.ReadLine();
                withdrawAccount = ListOfAccounts.Find(s => s._Name == withdrawText);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Skriv hur mycket pengar vill du ta ut: ");
            float moneyAmount = 0;
            bool isException = false;
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

            SaveCalculations(moneyAmount, 0, withdrawAccount, null);
            SaveTranscation(moneyAmount, withdrawAccount, false, "Uttag från bankomat\t\t");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Uppdatering går igenom om 15 sekunder!");
        }

        public float IntrestAmount(Accounts savAcc)
        {
            bool isException;
            decimal IntrestRate = 0.01M;
            decimal InsertedAmount = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Skriv hur mycket vill du sätta in: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    InsertedAmount = Convert.ToDecimal(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ogiltigt format! Vänligen skriv in ett nytt belopp: ");
                    isException = true;
                }

            } while (isException);
            
            decimal YearlyAmount = IntrestRate * InsertedAmount;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Om räntan är " + IntrestRate*100 + "% kommer du att få en årlig bonus på: " + Math.Round(YearlyAmount, 2) + savAcc._Currency);
            return (float)InsertedAmount; 
        }

        public void Loan()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Här kan du få reda på hur många procent ränta du får på ett lån från Pandabanken.");
            Console.WriteLine("Valbara valutor:  Svenska kronor: SEK | US dollar: USD | Brittisk pund: GBP | Euro: EUR ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Välj valuta: ");
            bool isException = true;
            string chooseCurrency = "";
            while (isException)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    chooseCurrency = Console.ReadLine().ToUpper();
                    Currency currencyEnum = (Currency)Enum.Parse(typeof(Currency), chooseCurrency);
                    isException = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ogiltig valuta, vänligen skriv in en ny: ");
                    isException = true;
                }
            }
            float Moneylimit = 0;
            foreach (var item in ListOfAccounts)
            {
                Moneylimit += item._Balance;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            decimal MoneyLimit2 = Convert.ToDecimal(Moneylimit);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Totalt kan man låna fem gånger så mycket pengar som man själv äger (summan av alla ens kontons saldon).");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Skriv in hur mycket du vill låna: ");
            decimal BorrowAmount = 0;
            isException = true;
            while (isException)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    BorrowAmount = Convert.ToDecimal(Console.ReadLine());
                    isException = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ogiltigt format! Vänligen välj nytt belopp: ");
                    isException = true;
                }
            }
            
            MoneyLimit2 *= 5;
            while (BorrowAmount > MoneyLimit2)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Du har för lite pengar för att låna så mycket");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Skriv in et nytyt belopp på hur mycket du vill låna: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                BorrowAmount = Convert.ToDecimal(Console.ReadLine());
            }

            decimal LoanintrestRate = 0.10M;
            decimal YearlyIntrest = BorrowAmount * LoanintrestRate;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Kostnaden på lånet blir {0} {1} per år, vid en ränta på {2}%.", YearlyIntrest, chooseCurrency, LoanintrestRate*100);
            Console.ReadKey();
        }

        public void ChangePassword()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Ditt lösenord måste innehålla både siffror och bokstäver, samt innehålla minst 8 tecken ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ange ett nytt Lösenord: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string passwordCreated = Console.ReadLine();

            while(!passwordCreated.Any(char.IsLetter) || !passwordCreated.Any(char.IsNumber))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Ditt lösenord måste innehålla både siffror och bokstäver");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Var god ange ett nytt lösenord: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                passwordCreated = Console.ReadLine();
            }
           
            while (passwordCreated.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Lösenordet var för kort, det måste innehålla minst 8 tecken.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Var god ange ett nytt lösenord: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                passwordCreated = Console.ReadLine();
            }
            Password = passwordCreated;
        }
    }
}