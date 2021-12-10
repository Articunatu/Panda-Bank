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

        
        public decimal[] currencyChange = new decimal[] { 1.00M, 0.11025802M, 0.083344351M, 0.097629977M };

        //private decimal[] currencyChange = new decimal[] { 1.00M, 0.11025802M, 0.083344351M, 0.097629977M };
        //public decimal[] CurrencyChange
        //{
        //    get { return currencyChange; }
        //    set { currencyChange = value; }
        //}

    }
}
