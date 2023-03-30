// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Concrete.Accounts;
using Boolean.CSharp.Main.Enums;

Customer customer = new Customer()
{
    Name = "Nigel",
    Address = "Bournemouth",
    Id = Guid.NewGuid()
};


//create current account
CurrentAccount currentAccount = new CurrentAccount(customer);

currentAccount.Deposit(1000.00M, new DateTime(2012, 1, 10));
currentAccount.Deposit(2000.00M, new DateTime(2012, 1, 13));
currentAccount.Withdraw(500.00M, new DateTime(2012, 1, 14));

currentAccount.Branch = Branches.Bournemouth;

currentAccount.WriteStatement();

Console.WriteLine($"Account Number: {currentAccount.Id}");
Console.WriteLine($"Balance: {currentAccount.Balance()}");

OverdraftRequest request = new OverdraftRequest();
request.Id = currentAccount.OverdraftRequests() + 1;
request.Amount = 10000M;
request.Status = OverdraftStatus.Pending;
request.RequestDate = DateTime.Now;

currentAccount.RequestOverdraft(request);
currentAccount.ApproveOverdraft(1);

currentAccount.PhoneStatements();


//create savings account
SavingsAccount savingsAccount = new SavingsAccount(customer);
savingsAccount.Deposit(10000000, DateTime.Now);
savingsAccount.PhoneStatements();

Console.ReadLine();