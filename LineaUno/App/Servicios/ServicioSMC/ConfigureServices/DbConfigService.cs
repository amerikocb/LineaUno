using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicioSMC.ConfigureServices.Interface;

namespace ServicioSMC.ConfigureServices
{
    public class DbConfigService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //DBContext using SQL Server
            services.AddDbContext<BDLINEAUNOContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BD")));
            //Add Identity User tables
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<BDLINEAUNOContext>();
        }
    }
}
