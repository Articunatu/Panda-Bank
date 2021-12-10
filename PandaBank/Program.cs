using System;
using System.Collections.Generic;

namespace PandaBank
{
    class Program
    {
        static void Main()
        {
            BankController bank = new BankController();
            bank.Start();
        }
    }
}
