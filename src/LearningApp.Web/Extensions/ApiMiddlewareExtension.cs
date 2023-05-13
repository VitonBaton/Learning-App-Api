using LearningApp.Web.Middlewares;

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
        return app;
    }
}
