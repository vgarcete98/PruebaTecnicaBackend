using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Middleware;

namespace PruebaTecnicaBackend
{
    public class Startup
    {

        public Startup( IConfiguration configuration ) { 
        
            Configuration  = configuration;
        
        }


        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            try
            {
                //CONFIGURACION DE LA BASE DE DATOS
                //-----------------------------------------------------------------------------------------------------
                services.AddDbContext<DbContextPTecnica>(options => {
                    options.UseSqlite("Data Source=PruebaTecnicaBackend.db");
				});
                //-----------------------------------------------------------------------------------------------------


                services.AddEndpointsApiExplorer();

                //-----------------------------------------------------------------------------------------------------



                //AÑADO LA CONFIGURACION PARA CORS, ASI PARA QUE SE PUEDAN REALIZAR SOLICITUDES DESDE EL NAVEGADOR
                //-----------------------------------------------------------------------------------------------------
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(  builder =>
                    {
                        builder.WithOrigins("AllowAll")
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
                });
                //-----------------------------------------------------------------------------------------------------


                services.AddAuthorization();
                services.AddControllers();


            }
            catch (Exception ex )
            {
                Console.WriteLine($"Ha ocurrido un error al realizar la configuracion los servicios {ex.Message}");
            }
        }


        public void Configure (  IApplicationBuilder app, IWebHostEnvironment env)
        {

            try
            {

                // YA ESTA AQUI LA VALIDACION PARA QUE SIEMPRE ACEPTE UN TOKEN API

                app.UseMiddleware<ApiKeyMiddleware>();

				app.UseRouting();

                app.UseCors("");

                app.UseAuthentication();

            }
            catch (Exception ex)
            {
                Console.WriteLine( $"Ha ocurrido un error al realizar la configuracion de la aplicacion {ex.Message}" );
            }


        }





    }
}
