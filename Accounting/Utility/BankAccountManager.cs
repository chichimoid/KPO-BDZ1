namespace Accounting;

public static class BankAccountManager
{
    public static void AddOperation(BankAccount bankAccount, Operation operation)
    {
        if (bankAccount.Id.Value != operation.BankAccountId.Value)
        {
            throw new ArgumentException("The operation belongs to a different bank account");
        }
        
        switch (operation.Type)
        {
            case OperationType.Expense :
                if (operation.Amount > bankAccount.Balance.Value)
                {
                    throw new ArgumentException("Insufficient funds");
                }
                bankAccount.Balance.Value -= operation.Amount;
                break;
            case OperationType.Income :
                bankAccount.Balance.Value += operation.Amount;
                break;
        }
        
        bankAccount.History.Add(operation);
    }
}