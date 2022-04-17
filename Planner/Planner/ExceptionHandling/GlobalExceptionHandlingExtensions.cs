using GlobalExceptionHandler.ContentNegotiation.Mvc;
using GlobalExceptionHandler.WebApi;

namespace SpendPlan.API.ExceptionHandling
{
    /// <summary>
    /// Provides extension methods for <see cref="ExceptionHandlerConfiguration"/>.
    /// </summary>
    public static class GlobalExceptionHandlingExtensions
    {
        /// <summary>
        /// Specifies response formatter with data transfer object to be used for global exception handling.
        /// </summary>
        /// <param name="configuration">The exception handler configuration.</param>
        /// <param name="formatter">The error formatter.</param>
        /// <typeparam name="T">The type of data transfer object to be returned.</typeparam>
        public static void ObjectResponseBody<T>(
            this ExceptionHandlerConfiguration configuration,
            Func<Exception, T> formatter)
        {
            Task Formatter(
                Exception exception,
                HttpContext httpContext,
                HandlerContext handlerContext)
            {
                httpContext.Response.ContentType = null!;
                httpContext.WriteAsyncObject(formatter(exception));

                return Task.CompletedTask;
            }

            configuration.ResponseBody(Formatter);
        }
    }
}
