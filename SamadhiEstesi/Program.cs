using Microsoft.EntityFrameworkCore;
using SamadhiEstesi.Data;  // Asegúrate de que esta es la ruta correcta para tu DbContext

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión desde el archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar DbContext con la cadena de conexión a los servicios
builder.Services.AddDbContext<sistema_gestion_completoContext>(options =>
    options.UseSqlServer(connectionString));

// Otros servicios de la aplicación
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
