# Configuración de SQL Server para el Backend

## Requisitos previos
1. SQL Server instalado (Developer Edition o Express)
2. Visual Studio o Visual Studio Code con las extensiones de .NET

## Pasos para configurar la base de datos

### 1. Conexión a SQL Server
La aplicación está configurada para conectarse a SQL Server con la siguiente cadena de conexión:
```
Server=localhost;Database=ProductManagementDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true
```

Si estás utilizando SQL Server Express u otra instancia con nombre, debes modificar el parámetro `Server` en el archivo `appsettings.json` y `appsettings.Development.json` a algo como:
```
Server=localhost\\SQLEXPRESS;
```

### 2. Creación de la base de datos
Tienes dos opciones para crear la base de datos:

#### Opción 1: Ejecutar el script SQL
Ejecuta el script de migración ubicado en la carpeta `Backend/Migrations/InitialMigration.sql` en SQL Server Management Studio o Azure Data Studio.

#### Opción 2: Usar Entity Framework Core
Abre una terminal en la carpeta `Backend/ProductManagement.API` y ejecuta:
```
dotnet ef migrations add InitialMigration
dotnet ef database update
```

Nota: Para usar este método, debes tener instalada la herramienta `dotnet-ef`:
```
dotnet tool install --global dotnet-ef
```

### 3. Ejecutar la aplicación
1. Abre una terminal en la carpeta `Backend/ProductManagement.API`
2. Ejecuta el comando:
```
dotnet run
```

La API estará disponible en `https://localhost:7001` y `http://localhost:3001`.

### 4. Verificar la conexión
Abre un navegador y accede a `https://localhost:7001/swagger` para ver la documentación de la API y probar los endpoints.

## Cambiar la configuración

### Puerto del servidor
Por defecto, la API está configurada para usar el puerto 3001. Si necesitas cambiar esto, puedes modificar el archivo `Properties/launchSettings.json`.

### Configuración de CORS
Por defecto, CORS está configurado para permitir solicitudes desde `http://localhost:5173` (servidor de desarrollo de Vue.js). Si tu frontend está utilizando un puerto diferente, modifica esta configuración en el archivo `Program.cs`. 