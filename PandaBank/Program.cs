using System;
using System.Collections.Generic;

namespace PandaBank
{
    class Program
    {
        static void Main()
        {
            Start();
        }

        static void Start()
        {
            Admin a = new Admin();
            a.AdminSetup();
            List<Customer> ListOfCustomers = a.ListOfCustomers;
            LoginUs(a, ListOfCustomers);
        }

        private static void LoginUs(Admin a, List<Customer> ListOfCustomers)
        {
            bool logintry = true;
            while (logintry)
            {
                for (int i = 0; i <= 2; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Användarnamn: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string userAnswer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Lösenord: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string userPass = Console.ReadLine();

                    if (userAnswer == "Admin" || userPass == "3.14")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Välkommen Admin, vad vill du göra?");
                        SignInAdmin(a, ListOfCustomers);
                        break;
                    }

                    LoginUser result = ListOfCustomers.Find(result => result.userName == userAnswer);
                    LoginUser result1 = ListOfCustomers.Find(result => result.password == userPass);
                    if (result == null || result1 == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Fel användarnamn eller lösenord, skriv in ett nytt:");
                        if (i == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Du har nått maxgräns försök!");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Customer resultCust = (Customer)result;
                        SignInMetod(a, resultCust, ListOfCustomers);
                    }
                }
            }
        }

        private static void SignInMetod(Admin a, Customer loginUser, List<Customer> customers)
        {
            bool Online = true;
            while (Online)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("PandaBanken");
                int money;
                Console.WriteLine("[1] Visa Konton");
                Console.WriteLine("[2] Överför Pengar Mellan Konton");
                Console.WriteLine("[3] Överför Pengar Till Andra Användare");
                Console.WriteLine("[4] Skapa Konto");
                Console.WriteLine("[5] Sätt In Pengar");
                Console.WriteLine("[6] Ta Ut Pengar");
                Console.WriteLine("[7] Låna Pengar");
                Console.WriteLine("[8] Visa transaktioner");
                Console.WriteLine("[9] Logga Ut");
                Console.Write("");
                Int32.TryParse(Console.ReadLine(), out money);
                Console.WriteLine();

                switch (money)
                {
                    case 1:
                        loginUser.ShoweAccounts();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        loginUser.ShoweAccounts();
                        loginUser.TransferAccounts();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        loginUser.TransferMoneyToUser(customers);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        loginUser.CreateAccount();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        loginUser.DepositMoney();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        loginUser.WithdrawMoney();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        loginUser.Loan();
                        Console.Clear();
                        break;
                    case 8:
                        loginUser.ShowTransactions();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 9:
                        Console.Clear();
                        LoginUs(a, customers);
                        break;
                    default: Console.WriteLine("Var snäll och välj ett giltigt alternativ!"); break;
                }
            }
        }

        private static void SignInAdmin(Admin a, List<Customer> customers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[1] Se en lista över alla användare");
            Console.WriteLine("[2] Skapa en nya användare");
            Console.WriteLine("[3] Överför Pengar Till Andra Användare");
            Console.WriteLine("[4] Logga ut.");
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    a.ShowCustomers();
                    Console.ReadKey();
                    Console.Clear();
                    SignInAdmin(a,customers);
                    break;
                case 2:
                    a.CreateCustomer();
                    Console.Clear();
                    SignInAdmin(a, customers);
                    break;
                case 3:
                    LoginUs(a, customers);
                    Console.Clear();
                    SignInAdmin(a, customers);
                    break;
                case 4:
                    Console.Clear();
                    LoginUs(a, customers);
                    break;
                default:
                    Console.WriteLine("Var snäll och välj ett giltigt alternativ!");
                    SignInAdmin(a, customers);
                    break;
            }
        }
    }
}
