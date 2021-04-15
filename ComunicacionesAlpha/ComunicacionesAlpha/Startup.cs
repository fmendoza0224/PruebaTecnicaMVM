using ComunicacionesAlpha.Aplicacion;
using ComunicacionesAlpha.Aplicacion.Interfaces;
using ComunicacionesAlpha.Datos;
using ComunicacionesAlpha.Datos.Interfaces;
using ComunicacionesAlpha.Dominio;
using ComunicacionesAlpha.Dominio.Servicios.Interfaces;
using ComunicacionesAlpha.Infraestructura.Interfaces;
using ComunicacionesAlpha.Infraestructura.Models;
using ComunicacionesAlpha.Infraestructura.StoreProcedures;
using ComunicacionesAlpha.Transversal;
using ComunicacionesAlpha.Transversal.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ComunicacionesAlpha
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
            Contexto.Configuracion = Configuration.GetSection("Configuracion").Get<Configuracion>();

            services.AddControllers();
            services.AddScoped<IRegistroCorrespondenciaAplicacion, RegistroCorrespondenciaAplicacion>();
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
            services.AddScoped<IRegistroCorrespondenciaDominio, RegistroCorrespondenciaDominio>();
            services.AddScoped<ILog, Log>();
            services.AddScoped<IRegistroCorrespondenciaSP, RegistroCorrespondenciaSP>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{GetAssemblyVersion()}", new OpenApiInfo
                {
                    Version = $"v{GetAssemblyVersion()}",
                    Title = "Api Comunicaciones Alpha",
                    Description = "Servicio encargado de administrar la correspondencia de los clientes."
                });
                c.ResolveConflictingActions(x => x.First());

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<ContextoBD>(optionsBuilder =>
               optionsBuilder.UseSqlServer(Contexto.Configuracion.ConexionBaseDatos)
           );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{GetAssemblyVersion()}/swagger.json", "Api Comunicaciones Alpha");
                c.DefaultModelRendering(ModelRendering.Model);

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetAssemblyVersion()
        {
            return GetType().Assembly.GetName().Version.ToString().Substring(0, 3);
        }
    }
}
