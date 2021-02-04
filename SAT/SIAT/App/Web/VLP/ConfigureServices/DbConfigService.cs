using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VLP.ConfigureServices.Interface;
using VLP.Models;

namespace VLP.ConfigureServices
{
    public class DbConfigService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //DBContext using SQL Server
            services.AddDbContext<BDVLPContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BDVLP")));
            //Add Identity User tables
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<BDVLPContext>();
        }
    }
}
