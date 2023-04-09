using LearningApp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateOnBuild = true;
    options.ValidateScopes = true;
});

builder.AddApiServices();
var app = builder.Build();
app.UseApiMiddleware();
await app.RunAsync();
