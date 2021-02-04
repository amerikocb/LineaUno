using Microsoft.AspNetCore.Builder;
using VLP.ConfigureApp.ExceptionMiddleware;

namespace VLP.ConfigureApp
{
    public static class ExceptionMiddlewareApp
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
