using LearningApp.LoggerService;
using LearningApp.Repositories;
using LearningApp.Services;
using LearningApp.Web.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.AddLogger();
builder.AddApiServices();
builder.Services.AddRepositories();
builder.Services.AddBLLServices();

//builder.Services.AddAutoMapper(typeof(ChaptersProfile), typeof(LecturesProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "LearningApp", Version = "v1"});
});

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.MapControllers();
app.Run();
