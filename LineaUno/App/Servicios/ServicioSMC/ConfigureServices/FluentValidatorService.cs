using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicioSMC.ConfigureServices.Interface;
using ServicioSMC.ConfigureServices.NeedfulClasses.FluentValidator;

namespace ServicioSMC.ConfigureServices
{
    public class FluentValidatorService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(opt => {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
