using System.Diagnostics;

namespace Matrimony.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Proceed to the next middleware
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                var trace = new StackTrace(ex, true);
                var frame = trace.GetFrame(0);
                var fileName = frame?.GetFileName();
                var lineNumber = frame?.GetFileLineNumber();

                _logger.LogError("Message :" + message + " | File name :" + fileName + " | Line no : " + lineNumber);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                if (!_env.IsProduction())
                {
                    var errorResponse = new
                    {
                        Detail = "Message :" + message + " | File name :" + fileName + " | Line no : " + lineNumber// ⚠️ Avoid showing this in production
                    };
                    await context.Response.WriteAsJsonAsync(errorResponse);
                }
            }
        }
    }

}
