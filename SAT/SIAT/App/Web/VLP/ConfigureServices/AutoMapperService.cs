using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VLP.ConfigureServices.Interface;
using VLP.ConfigureServices.NeedfulClasses.AutoMapper;

namespace VLP.ConfigureServices
{
    public class AutoMapperService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
        }
    }
}
