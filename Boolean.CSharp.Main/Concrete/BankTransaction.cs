using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Concrete
{
    public class BankTransaction
    {

        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal NewBalance { get; set; }
        public decimal OldBalance { get; set; }

    }
}
