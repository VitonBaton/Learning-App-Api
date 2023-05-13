using LearningApp.Contracts;

namespace LearningApp.Web.HttpContexts;

public static class HttpContextsServicesExtension
{
    public static IServiceCollection AddHttpContexts(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IAuthenticatedUser, AuthenticatedUserContext>();

        return services;
    }
}
