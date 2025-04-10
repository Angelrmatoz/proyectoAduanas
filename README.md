# Sistema de Gestión de Productos y Ventas

## Descripción
Sistema de gestión empresarial desarrollado con .NET Core y Vue.js para la administración de productos, ventas y clientes.

## Tecnologías Utilizadas

### Backend
- .NET Core
- SQL Server
- Entity Framework Core
- JWT para autenticación
- xUnit para pruebas unitarias

### Frontend
- Vue.js 3 (Composition API)
- TypeScript
- Pinia para gestión de estado
- Axios para consumo de API
- Vite como bundler
- Tailwind CSS para estilos

## Estructura del Proyecto

### Backend
```
Backend/
├── Controllers/         # Controladores de la API
├── Services/           # Lógica de negocio
├── Repositories/       # Acceso a datos
├── Models/            # Modelos de datos
├── DTOs/              # Objetos de transferencia de datos
├── Helpers/           # Utilidades y helpers
├── Middleware/        # Middleware personalizado
└── Tests/             # Pruebas unitarias
```

### Frontend
```
Frontend/
├── src/
│   ├── api/           # Servicios de API
│   ├── components/    # Componentes Vue
│   ├── composables/   # Hooks personalizados
│   ├── constants/     # Constantes
│   ├── layouts/       # Layouts de la aplicación
│   ├── router/        # Configuración de rutas
│   ├── stores/        # Stores de Pinia
│   ├── types/         # Tipos TypeScript
│   ├── utils/         # Utilidades
│   └── views/         # Vistas de la aplicación
```

## Instalación y Configuración

### Requisitos Previos
- .NET Core SDK 6.0 o superior
- SQL Server
- Node.js 16.x o superior
- npm o yarn

### Backend
1. Clonar el repositorio
2. Abrir la solución en Visual Studio o VS Code
3. Configurar la cadena de conexión en `appsettings.json`
4. Ejecutar las migraciones:
   ```bash
   dotnet ef database update
   ```
5. Ejecutar el proyecto:
   ```bash
   dotnet run
   ```

### Frontend
1. Navegar al directorio del frontend:
   ```bash
   cd Frontend
   ```
2. Instalar dependencias:
   ```bash
   npm install
   ```
3. Iniciar el servidor de desarrollo:
   ```bash
   npm run dev
   ```

## Modelo de Datos

### Productos
- ID
- Nombre
- Descripción
- Precio
- Stock

### Ventas
- ID
- Fecha
- Cliente
- Lista de Productos
- Total

### Clientes
- ID
- Nombre
- Email
- Teléfono

## Características Principales
- Gestión CRUD de productos
- Registro y seguimiento de ventas
- Gestión de clientes
- Autenticación y autorización basada en JWT
- Interfaz responsiva
- Validaciones de formularios
- Manejo de errores
- Pruebas unitarias

## Contribución
1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Licencia
Este proyecto está bajo la Licencia MIT.
