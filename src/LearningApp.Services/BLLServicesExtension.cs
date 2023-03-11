using AutoMapper;
using LearningApp.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Services;

public static class BLLServicesExtension
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        //services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyMarker).Assembly);

        services.AddScoped<IChaptersService, ChaptersService>();
        services.AddScoped<ILecturesService, LecturesService>();

        services.AddAutoMapper(typeof(IBLLAssemblyMarker).Assembly);
        return services;
    }
}
