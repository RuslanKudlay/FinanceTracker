using BAL.Services;
using BAL.Services.Interfaces;

namespace FinanceTracking.Extentions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddDI(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthService, AuthService>();

        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<ISettingService, SettingService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<ITransactionService, TransactionService>();

        return serviceCollection;
    }
}