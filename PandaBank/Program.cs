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
        private static void SignInMetod()
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
                case 1: Console.WriteLine();
                        Accounts A = new Accounts("Spar", 17698);
                        Accounts A1 = new Accounts("Lön Konto",4586);
                      
                        Customer C = new Customer();
                        C.AddAccounts(A);
                        C.AddAccounts(A1);
                        C.ShoweAccounts(); 
                        Console.ReadKey();
                    ; break;
                default: Console.WriteLine("Var snäll och välj ett giltigt alternativ!"); break;
            }
            }
        }
        private static void LoginUs()
        {
            LoginUser Ad = new LoginUser() { userName = "Admin", password = "1234" };
            LoginUser U1 = new LoginUser() { userName = "Hanna", password = "0000" };
            LoginUser U2 = new LoginUser() { userName = "Daniel", password = "1111" };

            List<LoginUser> ListUser = new List<LoginUser>();
            ListUser.Add(Ad);
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
                    LoginUser result1 = ListUser.Find(p => p.password == userPass);
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
                        SignInMetod();
                    }
                }
            }
        }
    }
}
