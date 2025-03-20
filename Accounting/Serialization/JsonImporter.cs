namespace Accounting;
using Newtonsoft.Json;

public class JsonImporter : Importer
{
    protected override void Deserialize(string filePath)
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
        var text = File.ReadAllText(filePath);
        var data = JsonConvert.DeserializeObject<DomainStorage>(text);
        
        BankAccounts = data.BankAccounts;
        Categories = data.Categories;
        Operations = data.Operations;
    }
}