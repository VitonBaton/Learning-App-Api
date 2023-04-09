using LearningApp.Contracts.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LearningApp.LoggerService;

public static class LoggerServicesExtension
{
    public static WebApplicationBuilder AddSerilogLoggerProvider(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, config) =>
        {
            config.ReadFrom.Configuration(context.Configuration);
        });
        return builder;
    }
    public static IServiceCollection AddLogger(this IServiceCollection services)
    {
        services.AddScoped<ILoggerManager, LoggerManager>();
        return services;
    }
}
