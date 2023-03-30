using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boolean.CSharp.Main.Enum;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {

        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; } 
        public decimal OldBalance { get; set; }

    }
}
