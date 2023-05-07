using System.Text;
using LearningApp.DataAccess;
using LearningApp.Models.Auth;
using LearningApp.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LearningApp.Services.Auth;

public static class AuthServicesExtension
{
    public static IServiceCollection AddAuth(this IServiceCollection services, AuthSettings authSettings)
    {

        services
            .AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<LearningDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authSettings.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.SecurityKey)),
                    ValidateIssuerSigningKey = true,
                };
            });

        return services;
    }

    public static IServiceCollection AddAuthSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
        return services;
    }
}
