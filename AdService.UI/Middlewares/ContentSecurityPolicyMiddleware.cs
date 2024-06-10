namespace AdService.UI.Middlewares;

public class ContentSecurityPolicyMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ContentSecurityPolicyMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task Invoke(HttpContext context)
    {
        if(!context.Response.Headers.ContainsKey("Content-Security-Policy"))
        {
            context.Response.Headers.Add("Content-Security-Policy",
                "object-src 'self';" +
                "img-src 'self';");
            await _requestDelegate(context);
        }
    }
}