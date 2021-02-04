using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicioSMC.ConfigureServices.Interface;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper;
using System.Reflection;

namespace ServicioSMC.ConfigureServices
{
    public class AutoMapperService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
        }
    }
}
