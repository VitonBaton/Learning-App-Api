using LearningApp.Contracts;

namespace LearningApp.Web.DatabaseSeeds;

public static class DatabaseSeedsExtension
{
    public static IServiceCollection AddDatabaseSeedServices(this IServiceCollection services)
    {
        services.AddTransient<ISeedsProvider, RolesSeed>();
        services.AddTransient<ISeedsProvider, UsersSeed>();
        services.AddTransient<ISeedsProvider, ChaptersSeed>();
        return services;
    }
}
