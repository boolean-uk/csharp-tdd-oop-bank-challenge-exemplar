using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete.Accounts
{
    public class SavingsAccount : Account
    {
        private Customer _customer;

        public SavingsAccount(Customer customer)
        {
            _customer = customer;
        }

    }
}
