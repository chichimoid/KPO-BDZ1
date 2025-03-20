using System.Collections.ObjectModel;
using System.Globalization;

namespace Accounting;

public class BankAccount(Balance balance, Id id, string name)
{
    public Id Id { get; } = id;
    public Balance Balance { get; private set; } = balance;
    public string Name { get; private set; } = name;

    public List<Operation> History { get; } = [];

    public void AcceptExporter(Exporter visitor)
    {
        visitor.YieldBankAccount(this);
    }
}