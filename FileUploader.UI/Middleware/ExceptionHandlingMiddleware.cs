using FileUploader.Core.Domain.Entities;
using FileUploader.Infrastructure.DbContext;

namespace FileUploader.UI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            await LogExceptionToDatabase(e);

            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var result = new { message = "An unexpected error occurred. Pleast try again later" };
            await context.Response.WriteAsJsonAsync(result);
        }

        private async Task LogExceptionToDatabase(Exception e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<LogDbContext>();
                var log = new ExceptionLog
                {
                    Message = e.Message,
                    StackTrace = e.StackTrace,
                    EventType = "Error",
                    ApplicationName = "FileUploaderWeb",
                    CreatedDateTime = DateTime.Now
                };
                db.ExceptionLogs.Add(log);
                await db.SaveChangesAsync();
            }
        }

    }
}
