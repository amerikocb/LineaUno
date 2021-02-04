using Microsoft.AspNetCore.Builder;
using ServicioSMC.ConfigureApp.ExceptionMiddleware;

namespace ServicioSMC.ConfigureApp
{
    public static class ExceptionMiddlewareApp
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
