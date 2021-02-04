using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using VLP.ConfigureServices.Interface;

namespace VLP.ConfigureServices
{
    public class SwaggerService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "VLP API", Version = "v1" });

                //Part to Add JWT in Swagger
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[0] }
                };

                x.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Cabecera de autorizacion JWT usando el esquema bearer",
                    Name = "Autorización",
                    In = "header",
                    Type = "apiKey"
                });

                x.AddSecurityRequirement(security);
            });
        }
    }
}
