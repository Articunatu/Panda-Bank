using System;
using System.Collections.Generic;
using System.Text;

namespace PandaBank
{
    class Admin : LoginUser
    {    
        public void CreateCustomer()
        {
            string nameCreated = Console.ReadLine();
            string passwordCreated = Console.ReadLine();
            Customer createdCustomer = new Customer(nameCreated, passwordCreated);
            ListOfCustomers.Add(createdCustomer);
            
            Console.WriteLine(createdCustomer.userName + " " + createdCustomer.password);
        }
    }
    //    public object A()

    //{
    //    LoginUser Ad = new LoginUser() { userName = "Admin", password = "1234" };
    //    LoginUser U1 = new LoginUser() { userName = "Hanna", password = "0000" };
    //    LoginUser U2 = new LoginUser() { userName = "Daniel", password = "1111" };

    //    List<LoginUser> ListUser = new List<LoginUser>();
    //    ListUser.Add(Ad);
    //    ListUser.Add(U1);
    //    ListUser.Add(U2);
    //    return ListUser;
    //}


    //public Customer AddCustomer(List<Accounts> _ListofAccounts, string _userName, string _password)
    //{

    //    userName = _userName;
    //    password = _password;
    //    ListOfAccounts = _ListofAccounts;
    //}
}
