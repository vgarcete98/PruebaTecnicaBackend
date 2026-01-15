using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configuración (opcional, ya se carga por defecto)
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Servicios
builder.Services.AddDbContext<DbContextPTecnica>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Migraciones automáticas al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DbContextPTecnica>();
    db.Database.EnsureCreated(); // <- crea la DB y tablas si no existen
}

// Middleware
app.UseRouting();
app.UseMiddleware<ApiKeyMiddleware>();

// Endpoints
app.MapControllers();

app.Run();
