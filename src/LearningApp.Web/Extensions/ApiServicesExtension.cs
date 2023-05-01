﻿using AutoMapper;
using LearningApp.LoggerService;
using LearningApp.DataAccess;
using LearningApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using LearningApp.DataAccess.Repositories;
using LearningApp.Web.Middlewares;

namespace LearningApp.Web.Extensions;

public static class ApiServicesExtension
{
    public static void AddApiServices(this WebApplicationBuilder builder)
    {
        builder
            .AddSerilogLoggerProvider()
            .Services
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
            .AddBllServices()
            .AddLogger()
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    corsPolicyBuilder =>
                        corsPolicyBuilder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            })
            .AddSwaggerServices()
            .AddSingleton<ErrorHandlerMiddleware>();
        //.AddFailureHandlers();
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
