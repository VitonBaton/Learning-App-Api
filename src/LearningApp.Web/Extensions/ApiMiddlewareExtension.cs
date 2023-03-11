namespace LearningApp.Web.Extensions;

public static class ApiMiddlewareExtension
{
    public static WebApplication UseApiMiddleware(this WebApplication app)
    {
        //app.UseMiddleware<ErrorHandlerMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHsts();
        app.UseForwardedHeaders();
        app.UseHttpsRedirection();

        app.UseCors("CorsPolicy");

        app.MapControllers();

        return app;
    }
}
