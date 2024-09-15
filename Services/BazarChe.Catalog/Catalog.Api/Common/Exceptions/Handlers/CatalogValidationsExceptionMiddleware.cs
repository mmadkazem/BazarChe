namespace Catalog.Api.Common.Exceptions.Handlers;


public sealed class CatalogValidationsExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CatalogValidationException ex)
        {
            context.Response.StatusCode = 422;
            context.Response.Headers.Append("content-type", "application/json");
            var errorType = ToUnderscoreCase(ex.GetType().Name.Replace("Exception", string.Empty));
            var json = JsonSerializer.Serialize(new { ErrorType = errorType, ex.Message, ex.Errors });
            await context.Response.WriteAsync(json);
        }
    }
    public static string ToUnderscoreCase(string value)
        => value.Replace(" ", "_").ToLowerInvariant();
}