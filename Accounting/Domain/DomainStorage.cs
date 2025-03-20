namespace Accounting;

public class DomainStorage()
{
    public List<BankAccount> BankAccounts { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
    public List<Operation> Operations { get; set; } = [];

    public void AcceptExporter(Exporter exporter)
    {
        foreach (var i in BankAccounts)
        {
            i.AcceptExporter(exporter);
        }
        foreach (var i in Categories)
        {
            i.AcceptExporter(exporter);
        }
        foreach (var i in Operations)
        {
            i.AcceptExporter(exporter);
        }
    }
}