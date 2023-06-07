using LearningApp.Web.Middlewares;
using Microsoft.Extensions.FileProviders;

namespace LearningApp.Web.Extensions;

public static class ApiMiddlewareExtension
{
    public static WebApplication UseApiMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHsts();
        app.UseForwardedHeaders();
        app.UseHttpsRedirection();

        app.UseCors("CorsPolicy");

        app.MapControllers();

        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Documents")),
            RequestPath = new PathString("/Documents")
        });

        return app;
    }
}
