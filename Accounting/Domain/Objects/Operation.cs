namespace Accounting;

public enum OperationType
{
    Income,
    Expense,
}

public class Operation(
    Id id,
    OperationType type,
    Id bankAccountId,
    double amount,
    DateTime date,
    string description,
    Id categoryId)
{
    public Id Id { get; } = id;
    public OperationType Type { get; } = type;
    public Id BankAccountId { get; } = bankAccountId;
    public double Amount { get; } = amount;
    public DateTime Date { get; } = date;
    public string Description { get; } = description;
    public Id CategoryId { get; } = categoryId;

    public void AcceptExporter(Exporter visitor)
    {
        visitor.YieldOperation(this);
    }
}