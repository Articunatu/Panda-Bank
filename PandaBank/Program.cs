using System;

namespace PandaBank
{
    struct Program
    {
        static void Main()
        {
            BankController bank = new BankController();
            bank.Start();
        }
    }
}