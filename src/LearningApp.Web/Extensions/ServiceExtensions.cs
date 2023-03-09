using LearningApp.Contracts;
using LearningApp.Contracts.Repositories;
using LearningApp.Contracts.Services;
using LearningApp.Entities;
using LearningApp.LoggerService;
using LearningApp.Repositories;
using LearningApp.Services;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Web.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => 
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddTransient<ILoggerManager, LoggerManager>();
    }

    public static void ConfigurePostgreSqlContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("PostgreSQL");
        services.AddDbContext<LearningContext>(o => o.UseNpgsql(connectionString));
    }
    
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
    }

    //public static void ConfigureServices(this IServiceCollection services)
    //{
    //    services.AddTransient<IChaptersService, ChaptersService>();
    //    services.AddTransient<ILecturesService, LecturesService>();
    //}
}