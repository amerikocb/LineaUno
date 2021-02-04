using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicioSMC.ConfigureServices.Interface;
using System;
using System.Linq;

namespace ServicioSMC.ConfigureServices.InstallServiceClass
{
    public static class InstallService
    {
        public static void InstallServicesAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
