using LearningApp.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Services;

public static class BllServicesExtension
{
    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddScoped<IChaptersService, ChaptersService>();
        services.AddScoped<ILecturesService, LecturesService>();
        services.AddScoped<IUsersService, UsersService>();

        services.AddAutoMapper(typeof(IBllAssemblyMarker).Assembly);
        return services;
    }
}
