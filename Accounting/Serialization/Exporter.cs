namespace Accounting;

public abstract class Exporter
{
    protected readonly List<BankAccount> BankAccounts = [];
    protected readonly List<Category> Categories = [];
    protected readonly List<Operation> Operations = [];
    
    public void Export(string filePath)
    {
        string data = Serialize();
        File.WriteAllText(filePath, data);
    }

    protected abstract string Serialize();
    public abstract void YieldBankAccount(BankAccount bankAccount);
    public abstract void YieldCategory(Category category);
    public abstract void YieldOperation(Operation operation);  
}