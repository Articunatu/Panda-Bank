using System;
using System.Collections.Generic;

namespace PandaBank
{
    class LoginUser
    {
        public string userName { get; set; }
        public string password { get; set; }

        public List<Customer> ListOfCustomers = new List<Customer>();
    }
}
