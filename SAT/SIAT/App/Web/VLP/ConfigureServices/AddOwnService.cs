using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VLP.ConfigureServices.Interface;
using VLP.Services;
using VLP.Services.Interfaces;

namespace VLP.ConfigureServices
{
    public class AddOwnService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITabContribuyenteService, TabContribuyenteService>();
            services.AddScoped<ITabInstitucionService, TabInstitucionService>();
            services.AddScoped<ITabCatBeneficioService, TabCatBeneficioService>();
            services.AddScoped<ITabBeneficioService, TabBeneficioService>();
            services.AddScoped<ITabUsuarioService, TabUsuarioService>();
        }
    }
}
