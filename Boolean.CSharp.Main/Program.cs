// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Customer customer = new Customer()
{
    Name = "Nigel",
    Address = "Bournemouth",
    Id = Guid.NewGuid()
};

CurrentAccount currentAccount = new CurrentAccount(customer);

currentAccount.Deposit(1000.00M, new DateTime(2012, 1, 10));
currentAccount.Deposit(2000.00M, new DateTime(2012, 1, 13));
currentAccount.Withdraw(500.00M, new DateTime(2012, 1, 14));


currentAccount.WriteStatement();

Console.WriteLine($"Account Number: {currentAccount.Id}");
Console.ReadLine();