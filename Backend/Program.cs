using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la contenedor
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Agregar documentación API con Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de la base de datos SQLite para desarrollo
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS para permitir solicitudes del frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Construir la aplicación
var app = builder.Build();

// Asegurar que la base de datos se crea y se actualiza
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configurar el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    // No redirigir a HTTPS en desarrollo
}
else
{
    // Solo usar HTTPS redirect en producción
    app.UseHttpsRedirection();
}

// Habilitar CORS
app.UseCors("AllowVueApp");

app.UseAuthorization();
app.MapControllers();

app.Run();
