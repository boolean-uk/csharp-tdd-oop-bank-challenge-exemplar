using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Concrete.Accounts;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
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
            Customer customer = new Customer()
            {
                Name = "Nigel",
                Address = "Bournemouth",
                Id = Guid.NewGuid()
            };

            CurrentAccount currentAccount = new CurrentAccount(customer);

            currentAccount.Deposit(1000000.00M,DateTime.Now);
            currentAccount.Deposit(1000000.00M, DateTime.Now);
            currentAccount.Withdraw(234.04M, DateTime.Now);
            currentAccount.Deposit(1000000.00M, DateTime.Now);
            Thread.Sleep(10000);
            currentAccount.Withdraw(5234.22M, DateTime.Now);


        }
    }
}