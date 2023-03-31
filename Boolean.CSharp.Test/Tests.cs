using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Concrete.Accounts;
using Boolean.CSharp.Main.Concrete.SampleData;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void TestTransaction()
        {
            BankTransaction t = new BankTransaction();
            t.Id = 1;
            t.Date = DateTime.Now;
            t.Type = TransactionType.Credit;
            t.Amount = 100.00M;

            Assert.IsTrue(t.Id == 1);
            Assert.IsNotNull(t.Date);
            Assert.IsTrue(t.Type == TransactionType.Credit);
            Assert.IsTrue(t.Amount == 100.00M);
        }
        [Test]
        public void TestCustomer()
        {
            Customer customer = new Customer()
            {
                Name = "Nigel",
                Address = "Bournemouth",
                Id = Guid.NewGuid()
            };

            Assert.IsNotNull(customer.Name);
            Assert.IsNotNull(customer.Address);
            Assert.IsNotNull(customer.Id);

        }
        [Test]
        public void TestAccount()
        {
            SampleData sample = new SampleData();

            Customer customer = new Customer()
            {
                Name = "Nigel",
                Address = "Bournemouth",
                Id = Guid.NewGuid()
            };
            SavingsAccount savingsAccount = new SavingsAccount(customer);
            sample.BankTransactions.ForEach(t =>
            {
                if (t.Type == TransactionType.Credit)
                {
                    savingsAccount.Deposit(t);

                }
                if (t.Type == TransactionType.Debit)
                {
                    savingsAccount.Withdraw(t);
                }

            });

            Assert.IsTrue(savingsAccount.Balance() == 2500.00M);


        }
        [Test]
        public void TestOverdraft()
        {
            OverdraftRequest request = new OverdraftRequest()
            {
                RequestDate = DateTime.Now,
                Amount = 100000M,
                Status = OverdraftStatus.Approved
            };
            SampleData sample = new SampleData();

            Customer customer = new Customer()
            {
                Name = "Nigel",
                Address = "Bournemouth",
                Id = Guid.NewGuid()
            };
            SavingsAccount savingsAccount = new SavingsAccount(customer);
            sample.BankTransactions.ForEach(t =>
            {
                if (t.Type == TransactionType.Credit)
                {
                    savingsAccount.Deposit(t);

                }
                if (t.Type == TransactionType.Debit)
                {
                    savingsAccount.Withdraw(t);
                }

            });

            //Request OD
            savingsAccount.RequestOverdraft(request);
            //Approve OD
            savingsAccount.ApproveOverdraft(1);
            Assert.IsNotNull(savingsAccount);
            Assert.IsTrue(savingsAccount.OverdraftAmount() == 100000M);
        }
        [Test]
        public void TestWithdrawWithOverdraft()
        {
            OverdraftRequest request = new OverdraftRequest()
            {
                RequestDate = DateTime.Now,
                Amount = 100000M,
                Status = OverdraftStatus.Approved
            };
            SampleData sample = new SampleData();

            Customer customer = new Customer()
            {
                Name = "Nigel",
                Address = "Bournemouth",
                Id = Guid.NewGuid()
            };
            SavingsAccount savingsAccount = new SavingsAccount(customer);
            //Request OD
            savingsAccount.RequestOverdraft(request);
            //Approve OD
            savingsAccount.ApproveOverdraft(1);

            foreach (BankTransaction t in sample.BankTransactions)
            {
                if (t.Type == TransactionType.Credit)
                {
                    savingsAccount.Deposit(t);

                }
                if (t.Type == TransactionType.Debit)
                {
                    savingsAccount.Withdraw(t);
                }

            }

            Assert.IsNotNull(savingsAccount);
            Assert.IsTrue(savingsAccount.Balance() == -47500.00M);
        }
        [Test]
        public void TestAccountTypes()
        {
            Customer customer = new Customer()
            {
                Name = "Nigel",
                Address = "Bournemouth",
                Id = Guid.NewGuid()
            };

            CurrentAccount current = new CurrentAccount(customer);
            SavingsAccount savings = new SavingsAccount(customer);

            Assert.IsTrue(current.GetType().BaseType == typeof(Account));
            Assert.IsTrue(savings.GetType().BaseType == typeof(Account));

        }
    }
}