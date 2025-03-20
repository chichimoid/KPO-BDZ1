namespace Accounting;

public abstract class Importer {
    protected List<BankAccount>? BankAccounts;
    protected List<Category>? Categories;
    protected List<Operation>? Operations;
    
    public void Import(string filePath, out List<BankAccount> newBankAccounts, out List<Category> newCategories,
        out List<Operation> newOperations)
    {
        Deserialize(filePath);
        newBankAccounts = BankAccounts ?? [];
        newCategories = Categories ?? [];
        newOperations = Operations ?? [];
    }

    protected abstract void Deserialize(string filePath);
}