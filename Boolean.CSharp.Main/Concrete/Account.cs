using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System.Speech.Synthesis;
using System.Text;


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
            foreach (IBankTransaction transaction in _transactions.OrderByDescending(t => t.Date).Where(t => t.Status == TransactionStatus.Approved))
            {

                Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ",
                        transaction.Date.ToShortDateString(),
                        transaction.Type == TransactionType.Credit ? transaction.Amount : 0,
                        transaction.Type == TransactionType.Debit ? transaction.Amount : 0,
                        transaction.NewBalance);
            };
        }
        /// <summary>
        /// Method to generate phrase to read from the transaction collection
        /// </summary>
        public void PhoneStatements()
        {
            SpeechSynthesizer speaker = new SpeechSynthesizer();
            
            StringBuilder sb = new StringBuilder();

            sb.Append($"your statement is as follows ");
            foreach (IBankTransaction transaction in _transactions.OrderByDescending(t => t.Date).Where(t => t.Status==TransactionStatus.Approved))
            {

                sb.Append($"on {transaction.Date.ToShortDateString()} there was a {transaction.Type} of {transaction.Amount}");


            };
            sb.Append($"as at {DateTime.Now.ToShortTimeString()} your balance is {this.Balance()}");
            speaker.Speak(sb.ToString());
            
        }
        /// <summary>
        /// Method to withdrawal on a given date
        /// </summary>
        /// <param name="t">new instance of BankTransaction</param>
        /// <returns></returns>
        public decimal Withdraw(BankTransaction t)
        {
            if(OverdraftAmount()>0)
            {
                if (Balance() + OverdraftAmount() > t.Amount)
                {
                    t.Status = TransactionStatus.Approved;
                }
                else
                {
                    t.Status = TransactionStatus.Rejected;
                }
            }
            else
            {
                if (t.Amount < Balance())
                {
                    t.Status = TransactionStatus.Approved;
                }
                else
                {
                    t.Status = TransactionStatus.Rejected;
                }
            }
            
            t.Id = _transactions.Count + 1;
            t.OldBalance = Balance();
            t.NewBalance = t.OldBalance - Balance();
            _transactions.Add(t);
            return t.NewBalance;
        }

        public decimal Deposit(BankTransaction t)
        {
            t.Id = _transactions.Count + 1;
            t.OldBalance = Balance();
            t.NewBalance = t.OldBalance + Balance();
            t.Status = TransactionStatus.Approved;
            _transactions.Add(t);
            return t.NewBalance;
        }

        public decimal Balance()
        {
            decimal balance = 0;


            foreach (IBankTransaction transaction in _transactions.Where(t => t.Type==TransactionType.Credit && t.Status==TransactionStatus.Approved))
            {

                balance += transaction.Amount;
               
            };
            foreach (IBankTransaction transaction in _transactions.Where(t => t.Type == TransactionType.Debit && t.Status == TransactionStatus.Approved))
            {

                balance -= transaction.Amount;

            };

            return balance;


        }
        public void RequestOverdraft(OverdraftRequest request)
        {
            request.Id = _overdraftRequests.Count + 1;
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
        /// <summary>
        /// Gets the overdraft amount by searching the overdraft requests for the latest approved overdraft
        /// </summary>
        /// <returns>decimal of the approved overdraft</returns>
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
