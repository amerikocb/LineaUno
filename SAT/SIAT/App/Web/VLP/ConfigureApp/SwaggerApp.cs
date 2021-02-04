using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLP.ConfigureApp.NeedfulClasses.Swagger;

namespace VLP.ConfigureApp
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
