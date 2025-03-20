using System.Text;

namespace Accounting;
using Newtonsoft.Json;

public class JsonExporter : Exporter
{
    protected override string Serialize()
    {
        // Uses the following format:
        // "BankAccounts": [
        // ...
        // ],
        // "Categories": [
        // ...
        // ],
        // "Operations": [
        // ...
        // ]
        var data = new DomainStorage { 
            BankAccounts = this.BankAccounts,
            Categories = this.Categories,
            Operations = this.Operations 
        };
        return JsonConvert.SerializeObject(data, Formatting.Indented);
    }

    public override void YieldBankAccount(BankAccount bankAccount)
    {
        BankAccounts.Add(bankAccount);
    }

    public override void YieldCategory(Category category)
    {
        Categories.Add(category);
    }

    public override void YieldOperation(Operation operation)
    {
        Operations.Add(operation);
    }
}