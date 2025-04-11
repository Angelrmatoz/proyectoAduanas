# Backend del Sistema de Gestión de Productos

## Arquitectura y Estructura

Este backend implementa una API RESTful desarrollada con ASP.NET Core 8.0 siguiendo principios de Clean Architecture y Domain-Driven Design (DDD). La aplicación está estructurada para permitir un fácil mantenimiento, testabilidad y escalabilidad.

### Capas de la Aplicación

1. **Controllers**: Endpoints de la API que reciben solicitudes HTTP y devuelven respuestas.
2. **DTOs**: Objetos de transferencia de datos para la comunicación con el cliente.
3. **Models**: Entidades de dominio con reglas de validación.
4. **Data**: Acceso a datos mediante Entity Framework Core.
5. **Migrations**: Scripts de cambios en la estructura de la base de datos.

### Tecnologías Implementadas

- **ASP.NET Core 8.0**: Framework moderno para desarrollar APIs.
- **Entity Framework Core**: ORM para acceso a datos.
- **SQLite**: Base de datos relacional liviana para desarrollo.
- **Swagger/OpenAPI**: Documentación interactiva de la API.
- **AutoMapper**: Mapeo de objetos entre capas (si aplicable).

## Modelo de Datos

### Entidad `Product`

```csharp
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    [Range(0.01, 10000.00)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Required]
    public int Stock { get; set; }

    public string Category { get; set; }

    public string ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
```

### DTOs

Se utilizan tres tipos de DTOs principales:

1. **ProductDTO**: Para respuestas con todos los datos del producto
2. **CreateProductDTO**: Para creación de nuevos productos
3. **UpdateProductDTO**: Para actualización parcial de productos existentes

## Configuración y Ejecución

### Requisitos previos

1. **.NET SDK 8.0** o superior instalado
2. **SQLite** instalado (para desarrollo) o **SQL Server** (para producción)
3. **Visual Studio 2022**, **Visual Studio Code** o **Rider** (opcional)

### Pasos para la configuración

#### 1. Configuración de la base de datos

La aplicación está configurada para usar SQLite por defecto para desarrollo, con la siguiente cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=products.db"
}
```

Para cambiar a SQL Server, modifica la cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ProductManagementDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

Y actualiza el registro del contexto en `Program.cs`:

```csharp
// Para SQLite
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

// Para SQL Server
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```

#### 2. Migración de la base de datos

Para crear la base de datos desde cero:

```bash
# Instalar la herramienta de EF Core (si no está instalada)
dotnet tool install --global dotnet-ef

# Crear una migración inicial (si no existe)
dotnet ef migrations add InitialCreate

# Aplicar la migración a la base de datos
dotnet ef database update
```

Alternativamente, la base de datos se creará automáticamente al iniciar la aplicación gracias al código en `Program.cs`:

```csharp
// Asegurar que la base de datos se crea y se actualiza
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}
```

#### 3. Ejecución del proyecto

```bash
# Navegar a la carpeta del proyecto
cd Backend

# Restaurar dependencias
dotnet restore

# Ejecutar el proyecto
dotnet run
```

La API estará disponible en:

- HTTP: http://localhost:5048
- HTTPS: https://localhost:7048 (si está habilitado)

### Swagger / OpenAPI

La documentación interactiva de la API está disponible en:

- http://localhost:5048/swagger

## Endpoints de la API

| Método HTTP | Ruta                 | Descripción                   | Parámetros/Cuerpo                |
| ----------- | -------------------- | ----------------------------- | -------------------------------- |
| GET         | `/api/products`      | Listar todos los productos    | -                                |
| GET         | `/api/products/{id}` | Obtener producto por ID       | `id`: ID del producto            |
| POST        | `/api/products`      | Crear nuevo producto          | Objeto `CreateProductDTO`        |
| PUT         | `/api/products/{id}` | Actualizar producto existente | `id` + Objeto `UpdateProductDTO` |
| DELETE      | `/api/products/{id}` | Eliminar producto             | `id`: ID del producto            |

## CORS (Cross-Origin Resource Sharing)

La API está configurada para permitir solicitudes de orígenes cruzados desde el frontend. La configuración se encuentra en `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ...

app.UseCors("AllowVueApp");
```

Para un entorno de producción, es recomendable restringir los orígenes permitidos:

```csharp
policy.WithOrigins("https://tu-dominio-frontend.com")
      .AllowAnyHeader()
      .AllowAnyMethod();
```

## Manejo de Errores

La API implementa manejo de errores global a través de middleware para proporcionar respuestas consistentes. Los códigos de estado HTTP utilizados son:

- **200 OK**: Operación exitosa con datos devueltos
- **201 Created**: Recurso creado exitosamente
- **204 No Content**: Operación exitosa sin datos para devolver
- **400 Bad Request**: Solicitud mal formada o datos inválidos
- **404 Not Found**: Recurso no encontrado
- **500 Internal Server Error**: Error del servidor

## Buenas Prácticas y Convenciones

1. **Validación de Datos**: Las validaciones se aplican mediante Data Annotations en DTOs y modelos.
2. **Respuestas HTTP Adecuadas**: Uso de códigos de estado HTTP apropiados para cada situación.
3. **Principio de Responsabilidad Única**: Cada clase tiene una única responsabilidad.
4. **Nombrado Descriptivo**: Nombres claros para clases, métodos y variables.
5. **Comentarios y Documentación**: Código comentado utilizando comentarios XML para Swagger.

## Desarrollo y Extensión

### Añadir un Nuevo Modelo

1. Crear la clase de entidad en `Models/`
2. Agregar DbSet en `ApplicationDbContext`
3. Crear DTOs correspondientes en `DTOs/`
4. Crear el controlador en `Controllers/`
5. Generar y aplicar migraciones

### Pruebas

Se recomienda implementar pruebas unitarias para:

- Controllers
- Validaciones de modelos
- Lógica de negocio

## Solución de Problemas Comunes

### Error de conexión a la base de datos

- Verificar cadena de conexión en `appsettings.json`
- Asegurar que SQLite o SQL Server está instalado y accesible
- Comprobar permisos de acceso a la base de datos

### Errores CORS

- Verificar que las URLs del frontend coinciden con las configuradas en CORS
- Comprobar si hay errores de preflight (OPTIONS)

### Problemas de migración

- Eliminar la base de datos actual y volver a aplicar las migraciones
- Actualizar el esquema: `dotnet ef database update`
