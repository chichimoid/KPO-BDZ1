namespace Accounting;

public static class ConsoleView
{
    public static void ShowDefaultMenu(DomainStorage storage, BankAccountFactory bankAccountFactory, 
        CategoryFactory categoryFactory, OperationFactory operationFactory)
    {
        while (true) {
            Console.Clear();
            Console.WriteLine("=== Console Menu ===");
            Console.WriteLine("1. Create Bank Account");
            Console.WriteLine("2. Create Category");
            Console.WriteLine("3. Create Operation");
            Console.WriteLine("4. View Bank Accounts");
            Console.WriteLine("5. View Categories");
            Console.WriteLine("6. View Operations");
            Console.WriteLine("7. Add operation to account");
            Console.WriteLine("8. View Analytics");
            Console.WriteLine("9. Export.");
            Console.WriteLine("10. Import");
            Console.WriteLine("11. Exit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateBankAccount(storage, bankAccountFactory);
                        break;
                    case 2:
                        CreateCategory(storage, categoryFactory);
                        break;
                    case 3:
                        CreateOperation(storage, operationFactory);
                        break;
                    case 4:
                        ViewBankAccounts(storage);
                        break;
                    case 5:
                        ViewCategories(storage);
                        break;
                    case 6:
                        ViewOperations(storage);
                        break;
                    case 7:
                        AddOperationToAccount(storage);
                        break;
                    case 8:
                        ViewAnalytics(storage);
                        break;
                    case 9:
                        Export(storage);
                        break;
                    case 10:
                        Import(storage);
                        break;
                    case 11:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            Thread.Sleep(1000);
        }
    }
    private static void CreateBankAccount(DomainStorage storage, BankAccountFactory factory)
    {
        Console.Clear();
        Console.WriteLine("=== Create Bank Account ===");
        Console.Write("Enter account id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid bank account ID. Bank account creation canceled.");
            return;
        }
        Console.Write("Enter account name: ");
        string name = Console.ReadLine();
        
        var account = factory.Create(id, name);
        
        storage.BankAccounts.Add(account);
        Console.WriteLine("Account created successfully.");
    }

    private static void CreateCategory(DomainStorage storage, CategoryFactory factory)
    {
        Console.Clear();
        Console.WriteLine("=== Create Category ===");
        Console.Write("Enter category id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid category ID. Category creation canceled.");
            return;
        }
        Console.Write("Enter category name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Choose category type: ");
        Console.WriteLine("1. Income");
        Console.WriteLine("2. Expenes");
        // Compiler won't let you leave that uninitialized even if all paths lead to further initialization.
        if (!int.TryParse(Console.ReadLine(), out int typeChoice) || typeChoice < 1 || typeChoice > 2)
        {
            Console.WriteLine("Invalid choice. Operation creation canceled.");
            return;
        }
        CategoryType type = typeChoice == 1 ? CategoryType.Income : CategoryType.Expense;
        
        var category = factory.Create(id, name, type);

        storage.Categories.Add(category);
        Console.WriteLine("Category created successfully.");
    }

    private static void CreateOperation(DomainStorage storage, OperationFactory factory)
    {
        Console.Clear();
        Console.WriteLine("=== Create Operation ===");
        
        Console.Write("Enter operation ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid operation ID. Operation creation canceled.");
            return;
        }
        
        Console.WriteLine("Select operation type:");
        Console.WriteLine("1. Income");
        Console.WriteLine("2. Expense");
        Console.Write("Enter choice: ");
        if (!int.TryParse(Console.ReadLine(), out int typeChoice) || typeChoice < 1 || typeChoice > 2)
        {
            Console.WriteLine("Invalid choice. Operation creation canceled.");
            return;
        }
        OperationType type = typeChoice == 1 ? OperationType.Income : OperationType.Expense;
        
        Console.Write("Enter bank account ID: ");
        if (!int.TryParse(Console.ReadLine(), out int bankAccountId))
        {
            Console.WriteLine("Invalid bank account ID. Operation creation canceled.");
            return;
        }

        Console.Write("Enter amount: ");
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Invalid amount. Operation creation canceled.");
            return;
        }

        Console.Write("Enter the date time (type NOW for DateTime.Now): ");
        string input = Console.ReadLine();
        DateTime time;
        if (input == "NOW")
        {
            time = DateTime.Now;
        }
        else if (!DateTime.TryParse(Console.ReadLine(), out time))
        {
            Console.WriteLine("Invalid date time. Operation creation canceled.");
        }

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter category ID: ");
        if (!int.TryParse(Console.ReadLine(), out int categoryId))
        {
            Console.WriteLine("Invalid category ID. Operation creation canceled.");
            return;
        }
        
        var operation = factory.Create(id, type, bankAccountId, amount, time, description, categoryId);
        
        storage.Operations.Add(operation);
        Console.WriteLine("Operation created successfully.");
    }

    private static void ViewBankAccounts(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Bank Accounts ===");
        if (storage.BankAccounts.Count == 0)
        {
            Console.WriteLine("No bank accounts found.");
        }
        else
        {
            foreach (var account in storage.BankAccounts)
            {
                Console.WriteLine($"ID: {account.Id.Value}, Name: {account.Name}, Balance: {account.Balance.Value}");
            }
            WaitForAnyKey();
        }
    }

    private static void ViewCategories(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Categories ===");
        if (storage.Categories.Count == 0)
        {
            Console.WriteLine("No categories found.");
        }
        else
        {
            foreach (var category in storage.Categories)
            {
                Console.WriteLine($"ID: {category.Id.Value}, Name: {category.Name}");
            }
            WaitForAnyKey();
        }
    }

    private static void ViewOperations(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Operations ===");
        if (storage.Operations.Count == 0)
        {
            Console.WriteLine("No operations found.");
        }
        else
        {
            foreach (var operation in storage.Operations)
            {
                Console.WriteLine($"ID: {operation.Id.Value}, BankAccountID: {operation.BankAccountId.Value}" +
                                  $" Description: {operation.Description}, Amount: {operation.Amount}, " +
                                  $"Date: {operation.Date}, Description: {operation.Description}");
            }
            WaitForAnyKey();
        }
    }

    private static void AddOperationToAccount(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Add Operation to Account ===");
        Console.Write("Enter account id: ");
        if (!int.TryParse(Console.ReadLine(), out int accountId))
        {
            Console.WriteLine("Invalid bank account ID. Operation not added.");
            return;
        }

        var account = storage.BankAccounts.Find(x => x.Id.Value == accountId);
        if (account == null)
        {
            Console.WriteLine("Bank account not found. Operation not added.");
            return;
        }
        
        Console.Write("Enter operation id: ");
        if (!int.TryParse(Console.ReadLine(), out int operationId))
        {
            Console.WriteLine("Invalid operation ID. Operation not added.");
            return;
        }

        var operation = storage.Operations.Find(x => x.Id.Value == operationId);
        if (operation == null)
        {
            Console.WriteLine("Operation not found. Operation not added.");
            return;
        }
        
        BankAccountManager.AddOperation(account, operation);
        Console.WriteLine("Operation added successfully.");
    }

    private static void ViewAnalytics(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Analytics ===");
        Console.WriteLine("1. Calculate profit");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    ViewCalculateProfit(storage);
                    break;
                default:
                    Console.WriteLine("Invalid option. Analytics canceled.");
                    return;
            }
        }
    }

    private static void ViewCalculateProfit(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Calculate Profit ===");
        Console.Write("Enter account id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid bank account ID. Calculation canceled.");
            return;
        }

        var account = storage.BankAccounts.Find(x => x.Id.Value == id);
        if (account == null)
        {
            Console.WriteLine("Bank account not found. Calculation canceled.");
            return;
        }

        if (account.History.Count == 0)
        {
            Console.WriteLine("Profit: 0");
            return;
        }
        
        Console.Write("Enter start date (type FIRST to start at the very first one): ");
        string input = Console.ReadLine();
        DateTime startTime;
        if (input == "FIRST")
        {
            startTime = account.History[0].Date;
        }
        else if (!DateTime.TryParse(Console.ReadLine(), out startTime))
        {
            Console.WriteLine("Invalid date time. Operation creation canceled.");
        }
        
        Console.Write("Enter start date (type NOW for DateTime.Now):");
        input = Console.ReadLine();
        DateTime endTime;
        if (input == "NOW")
        {
            endTime = DateTime.Now;
        }
        else if (!DateTime.TryParse(Console.ReadLine(), out endTime))
        {
            Console.WriteLine("Invalid date time. Operation creation canceled.");
        }

        var result = BankAccountAnalytics.CalculateProfit(account, startTime, endTime);
        
        Console.WriteLine($"Profit: {result}");
        
        WaitForAnyKey();
    }

    private static void Export(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Export ===");
        Console.Write("Enter the file name: ");
        string fileName = Console.ReadLine();
        Console.Write("Choose the file format: ");
        Console.WriteLine("1. JSON");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    var exporter = new JsonExporter();
                    storage.AcceptExporter(exporter);
                    exporter.Export($"{fileName}.json");
                    break;
                default:
                    Console.WriteLine("Invalid option. Analytics canceled.");
                    return;
            }
        }
        Console.WriteLine("Export successful.");
    }
    
    private static void Import(DomainStorage storage)
    {
        Console.Clear();
        Console.WriteLine("=== Export ===");
        Console.Write("Enter the file path: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Could not find the file. Import canceled.");
            return;
        }
        if (filePath.EndsWith(".json"))
        {
            var jsonImporter = new JsonImporter();
            jsonImporter.Import(filePath, out var bankAccounts,
                out var categories, out var operations);
            storage.BankAccounts = bankAccounts;
            storage.Categories = categories;
            storage.Operations = operations;
        }
        
        Console.WriteLine("Import successful.");
    }

    private static void WaitForAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}