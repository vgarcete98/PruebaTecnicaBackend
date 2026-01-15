using PruebaTecnicaBackend;
using PruebaTecnicaBackend.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

app.UseRouting();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();




app.Run();







