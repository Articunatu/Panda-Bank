using System;
using System.Collections.Generic;

namespace PandaBank
{
    class Program
    {
        static void Main()
        {
            LoginUs();
        }

        private static void LoginUs()
        {
            LoginUser Ad = new Customer("Admin", "1234");
            Customer U1 = new Customer("Hanna", "0000");
            Customer U2 = new Customer("Daniel", "1111");

            List<LoginUser> ListUser = new List<LoginUser>();
            Accounts a1 = new Accounts("Spar", 44000);
            Accounts a2 = new Accounts("Lön", 22998);
            Accounts a3 = new Accounts("Fond", 33711);
            U1.AddAccounts(a1); U1.AddAccounts(a2); //First user's accounts
            U2.AddAccounts(a3);       //Second user's account
            ListUser.Add(U1);
            ListUser.Add(U2);

            bool logintry = true;
            while (logintry)
            {
                for (int i = 0; i <= 2; i++)
                {
                    Console.Write("Användarnamn: ");
                    string userAnswer = Console.ReadLine();
                    Console.Write("Lösenord: ");
                    string userPass = Console.ReadLine();

                    LoginUser result = ListUser.Find(a => a.userName == userAnswer);
                    LoginUser result1 = ListUser.Find(p => result.password == userPass);
                    if (result == null || result1 == null)
                    {
                        Console.WriteLine("Fel användarnamn eller lösenord");
                        if (i == 2)
                        {
                            Console.WriteLine("Du har nått maxgräns försök!");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Customer resultCust = (Customer)result;
                        SignInMetod(resultCust);
                    }
                }
            }
        }

        private static void SignInMetod(Customer loginUser)
        {
            bool Online = true;
            while (Online)
            {
                Console.WriteLine();
                Console.WriteLine("PandaBanken");
                int money;
                Console.WriteLine("[1] Visa Konton");
                Console.WriteLine("[2] Överför Pengar Mellan Konton");
                Console.WriteLine("[3] Överför Pengar Till Andra Användare");
                Console.WriteLine("[4] Skapa Konto");
                Console.WriteLine("[5] Sätt In Pengar");
                Console.WriteLine("[6] Ta Ut Pengar");
                Console.WriteLine("[7] Låna Pengar");
                Console.WriteLine("[8] Logga Ut");
                Console.Write("");
                Int32.TryParse(Console.ReadLine(), out money);
                Console.WriteLine();

                switch (money)
                {
                    case 1:
                        loginUser.ShoweAccounts();

                        Console.ReadKey();
                        break;
                    default: Console.WriteLine("Var snäll och välj ett giltigt alternativ!"); break;
                }
            }
        }
    }
}
