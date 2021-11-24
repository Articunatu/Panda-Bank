using System;

namespace PandaBank
{
    class Program
    {
        static void Main()
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
            Console.WriteLine("[7] Log out");
            Console.Write("");
            Int32.TryParse(Console.ReadLine(), out money);
            Console.WriteLine();

            switch (money)
            {
                case 1: Console.WriteLine(); break; 
                default: break;
            }
        }
    }
}
