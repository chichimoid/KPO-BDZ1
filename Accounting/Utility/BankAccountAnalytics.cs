namespace Accounting;

public static class BankAccountAnalytics
{
    public static double CalculateProfit(BankAccount account, DateTime startDate, DateTime endDate)
    {
        Balance sum = new(0);
        foreach (var op in account.History)
        {
            if (op.Date >= startDate && op.Date <= endDate)
            {
                sum.Value += op.Amount;
            }
        }
        return sum.Value;
    }
}