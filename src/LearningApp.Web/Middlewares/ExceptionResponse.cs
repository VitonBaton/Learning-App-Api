namespace LearningApp.Web.Middlewares;

public sealed class ExceptionResponse
{
    public ExceptionResponse(string message)
    {
        Message = message;
        PermissionFailures = new List<string>(); // todo
        // ValidationFailures = new List<ValidationFailure>();
    }

    public string Message { get; set; }
    public List<string> PermissionFailures { get; set; }
}
