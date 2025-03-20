namespace Accounting;

public class OperationFactory
{
    public Operation Create(Id id, OperationType type, Id bankAccountId, double amount,
        DateTime date, string description, Id categoryId)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }
        
        return new Operation(id, type, bankAccountId, amount, date, description, categoryId);
    }
}