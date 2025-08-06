namespace UserManagementAPI.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;

            _logger.LogInformation("Incoming Request: {Method} {Path}", method, path);

            // Capture the response status code after the next middleware runs
            await _next(context);

            var statusCode = context.Response.StatusCode;
            _logger.LogInformation("Outgoing Response: {StatusCode} for {Method} {Path}", statusCode, method, path);
        }
    }
}
