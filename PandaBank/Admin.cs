using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaBank
{
    class Admin : LoginUser
    {
        #region Customers & BankAccounts
        Customer U1 = new Customer("Hanna", "0000");
        Customer U2 = new Customer("Daniel", "1111");
        Customer U3 = new Customer("Emma", "2222");

        Accounts a1 = new Accounts("Spar", 50000.00f, "SEK");
        Accounts a2 = new Accounts("Lön", 20000f, "EUR");
        Accounts a3 = new Accounts("Fond", 30000.00f, "SEK");
        Accounts a4 = new Accounts("Aktie", 10000.00f, "SEK");
        Accounts a5 = new Accounts("Privat", 4000.66f, "SEK");
        Accounts a6 = new Accounts("Investeringar", 99999.02f, "SEK");
        #endregion

        public List<Customer> ListOfCustomers = new List<Customer>();

        public void AdminSetup()
        {
            U1.AddAccounts(a1); U1.AddAccounts(a2);  //First user's accounts
            U2.AddAccounts(a3); U2.AddAccounts(a4);  //Second user's account
            U3.AddAccounts(a5); U3.AddAccounts(a6);
            ListOfCustomers.Add(U1);
            ListOfCustomers.Add(U2);
            ListOfCustomers.Add(U3);
        }

        public void ShowCustomers()
        {
            foreach (var customer in ListOfCustomers)
            {
                Console.WriteLine("Användare: " + customer.UserName + ", Antal konton: " + customer.ListOfAccounts.Count);
            }
        }

        public void CreateCustomer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ange Användarnamnet på den nya användaren: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string nameCreated = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Lösenordet måste innehålla både siffror och bokstäver samt innehålla minst 8 tecken ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ange ett Lösenordet till den nya användaren: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string passwordCreated = Console.ReadLine();

            while (!passwordCreated.Any(char.IsLetter) || !passwordCreated.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ditt lösenord måste innehålla både siffror och bokstäver");
                Console.Write("Var god ange ett nytt lösenord: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                passwordCreated = Console.ReadLine();
            }
            while (passwordCreated.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Lösenordet var för kort, det måste innehålla minst 8 tecken.");
                Console.Write("Var god ange ett nytt lösenord: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                passwordCreated = Console.ReadLine();
            }
            Customer createdCustomer = new Customer(nameCreated, passwordCreated);
            ListOfCustomers.Add(createdCustomer);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Du har lagt till följande användare: " + createdCustomer.UserName + "\nMed lösenordet: " + createdCustomer.Password);
        }

        public void UpdateCurrency()
        {
            bool myBool = true;
            while (myBool)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Nuvarande värde på valutan:");
                Console.WriteLine(Customer.Currency.SEK + " " + currencyChange[0]);
                Console.WriteLine(Customer.Currency.USD + " " + currencyChange[1]);
                Console.WriteLine(Customer.Currency.GBP + " " + currencyChange[2]);
                Console.WriteLine(Customer.Currency.EUR + " " + currencyChange[3]);
                Console.WriteLine();
                Console.WriteLine("Välj valuta som du vill ändra värdet på! \nSvenska krona: SEK | US dollar: USD | Brittisk pund: GBP | Euro: EUR" +
                    "\nFör att avsluta, vänligen skriv X");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Valuta: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string changeValue = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.Green;
                switch (changeValue)
                {
                    
                    case "SEK":
                        Console.Write("Vad är det nya värdet? ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string chooseNewValue = Console.ReadLine();
                        decimal deciValue = Convert.ToDecimal(chooseNewValue);
                        currencyChange[0] = deciValue;
                        Console.WriteLine();
                        break;
                    case "USD":
                        Console.Write("Vad är det nya värdet? ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string chooseNewValue1 = Console.ReadLine();
                        decimal deciValue1 = Convert.ToDecimal(chooseNewValue1);
                        currencyChange[1] = deciValue1;
                        Console.WriteLine();
                        break;
                    case "GBP":
                        Console.Write("Vad är det nya värdet? ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string chooseNewValue2 = Console.ReadLine();
                        decimal deciValue2 = Convert.ToDecimal(chooseNewValue2);
                        currencyChange[2] = deciValue2;
                        Console.WriteLine();
                        break;
                    case "EUR":
                        Console.Write("Vad är det nya värdet? ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string chooseNewValue3 = Console.ReadLine();
                        decimal deciValue3 = Convert.ToDecimal(chooseNewValue3);
                        currencyChange[3] = deciValue3;
                        Console.WriteLine();
                        break;
                    case "X":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Ny värde på valutor:");
                        Console.WriteLine(Customer.Currency.SEK + " " + currencyChange[0]);
                        Console.WriteLine(Customer.Currency.USD + " " + currencyChange[1]);
                        Console.WriteLine(Customer.Currency.GBP + " " + currencyChange[2]);
                        Console.WriteLine(Customer.Currency.EUR + " " + currencyChange[3]);
                        myBool = false;
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Vänligen välj giltig valuta!");
                        break;
                }
            }

        }
    }
}