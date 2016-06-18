using Microsoft.AspNetCore.Builder;
public static class RequestLoggerExtensions
{
    public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder) {
        return builder.UseMiddleware<RequestLoggerMiddleware>();
    }
}