# Instrucciones para ejecutar el proyecto

A continuación se detallan los pasos necesarios para ejecutar el proyecto y conectarlo a SQL Server Developer Edition:

## Paso 1: Verificar SQL Server

Asegúrate que SQL Server esté funcionando correctamente en tu máquina. Puedes verificarlo abriendo SQL Server Management Studio y conectándote a tu instancia local.

## Paso 2: Crear la base de datos

Ejecuta el script de migración inicial para crear la base de datos y tablas:

1. Abre SQL Server Management Studio
2. Conéctate a tu instancia local de SQL Server
3. Abre el archivo `Backend/Migrations/InitialMigration.sql`
4. Ejecuta el script completo

Este script creará la base de datos `ProductManagementDB` con la tabla `Products` y algunos datos iniciales.

## Paso 3: Iniciar el backend

1. Abre una terminal en la carpeta raíz del proyecto
2. Navega a la carpeta del proyecto API con el siguiente comando:
   ```
   cd Backend\ProductManagement.API
   ```
3. Ejecuta el siguiente comando para iniciar el backend:
   ```
   dotnet run
   ```
4. La API estará disponible en `https://localhost:7001` y `http://localhost:3001`

**Importante**: El comando `dotnet run` debe ejecutarse específicamente desde la carpeta `Backend/ProductManagement.API`, no desde la carpeta raíz del proyecto.

## Paso 4: Iniciar el frontend

1. Abre otra terminal en la carpeta raíz del proyecto
2. Instala las dependencias con el comando:
   ```
   npm install
   ```
3. Inicia el servidor de desarrollo:
   ```
   npm run dev
   ```
4. El frontend estará disponible en la URL que se muestra en la terminal (generalmente `http://localhost:5173`)

## Paso 5: Verificar el funcionamiento

1. Abre tu navegador y navega a la URL del frontend
2. Deberías ver la interfaz de usuario del Sistema de Gestión de Productos
3. La aplicación debería poder comunicarse con el backend y mostrar los productos almacenados en la base de datos

## Notas adicionales

- La conexión a la base de datos está configurada en el archivo `Backend/ProductManagement.API/appsettings.json`
- Si necesitas cambiar la cadena de conexión, modifica el valor de `DefaultConnection` en este archivo
- El proyecto utiliza Entity Framework Core para la comunicación con la base de datos
