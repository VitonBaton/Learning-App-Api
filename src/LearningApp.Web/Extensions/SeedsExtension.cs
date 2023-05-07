using LearningApp.Contracts;
using LearningApp.Web.DatabaseSeeds;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Web.Extensions;

public static class SeedsExtension
{
    public static async Task SeedEntitiesAsync<TContext>(this IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
        where TContext : DbContext
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();

        try
        {
            logger.LogInformation("Seeding started");

            var seedProviders = scope.ServiceProvider.GetServices<ISeedsProvider>();
            foreach (var seedProvider in seedProviders)
            {
                await seedProvider.Seed(cancellationToken);
            }

            logger.LogInformation("Seeding finished");
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, "An error occurred while seeding the database");
        }
    }

    public static IServiceCollection AddSeedsSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<SeedsSettings>(configuration.GetSection("SeedsSettings"));
        return services;
    }
}
