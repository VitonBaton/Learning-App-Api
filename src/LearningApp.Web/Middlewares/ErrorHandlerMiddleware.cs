using System.Net.Mime;
using System.Text.Json;
using LearningApp.Contracts.Services;
using LearningApp.Core.Exceptions;

namespace LearningApp.Web.Middlewares;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILoggerManager _logger;

    public ErrorHandlerMiddleware(ILoggerManager logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var statusCode = 500;
            var exceptionResponse = new ExceptionResponse(ex.Message);

            switch (ex)
            {
                case InvalidDataAppException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case NotFoundAppException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                case AppException:
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }


            context.Response.StatusCode = statusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            var json = JsonSerializer.Serialize(exceptionResponse);
            _logger.LogError(json);
            await context.Response.WriteAsync(json, context.RequestAborted);
        }
    }
}
