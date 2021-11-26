using System;
using System.Collections.Generic;
using System.Text;

namespace PandaBank
{
    class Customer
    {
        public List<Accounts> ListOfAccounts = new List<Accounts>();

        public void AddAccounts(Accounts _Account)
        {
            ListOfAccounts.Add(_Account);
        }
        public void ShoweAccounts()
        {
            foreach (var item in ListOfAccounts)
            {
                item.PrintInfo();
            }
        }
    }
}
