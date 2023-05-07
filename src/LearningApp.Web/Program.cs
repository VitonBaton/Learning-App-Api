using LearningApp.DataAccess;
using LearningApp.Web.DatabaseSeeds;
using LearningApp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateOnBuild = true;
    options.ValidateScopes = true;
});

builder.AddApiServices();
var app = builder.Build();

await app.Services.MigrateDatabaseAsync<LearningDbContext>(app.Lifetime.ApplicationStopping);
await app.Services.SeedEntitiesAsync<LearningDbContext>(app.Lifetime.ApplicationStopping);

app.UseApiMiddleware();
await app.RunAsync();
