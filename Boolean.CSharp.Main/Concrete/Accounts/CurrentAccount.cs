using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main.Concrete.Accounts
{
    public class CurrentAccount : Account
    {


        private Customer _customer;

        public CurrentAccount(Customer customer)
        {            
            _customer = customer;
        }


        public Customer Customer => _customer;


    }
}
