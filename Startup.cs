using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyPage1.Servicios;

namespace ProyPage1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            /*
            services.AddSingleton<Model.Profesor>();

            //registrarse como un servicio Scoped para que cada usuario diferente reciba su propia instancia del servicio durante la duración de su sesión. .
            //Un Singleton permite compartir la misma instancia de una clase de servicio entre componentes. 
            //Esto es bueno porque desea asegurarse de que todas sus páginas reciban la misma instancia de la clase de servicio Profesor. 
            //Esto garantizará que los datos (es decir, Legajo, en este ejemplo) se compartan correctamente entre las páginas a lo largo de la vida útil de la aplicación.
            services.AddScoped<Model.Profesor>();*/

            services.AddSingleton<IProfesorServicio,ProfesorServicio>();
            //services.AddScoped<Model.Datos>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
