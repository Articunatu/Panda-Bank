using System;
using System.Collections.Generic;

namespace PandaBank
{
    class LoginUser
    {
        public string userName { get; set; }
        public string password { get; set; }

        private string _userName;
        private string _password;
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }

        public List<Customer> ListOfCustomers = new List<Customer>();
    }
}
