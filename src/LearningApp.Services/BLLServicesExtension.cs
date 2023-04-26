using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LearningApp.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Services;

public static class BllServicesExtension
{
    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(IBllAssemblyMarker).Assembly);

        services.AddScoped<IChaptersService, ChaptersService>();
        services.AddScoped<ILecturesService, LecturesService>();

        services.AddAutoMapper(typeof(IBllAssemblyMarker).Assembly);
        return services;
    }
}
