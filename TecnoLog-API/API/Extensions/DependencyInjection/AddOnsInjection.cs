namespace API.Extensions.DependencyInjection;

using Application.Interfaces.Providers;
using Application.Interfaces.Services.Core;
using Application.Interfaces.Services.Core.Auth;
using Infrastructure.Providers;
using Infrastructure.Services;

public static class AddOnsInjection
{
    public static IServiceCollection AddAddOns(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddScoped<ICsvService, CsvService>();
        services.AddScoped<IProfileService, ProfileService>();

        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }
}