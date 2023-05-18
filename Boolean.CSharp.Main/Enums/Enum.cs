using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Enums
{
   
        public enum TransactionType
        {
            Credit,
            Debit
        }
        public enum TransactionStatus
        {
            Pending,
            Approved,
            Rejected
        }
        public enum Branches
        {
            Bournemouth,
            Athens,
            London,
            Paris,
            Cologne,
            Stockholm,
            Lisbon,
            Amsterdam
        }
        public enum OverdraftStatus
        {
            Pending,
            Approved,
            Rejected
        }

    
}
