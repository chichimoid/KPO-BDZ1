namespace Accounting;

using Microsoft.Extensions.DependencyInjection;

internal static class Program
{
    private static void Main()
    {
        var serviceProvider = ZooServiceProviderFactory.CreateServiceProvider();

        var bankAccountFactory = serviceProvider.GetRequiredService<BankAccountFactory>();
        var categoryFactory = serviceProvider.GetRequiredService<CategoryFactory>();
        var operationFactory = serviceProvider.GetRequiredService<OperationFactory>();

        var storage = new DomainStorage();
        
        ConsoleView.ShowDefaultMenu(storage, bankAccountFactory, categoryFactory, operationFactory);
        
        
        // Additional small test
        /*
        var a = bankAccountFactory.Create(0, "Main");
        var b = bankAccountFactory.Create(1, "Mine");
        var c = bankAccountFactory.Create(2 ,"Maine");
        
        storage.BankAccounts.Add(a);
        storage.BankAccounts.Add(b);
        storage.BankAccounts.Add(c);

        JsonExporter exporter = new();
        storage.AcceptExporter(exporter);

        var o = operationFactory.Create(0, OperationType.Income, 0, 100, DateTime.Now, "o", 0);
        BankAccountManager.AddOperation(a, o);

        exporter.Export("out.json");

        JsonImporter importer = new();
        importer.Import("out.json", out var ba,  out var bb, out var bc);
        storage.BankAccounts = ba;
        storage.Categories = bb;
        storage.Operations = bc;

        exporter = new JsonExporter();
        storage.AcceptExporter(exporter);
        exporter.Export("out2.json");
        */
    }
}