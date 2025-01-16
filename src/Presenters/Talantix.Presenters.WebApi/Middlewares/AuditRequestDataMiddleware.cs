using Microsoft.Extensions.Logging;

namespace Talantix.Presenters.WebApi.Middlewares;

public class AuditRequestDataMiddleware(RequestDelegate next, ILogger<AuditRequestDataMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress.ToString();
        var endpointPath = context.Request.Path;
        var endpointQuery = context.Request.Query;
        logger.LogInformation("PATH: {0}; QUERY: {0}; IP: {1}", endpointPath, endpointQuery, remoteIp);
        await next(context);
    }
}
