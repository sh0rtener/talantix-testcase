using Newtonsoft.Json;
using Talantix.Core.Domain.Common;

namespace Talantix.Presenters.WebApi.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (DomainException ex)
        {
            ErrorModel model = new() { Message = ex.Message };
            await HandleAsync(context, model);
        }
        catch (InvalidDataException ex)
        {
            ErrorModel model = new() { Message = ex.Message };
            await HandleAsync(context, model);
        }
        catch (Exception)
        {
            ErrorModel model = new() { Message = "Internal server Error" };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var result = JsonConvert.SerializeObject(model);

            await context.Response.WriteAsync(result);
        }
    }

    private async Task HandleAsync(HttpContext context, ErrorModel model)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;

        var result = JsonConvert.SerializeObject(model);

        await context.Response.WriteAsync(result);
    }

    private class ErrorModel
    {
        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("Errors")]
        public Dictionary<string, string[]> Errors { get; set; } = new();
    }
}
