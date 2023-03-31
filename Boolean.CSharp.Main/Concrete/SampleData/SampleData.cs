using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete.SampleData
{
    public class SampleData
    {
        private List<BankTransaction> _transactions;
        public SampleData()
        {
            _transactions = new List<BankTransaction>();
            SeedTransactionData();



        }

        private void SeedTransactionData()
        {
            BankTransaction t1 = new BankTransaction()
            {
                Amount = 1000.00M,
                Date = new DateTime(2012, 1, 10),
                Type = Enums.TransactionType.Credit,
                Status = Enums.TransactionStatus.Pending

            };
            BankTransaction t2 = new BankTransaction()
            {
                Amount = 2000.00M,
                Date = new DateTime(2012, 1, 13),
                Type = Enums.TransactionType.Credit,
                Status = Enums.TransactionStatus.Pending
            };
            BankTransaction t3 = new BankTransaction()
            {
                Amount = 500.00M,
                Date = new DateTime(2012, 1, 14),
                Type = Enums.TransactionType.Debit,
                Status = Enums.TransactionStatus.Pending
            };
            BankTransaction t4 = new BankTransaction()
            {
                Amount = 50000.00M,
                Date = new DateTime(2012, 1, 14),
                Type = Enums.TransactionType.Debit,
                Status = Enums.TransactionStatus.Pending
            };
            _transactions.Add(t1);
            _transactions.Add(t2);
            _transactions.Add(t3);
            _transactions.Add(t4);
        }

        public List<BankTransaction> BankTransactions { get { return _transactions; } }

    }
}
