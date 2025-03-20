namespace Accounting;

public enum CategoryType
{
    Income,
    Expense
}

public class Category(Id id, string name, CategoryType type)
{
    public Id Id { get; } = id;
    public CategoryType Type { get; } = type;
    public string Name { get; private set; } = name;

    public void AcceptExporter(Exporter visitor)
    {
        visitor.YieldCategory(this);
    }
}