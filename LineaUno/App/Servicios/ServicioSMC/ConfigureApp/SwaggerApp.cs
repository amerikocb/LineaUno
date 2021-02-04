using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ServicioSMC.ConfigureApp.NeedfulClasses.Swagger;
using System.Threading.Tasks;

namespace ServicioSMC.ConfigureApp
{
    public static class SwaggerApp
    {
        public static void ConfigureSwaggerOptions(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerOptions = new SwaggerOptions();
            configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description); });

            
        }
    }
}
