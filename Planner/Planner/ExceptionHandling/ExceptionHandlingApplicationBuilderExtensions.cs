using GlobalExceptionHandler.WebApi;

namespace SpendPlan.API.ExceptionHandling
{
    /// <summary>
    /// Provides extension methods for <see cref="IApplicationBuilder"/> to add custom exception handling.
    /// </summary>
    public static class ExceptionHandlingApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds custom exception handling to the application request handling pipeline.
        /// </summary>
        /// <param name="app">The application request handling pipeline builder.</param>
        public static void AddCustomExceptionHandling(this IApplicationBuilder app)
        {
            var hostingEnvironment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            app.UseGlobalExceptionHandler(x =>
            {
                ConfigureResponseBody(x, hostingEnvironment);
                ConfigureExceptionBehavior(x);
            });

            app.UseExceptionLogging();
        }

        private static void ConfigureResponseBody(
           ExceptionHandlerConfiguration configuration,
           IWebHostEnvironment hostingEnvironment)
        {
            var isDevelopment = hostingEnvironment.IsDevelopment();

            ErrorResponse ExceptionFormatter(Exception e)
            {
                return ProvideBaseError(e, isDevelopment);
            }

            configuration.ObjectResponseBody(ExceptionFormatter);
        }

        private static void ConfigureExceptionBehavior(ExceptionHandlerConfiguration configuration)
        {
            configuration.ContentType = "application/json";
        }

        private static void UseExceptionLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionLoggingMiddleware>();
        }

        private static ErrorResponse ProvideBaseError(Exception ex, bool isDevelopment)
        {
            return new ErrorResponse
            {
                Messages = new[] { ex.Message },
                DeveloperMessage = isDevelopment ? ex.ToString() : null,
            };
        }
    }
    public class ErrorResponse
    {
        public IReadOnlyCollection<string>? Messages { get; set; }

        public string? DeveloperMessage { get; set; }
    }
}
