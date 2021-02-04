using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VLP.ConfigureApp;
using VLP.Installers.InstallServiceClass;

namespace VLP
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
            //Add Cors
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
        }
    }
}
