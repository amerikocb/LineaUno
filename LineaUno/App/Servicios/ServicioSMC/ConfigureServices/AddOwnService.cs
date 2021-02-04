using LineaUno.App.Servicios.Contratos.SMC.v1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicioSMC.ConfigureServices.Interface;
using ServicioSMC.v1.Controllers;

namespace ServicioSMC.ConfigureServices
{
    public class AddOwnService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDomUsuarioService, DomUsuarioController>();
            services.AddScoped<IMcmaeCargaForDosService, McmaeCargaForDosController>();
        }
    }
}
