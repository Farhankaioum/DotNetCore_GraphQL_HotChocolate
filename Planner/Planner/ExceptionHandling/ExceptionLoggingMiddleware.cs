namespace SpendPlan.API.ExceptionHandling
{
    /// <summary>
    /// A middleware that will catch exceptions, log them, and re-throw.
    /// </summary>
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionLoggingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next request handling delegate.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public ExceptionLoggingMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<ExceptionLoggingMiddleware>();
        }

        /// <summary>
        /// Invokes the next request handling delegate, catches exceptions, logs them and re-trows.
        /// </summary>
        /// <param name="context">Th HTTP context.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the result of the asynchronous operation.
        /// </returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Message}", ex.Message);
                throw;
            }
        }
    }
}
