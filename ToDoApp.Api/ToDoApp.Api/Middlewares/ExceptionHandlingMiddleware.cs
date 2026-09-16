using System.Net;
using ToDoApp.Services.Exceptions;

namespace ToDoApp.Api.Middlewares
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate next;
        public ExceptionHandling(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ToDoAppBaseExeption ex)
            {
                context.Response.StatusCode = (int)ex.GetStatusCode();
                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
            }

        }
    }
}
