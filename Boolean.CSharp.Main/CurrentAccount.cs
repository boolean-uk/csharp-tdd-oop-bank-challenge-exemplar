using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account, IAccount
    {
        private decimal _bankBalance;
        //private decimal _bankBalance;
        private List<Transaction> _transactions;
        private Customer _customer;
        
        public CurrentAccount(Customer customer)
        {
            _bankBalance = 0M;
            _transactions = new List<Transaction>();
            _customer = customer;

        }

       
        /// <summary>
        /// Method to withdrawal on a given date
        /// </summary>
        /// <param name="amount">decimal amount to withdraw</param>
        /// <param name="when"></param>
        /// <returns></returns>
        public decimal Withdraw(decimal amount, DateTime when)
        {
            decimal oldBalance = _bankBalance;
            _bankBalance = _bankBalance - amount;

            _transactions.Add(new Transaction()
            {
                Amount = amount,
                Date = when,
                Id = _transactions.Count + 1,
                Type = Enum.TransactionType.Debit,
                Balance = _bankBalance,
                OldBalance = oldBalance

            });
            return _bankBalance;
        }
      
        /// <summary>
        /// Deposit an amount on a given day
        /// </summary>
        /// <param name="amount">amount to deposit</param>
        /// <param name="when">date when deposit happened</param>
        /// <returns></returns>
        public decimal Deposit(decimal amount, DateTime when)
        {
            decimal oldBalance = _bankBalance;
            _bankBalance = _bankBalance + amount;

            _transactions.Add(new Transaction()
            {
                Amount = amount,
                Date = when,
                Id = _transactions.Count + 1,
                Type = Enum.TransactionType.Credit,
                Balance = _bankBalance,
                OldBalance = oldBalance

            });
            return _bankBalance;
        }
        /// <summary>
        /// Method outputs a statement to the console
        /// </summary>
        public void WriteStatement()
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ","Date","Credit","Debit","Balance");
            foreach (Transaction transaction in _transactions.OrderByDescending(t => t.Date))
            {
                
                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", 
                        transaction.Date.ToShortDateString(),
                        transaction.Type==Enum.TransactionType.Credit ? transaction.Amount : 0,
                        transaction.Type == Enum.TransactionType.Debit ? transaction.Amount : 0,
                        transaction.Balance);
            };
        }
        /// <summary>
        /// property to get Bank Balance
        /// </summary>
        public decimal BankBalance { get { return _bankBalance; } }
       
    }
}
