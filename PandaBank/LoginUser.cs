using System;
using System.Collections.Generic;


namespace PandaBank
{
    class LoginUser
    {
        public string userName { get; set; }
        public string password { get; set; }

        public decimal[] currencyChange = new decimal[] { 1.00M, 0.11025802M, 0.083344351M, 0.097629977M };
    }
}
