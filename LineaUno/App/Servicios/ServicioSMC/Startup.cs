using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServicioSMC.ConfigureApp;
using ServicioSMC.ConfigureServices.InstallServiceClass;
using System.Threading.Tasks;

namespace ServicioSMC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.InstallServicesAssembly(Configuration);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.ConfigureSwaggerOptions(Configuration);

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.ConfigureCustomExceptionMiddleware();

            app.UseMvc();

            // Redirect to Swagger's Start Page
            app.Run(context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
        }
    }
}
