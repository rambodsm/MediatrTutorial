using System.Net;
using System.Text.Json;

namespace MediatrTutorial.Filters;

public class ExceptionHandlerFilter
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerFilter> _logger;

    public ExceptionHandlerFilter(RequestDelegate next, ILogger<ExceptionHandlerFilter> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var obj = new
        {
            Message = exception.Message
        };

        var serilized = JsonSerializer.Serialize(obj);

        await context.Response.WriteAsync(serilized);
    }
}