using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<DbContextPTecnica>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

app.UseRouting();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();




app.Run();







