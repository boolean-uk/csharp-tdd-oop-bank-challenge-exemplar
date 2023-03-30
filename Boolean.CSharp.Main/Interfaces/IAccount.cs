namespace Boolean.CSharp.Main.Interfaces
{
    public interface IAccount
    {
        decimal Withdraw(decimal amount, DateTime when);
        decimal Deposit(decimal amount, DateTime when);
    }
}