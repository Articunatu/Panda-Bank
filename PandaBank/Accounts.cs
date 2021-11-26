using System;
using System.Collections.Generic;
using System.Text;

namespace PandaBank
{
    public class Accounts
    {
        public string _Name;
        public float _Balance;


        public Accounts(string Name, float Balance)
        {
            _Name = Name;
            _Balance = Balance;
        }


        public void PrintInfo()
        {
            Console.WriteLine(_Name +" "+ _Balance);
        }

        //Customer C1 = new Customer();
        //Accounts A1 = new Accounts();
        //C1.AddAccounts(A1);
            
        //    Accounts A2 = new Accounts();
        //A2._Name = "Test";
        //    A2._Balance = 6748236;
        //    C1.AddAccounts(A2);
        //    C1.ShoweAccounts();

    }
}
