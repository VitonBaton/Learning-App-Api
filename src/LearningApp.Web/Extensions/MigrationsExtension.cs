using Microsoft.EntityFrameworkCore;

namespace LearningApp.Web.Extensions;

public static class MigrationsExtension
{
    public static async Task MigrateDatabaseAsync<TContext>(this IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
        where TContext : DbContext
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();

        try
        {
            logger.LogInformation("Database migration started");
            await context.Database.MigrateAsync(cancellationToken);

            logger.LogInformation("Database has been migrated");
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, "An error occurred while migrating the database");
        }
    }
}
