using AutoMapper;
using LearningApp.LoggerService;
using LearningApp.Repositories;
using LearningApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace LearningApp.Web.Extensions;

public static class ApiServicesExtension
{
    public static void AddApiServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            })
            .Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddRepositories()
            .AddPostgreSqlDbContext(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")))
            .AddBLLServices()
            .AddLogger()
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            })
            .AddSwaggerServices();
            //.AddSingleton<ErrorHandlerMiddleware>()
            //.AddFailureHandlers();

        builder.AddSerilogLoggerProvider();
    }

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "LearningApp",
                Version = "v1",
                Description = "Documentation of API"
            });

            //setup.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            //{
            //    In = ParameterLocation.Header,
            //    Description = "Please, insert JWT. For example: Bearer ABC123...",
            //    Name = HeaderNames.Authorization,
            //    Type = SecuritySchemeType.ApiKey
            //});

            //setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = JwtBearerDefaults.AuthenticationScheme
            //            }
            //        },
            //        Array.Empty<string>()
            //    }
            //});
        });

        return services;
    }
}
