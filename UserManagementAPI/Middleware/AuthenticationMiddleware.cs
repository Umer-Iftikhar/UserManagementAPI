using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;
        private const string ValidToken = "my-secret-token"; // Replace with secure token or validation logic

        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                _logger.LogWarning("Missing or malformed Authorization header.");
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Missing or malformed token.");
                return;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();

            if (token != ValidToken)
            {
                _logger.LogWarning("Invalid token provided.");
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid token.");
                return;
            }

            await _next(context); // Token is valid, proceed
        }
    }
}