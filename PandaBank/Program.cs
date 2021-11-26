using System;
using System.Collections.Generic;

namespace PandaBank
{
    class Program
    {
        static void Main()
        {
            //Login L = new Login();
            //L._loginUs();
            LoginUs();

        }

        private static void SignInMetod()
        {

            Console.WriteLine(" ");
            int money;
            Console.WriteLine("[1] Show Accounts");
            Console.WriteLine("[2] Tranfer Money between accounts");
            Console.WriteLine("[3] Tranfer Money between users");
            Console.WriteLine("[4] Create Account");
            Console.WriteLine("[5] Deposit Money");
            Console.WriteLine("[6] Withdraw Money");
            Console.WriteLine("[7] Borrow Money");
            Console.WriteLine("[8] Log out");
            Console.Write("");
            Int32.TryParse(Console.ReadLine(), out money);
            Console.WriteLine();

            switch (money)
            {
                case 1: Console.WriteLine(); break;
                default: break;
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
