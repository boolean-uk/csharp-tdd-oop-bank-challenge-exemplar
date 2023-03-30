using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void TestTransaction()
        {
            Transaction t = new Transaction();
            t.Id = 1;
            t.Date = DateTime.Now;
            t.Type = Main.Enum.TransactionType.Credit;
            t.Amount = 100.00M;

            Assert.IsTrue(t.Id == 1);
            Assert.IsNotNull(t.Date);
            Assert.IsTrue(t.Type == Main.Enum.TransactionType.Credit);
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