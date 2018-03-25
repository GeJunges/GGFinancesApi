using System;
using System.Net;
using System.Threading.Tasks;
using FinancesApi.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FinancesApi.Middlewares {
    public class StatusCodePagesMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILoggerWrapper _logger;

        public StatusCodePagesMiddleware(RequestDelegate next, ILoggerWrapper logger) {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext) {
            try {
                await _next(httpContext);

                if (!httpContext.Request.Path.Value.StartsWith("/api")) {
                    return;
                }

                var statusCode = httpContext.Response.StatusCode;

                if (StatusCodeToHandleError(statusCode)) {
                    _logger.Info($"Error: {statusCode} happend");
                    await CreateResponse(httpContext, statusCode);
                }
            } catch (Exception ex) {
                _logger.Error($"Error: {ex.Message}");
                throw;
            }
        }

        private static bool StatusCodeToHandleError(int statusCode) {
            return statusCode == StatusCodes.Status404NotFound
                || statusCode == StatusCodes.Status401Unauthorized;
        }

        private static async Task CreateResponse(HttpContext httpContext, int statusCode) {
            var description = ((HttpStatusCode)statusCode).ToString();
            var response = JsonConvert.SerializeObject(description);

            await httpContext.Response.WriteAsync(response);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HttpStatusCodeExceptionExtensions {
        public static IApplicationBuilder UseStatusCodePagesMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<StatusCodePagesMiddleware>();
        }
    }
}