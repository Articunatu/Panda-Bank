using System;
using System.Collections.Generic;
using System.Text;

namespace PandaBank
{
    class Admin : LoginUser
    {
        LoginUser Ad = new Customer("Admin", "1234");
        Customer U1 = new Customer("Hanna", "0000");
        Customer U2 = new Customer("Daniel", "1111");
        Customer U3 = new Customer("Emma", "2222");

        Accounts a1 = new Accounts("Spar", 44000, "SEK");
        Accounts a2 = new Accounts("Lön", 22998, "SEK");
        Accounts a3 = new Accounts("Fond", 33711, "SEK");
        Accounts a4 = new Accounts("Aktie", 11000, "SEK");
        Accounts a5 = new Accounts("Privat", 5500, "SEK");
        Accounts a6 = new Accounts("Investeringar", 99999, "SEK");

        public void AdminSetup()
        {
            U1.AddAccounts(a1); U1.AddAccounts(a2);  //First user's accounts
            U2.AddAccounts(a3); U2.AddAccounts(a4);  //Second user's account
            U3.AddAccounts(a5); U3.AddAccounts(a6);
            ListOfCustomers.Add(U1);
            ListOfCustomers.Add(U2);
            ListOfCustomers.Add(U3);
        }

        public void ShowCustomers()
        {
            
            foreach (var customer in ListOfCustomers)
            {
                Console.WriteLine("Användare: " + customer.userName + ", Antal konton: " + customer.ListOfAccounts.Count);
            }
        }
        
        public void CreateCustomer()
        {
            Console.Write("Ange Användarnamnet på den nya användaren: ");
            string nameCreated = Console.ReadLine();
            Console.Write("Ange ett Lösenordet till den nya användaren: ");
            string passwordCreated = Console.ReadLine();
            Customer createdCustomer = new Customer(nameCreated, passwordCreated);
            ListOfCustomers.Add(createdCustomer);
            
            Console.WriteLine("Du har lagt till följande användare: "+createdCustomer.userName +"\nMed lösenordet: " + createdCustomer.password);
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
