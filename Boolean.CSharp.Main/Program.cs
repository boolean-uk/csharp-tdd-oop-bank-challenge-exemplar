// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Concrete.Accounts;
using Boolean.CSharp.Main.Concrete.SampleData;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;




/********************************************************/


Customer customer = new Customer()
{
    Name = "Nigel",
    Address = "Bournemouth",
    Id = Guid.NewGuid()
};
//create current account
CurrentAccount currentAccount = new CurrentAccount(customer);


/********************************************************/

OverdraftRequest request = new OverdraftRequest()
{
    RequestDate = DateTime.Now,
    Amount = 100000M,
    Status = OverdraftStatus.Pending
};

//Request OD
currentAccount.RequestOverdraft(request);
//Approve OD
currentAccount.ApproveOverdraft(1);

/********************************************************/



SampleData data = new SampleData();
data.BankTransactions.ForEach(t =>
{
    if(t.Type == TransactionType.Credit)
    {
        currentAccount.Deposit(t);

    } 
    if(t.Type==TransactionType.Debit)
    {
        currentAccount.Withdraw(t);
    }
    
});

/********************************************************/

currentAccount.Branch = Branches.Bournemouth;
currentAccount.WriteStatement();

Console.WriteLine($"Account Number: {currentAccount.Id}");
Console.WriteLine($"Balance: {currentAccount.Balance()}");

/********************************************************/
currentAccount.PhoneStatements();

/********************************************************/


Console.ReadLine();

/********************************************************/