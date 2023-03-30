using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Boolean.CSharp.Main.Concrete
{
    public abstract class Account
    {
        public Guid Id { get; set; }
        private List<BankTransaction> _transactions;
        private List<OverdraftRequest> _overdraftRequests;
        

        public Branches Branch { get; set; }
        
        public Account()
        {
            this.Id = Guid.NewGuid();
            _transactions = new List<BankTransaction>();
            _overdraftRequests = new List<OverdraftRequest>();  
        }

        /// <summary>
        /// Method outputs a statement to the console
        /// </summary>
        public void WriteStatement()
        {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Credit", "Debit", "Balance");
            foreach (IBankTransaction transaction in _transactions.OrderByDescending(t => t.Date))
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                        transaction.Date.ToShortDateString(),
                        transaction.Type == TransactionType.Credit ? transaction.Amount : 0,
                        transaction.Type == TransactionType.Debit ? transaction.Amount : 0,
                        transaction.NewBalance);
            };
        }
        public void PhoneStatements()
        {
            SpeechSynthesizer speaker = new SpeechSynthesizer();
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"your statement is as follows ");
            foreach (IBankTransaction transaction in _transactions.OrderByDescending(t => t.Date))
            {

                sb.Append($"on {transaction.Date.ToShortDateString()} there was a {transaction.Type} of {transaction.Amount}");

                
            };
            sb.Append($"as at {DateTime.Now.ToShortTimeString()} your balance is {this.Balance()}");
            speaker.Speak(sb.ToString());
        }
        /// <summary>
        /// Method to withdrawal on a given date
        /// </summary>
        /// <param name="amount">decimal amount to withdraw</param>
        /// <param name="when"></param>
        /// <returns></returns>
        public decimal Withdraw(decimal amount, DateTime when)
        {
            decimal oldBalance = Balance();           

            _transactions.Add(new BankTransaction()
            {
                Amount = amount,
                Date = when,
                Id = _transactions.Count + 1,
                Type = TransactionType.Debit,
                NewBalance = oldBalance - amount,
                OldBalance = oldBalance

            });
            return oldBalance - amount;
        }

        /// <summary>
        /// Deposit an amount on a given day
        /// </summary>
        /// <param name="amount">amount to deposit</param>
        /// <param name="when">date when deposit happened</param>
        /// <returns></returns>
        public decimal Deposit(decimal amount, DateTime when)
        {
            decimal oldBalance = Balance();            

            _transactions.Add(new BankTransaction()
            {
                Amount = amount,
                Date = when,
                Id = _transactions.Count + 1,
                Type = TransactionType.Credit,
                NewBalance = oldBalance + amount,
                OldBalance = oldBalance

            });
            return oldBalance + amount;
        }
        public decimal Balance()
        {
            decimal balance = 0;


            foreach (IBankTransaction transaction in _transactions.Where(t => t.Type==TransactionType.Credit))
            {

                balance += transaction.Amount;
               
            };
            foreach (IBankTransaction transaction in _transactions.Where(t => t.Type == TransactionType.Debit))
            {

                balance -= transaction.Amount;

            };

            return balance;


        }
        public void RequestOverdraft(OverdraftRequest request)
        {


            _overdraftRequests.Add(request);
            
        }
        public void ApproveOverdraft(int id)
        {
            var item = _overdraftRequests.Where(r => r.Id == id).FirstOrDefault();
            if(item != null)
            {
                item.Status = OverdraftStatus.Approved;
            }
        }

        public decimal OverdraftAmount()
        {
            IOverdraftRequest? latestApproved = _overdraftRequests.OrderByDescending(o => o.RequestDate).Where(o => o.Status==OverdraftStatus.Approved).FirstOrDefault();

            return latestApproved==null ? 0 : latestApproved.Amount;
        }
        public int OverdraftRequests()
        {
            return _overdraftRequests.Count();
        }
    }
}
