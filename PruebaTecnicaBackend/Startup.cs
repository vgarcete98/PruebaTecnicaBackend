using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaBackend.Application.Addresses.Commands.CreateUserAddresses;
using PruebaTecnicaBackend.Application.Addresses.Commands.DeleteAddresses;
using PruebaTecnicaBackend.Application.Addresses.Commands.UpdateAddresses;
using PruebaTecnicaBackend.Application.Addresses.Queries.GetAddressesUser;
using PruebaTecnicaBackend.Application.Currencies.Commands.CreateCurrencies;
using PruebaTecnicaBackend.Application.Currencies.Queries.GetCurrencies;
using PruebaTecnicaBackend.Application.CurrencyConversion;
using PruebaTecnicaBackend.Application.Users.Commands.CreateUser;
using PruebaTecnicaBackend.Application.Users.Commands.DeleteUser;
using PruebaTecnicaBackend.Application.Users.Commands.UpdateUser;
using PruebaTecnicaBackend.Application.Users.Queries.GetUserById;
using PruebaTecnicaBackend.Application.Users.Queries.GetUsers;
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


                //PARA EL ENDPOINT DE USUARIOS
				services.AddScoped<CreateUserCommandHandler>();
				services.AddScoped<UpdateUserCommandHandler>();
				services.AddScoped<DeleteUserCommandHandler>();
				services.AddScoped<GetUserByIdQueryHandler>();
				services.AddScoped<GetUsersQueryHandler>();
				services.AddScoped<GetAddressesUserQueryHandler>();
				services.AddScoped<CreateUserAddressesCommandHandler>();

				//PARA LO QUE SERIA DIRECCIONES

				services.AddScoped<DeleteAddressesCommandHandler>();
				services.AddScoped<UpdateAddressesCommandHandler>();

				//PARA LA CONVERSION DE DIVISAS

				services.AddScoped<GetCurrenciesQueryHandler>();
				services.AddScoped<CreateCurrenciesCommandHandler>();
				services.AddScoped<CurrencyConversionCommandHandler>();



			}
            catch (Exception ex )
            {
                Console.WriteLine($"Ha ocurrido un error al realizar la configuracion los servicios {ex.Message}");
            }
        }


    }
}
