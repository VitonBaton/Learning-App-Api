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

    public static void AddApiServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
        builder.Services
            .AddPostgreSqlDbContext(o => o.UseNpgsql(connectionString));
    }
}
