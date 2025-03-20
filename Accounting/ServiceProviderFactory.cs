namespace Accounting;

using Microsoft.Extensions.DependencyInjection;

public static class ZooServiceProviderFactory
{
    public static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        
        services.AddTransient<BankAccountFactory>();
        services.AddTransient<CategoryFactory>();
        services.AddTransient<OperationFactory>();

        return services.BuildServiceProvider();
    }
}