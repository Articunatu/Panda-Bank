using System;
using System.Collections.Generic;
using System.Text;

namespace PandaBank
{
    public class SavingsAccount 
    {
        public void IntrestAmount()
        {
            decimal IntrestRate = 0.01M;
            Console.Write("Skriv hur mycket vill du sätta in:");
            decimal InsertedAmount = Convert.ToDecimal(Console.ReadLine());
            decimal YearlyAmount = IntrestRate * InsertedAmount;
            Console.WriteLine("Om ränta är "+IntrestRate+" kommer du att få en årlig summa på:"+ YearlyAmount);
        }

    }
}
