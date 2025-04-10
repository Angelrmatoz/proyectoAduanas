-- Crear base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ProductManagementDB')
BEGIN
    CREATE DATABASE ProductManagementDB;
END
GO

USE ProductManagementDB;
GO

-- Eliminar tabla si existe
IF OBJECT_ID('Products', 'U') IS NOT NULL
BEGIN
    DROP TABLE Products;
END
GO

-- Tabla de Productos
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL,
    Category NVARCHAR(50) NULL,
    ImageUrl NVARCHAR(255) NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETUTCDATE()
);
GO

-- Agregar datos iniciales
INSERT INTO Products (Name, Description, Price, Stock, Category, CreatedAt, UpdatedAt)
VALUES 
('Laptop Acer', 'Laptop Acer con procesador i5, 8GB RAM, 512GB SSD', 799.99, 10, 'Electrónicos', GETUTCDATE(), GETUTCDATE()),
('Monitor LG', 'Monitor LG 24 pulgadas, Full HD', 199.99, 15, 'Electrónicos', GETUTCDATE(), GETUTCDATE()),
('Teclado mecánico', 'Teclado mecánico con retroiluminación RGB', 59.99, 30, 'Accesorios', GETUTCDATE(), GETUTCDATE()),
('Mouse inalámbrico', 'Mouse inalámbrico ergonómico', 29.99, 25, 'Accesorios', GETUTCDATE(), GETUTCDATE()),
('Disco duro externo', 'Disco duro externo 1TB USB 3.0', 79.99, 20, 'Almacenamiento', GETUTCDATE(), GETUTCDATE());
GO 