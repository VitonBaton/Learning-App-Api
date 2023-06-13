using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using LearningApp.DataAccess;
using LearningApp.LoggerService;
using LearningApp.Models.Auth;
using LearningApp.Services;
using LearningApp.Web.Auth;
using LearningApp.Web.DatabaseSeeds;
using LearningApp.Web.HttpContexts;
using LearningApp.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace LearningApp.Web.Extensions;

public static class ApiServicesExtension
{
    public static void AddApiServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthSettings(builder.Configuration)
            .AddSeedsSettings(builder.Configuration);

        var authSettings = builder.Configuration
            .GetRequiredSection("AuthSettings")
            .Get<AuthSettings>();

        builder
            .AddSerilogLoggerProvider()
            .Services
            .AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
            .Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddRepositories()
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(typeof(IWebAssemblyMarker).Assembly)
            .AddPostgreSqlDbContext(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")))
            .AddBllServices()
            .AddLogger()
            /*.AddIdentityCore<User>()
            .AddRoles<Role>()
            .AddEntityFrameworkStores<LearningDbContext>().Services*/
            .AddDatabaseSeedServices()
            .AddAuth(authSettings)
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    corsPolicyBuilder =>
                        corsPolicyBuilder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            })
            .AddSwaggerServices()
            .AddScoped<ErrorHandlerMiddleware>()
            .AddScoped<RequestLoggingMiddleware>()
            .AddHttpContexts();
        //.AddFailureHandlers();
    }

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1",
                new OpenApiInfo { Title = "LearningApp", Version = "v1", Description = "Documentation of API" });

            setup.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please, insert JWT. For example: Bearer ABC123...",
                    Name = HeaderNames.Authorization,
                    Type = SecuritySchemeType.ApiKey
                });

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme, Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}
