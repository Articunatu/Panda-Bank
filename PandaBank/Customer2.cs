using System;
using System.Collections.Generic;

namespace PandaBank
{
    partial class Customer : LoginUser
    {
        List<string> Transactions = new List<string>();

        public void SaveTranscation(float transaction, Accounts transferAccount, bool plusOrMinus)
        {
            char mathSign = plusOrMinus ? '+' : '-';
            string savedTransfer = $"Ändrat bankkonto: {transferAccount._Name} Ändrad summa: {mathSign}{transaction}";
            Transactions.Add(savedTransfer);
        }
        public void SaveTranscation2(float transaction, Accounts transferAccount, bool plusOrMinus)
        {
            char mathSign = plusOrMinus ? '+' : '-';
            string savedTransfer = $"Ändrat bankkonto: {transferAccount._Name} Ändrad summa: {mathSign}{transaction}";
            Transactions.Add(savedTransfer);
        }


        public void ShowTransactions()
        {
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}