using LearningApp.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.LoggerService;

public static class LoggerServicesExtension
{
    public static IServiceCollection AddLogger(this IServiceCollection services)
    {
        services.AddScoped<ILoggerManager, LoggerManager>();
        return services;
    }
}
