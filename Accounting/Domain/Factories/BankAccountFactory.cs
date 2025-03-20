namespace Accounting;

public class BankAccountFactory
{
    public BankAccount Create(Id id, string name)
    {
        if (name == null || name.Length < 2)
        {
            throw new ArgumentException("Name must be at least 2 characters long");
        }
        return new BankAccount(0, id, name);
    }
}