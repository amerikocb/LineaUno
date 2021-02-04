using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ServicioSMC.ConfigureApp.ExceptionMiddleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(
                new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Mensaje = "Error interno del servidor."
                }.ToString());
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //Log.Error($"Mensaje : {ex.Message} - Detalles: {ex.InnerException}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
    }
}
