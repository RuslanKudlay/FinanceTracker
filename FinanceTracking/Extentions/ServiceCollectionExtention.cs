using BAL.Services;
using BAL.Services.Interfaces;

namespace FinanceTracking.Extentions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddDI(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthService, AuthService>();

        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IMonoService, MonoService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<ITransactionService, TransactionService>();

        serviceCollection.AddScoped<IClientService, ClientService>();
        serviceCollection.AddScoped<IFamilyGroupService, FamilyGroupService>();
        serviceCollection.AddScoped<IEmailService, SmtpEmailService>();
        serviceCollection.AddScoped<IUserSettingService, UserSettingService>();

        return serviceCollection;
    }
}