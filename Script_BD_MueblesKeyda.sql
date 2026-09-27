USE master;
GO

IF EXISTS(select * from sys.databases where name='MueblesKeyda')
BEGIN
    ALTER DATABASE MueblesKeyda SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MueblesKeyda;
END
GO

CREATE DATABASE MueblesKeyda;
GO

USE MueblesKeyda;
GO

CREATE TABLE Usuario
(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Contraseña VARCHAR(255) NOT NULL,
    Correo VARCHAR(150) NOT NULL UNIQUE,
    IdRol INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Usuario_Rol
    FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)
);

GO

CREATE TABLE RecuperacionContraseña
(
    IdRecuperacion INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    Codigo VARCHAR(6) NOT NULL,
    FechaGeneracion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaExpiracion DATETIME NOT NULL,
    Usado BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Recuperacion_Usuario
    FOREIGN KEY (IdUsuario)
    REFERENCES Usuario(IdUsuario)
);


SELECT * FROM Usuario
GO
--------------------------------------------------------
ALTER TABLE Usuario
ADD Nombre VARCHAR(100) NOT NULL DEFAULT '';

ALTER TABLE Usuario
ADD Rol VARCHAR(20) NOT NULL DEFAULT '';

ALTER TABLE Usuario
ADD Estado BIT NOT NULL DEFAULT 1;

ALTER TABLE Usuario
ALTER COLUMN Contraseña VARCHAR(64) NOT NULL;

ALTER TABLE Usuario
ADD CONSTRAINT CK_Usuario_Rol
CHECK (Rol IN ('Administrador','Secretario'));

ALTER TABLE Usuario
ADD Nombre VARCHAR(100) NOT NULL DEFAULT '';

ALTER TABLE Usuario
ADD Rol VARCHAR(20) NOT NULL DEFAULT '';

ALTER TABLE Usuario
ADD Estado BIT NOT NULL DEFAULT 1;

ALTER TABLE Usuario
ADD CONSTRAINT CK_Usuario_Rol
CHECK (Rol IN ('Administrador', 'Secretario'));

CREATE TABLE TipoCliente
(
    IdTipoCliente INT IDENTITY(1,1) PRIMARY KEY,
    TipoCliente VARCHAR(15) NOT NULL
);
GO

CREATE TABLE Cliente
(
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    IdTipoCliente INT NOT NULL,
    Identificador1 VARCHAR(40),
    Identificador2 VARCHAR(40),
    Documento VARCHAR(30) NOT NULL,
    Telefono VARCHAR(9) NOT NULL UNIQUE, 
    Correo VARCHAR(40) UNIQUE,
    Direccion VARCHAR(200) NOT NULL,
    Estado VARCHAR(10) NOT NULL DEFAULT 'Activo'
        CHECK (Estado IN ('Activo', 'Inactivo')),

    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Cliente_TipoCliente
        FOREIGN KEY (IdTipoCliente)
        REFERENCES TipoCliente(IdTipoCliente),

    CONSTRAINT UNICO_Cliente_Tipo_Documento
        UNIQUE (IdTipoCliente, Documento)
);
GO
GO

CREATE TABLE Categoria
(
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Categoria VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200),
    Estado VARCHAR(10) NOT NULL
    CHECK (Estado IN ('Activa', 'Inactiva')),
);
GO

CREATE TABLE UnidadMedida
(
     IdUnidadMedida INT IDENTITY (1,1) PRIMARY KEY,
     UnidadMedida VARCHAR (15) NOT NULL
);
GO

CREATE TABLE Material
(
    IdMaterial INT IDENTITY(1,1) PRIMARY KEY,
    NombreDelMaterial VARCHAR(100) NOT NULL,
    IdUnidadDeMedida INT NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Categoria INT,

    CONSTRAINT Material_Stock
        CHECK (Stock >= 0),

    CONSTRAINT FK_Material_Unidad
        FOREIGN KEY (IdUnidadDeMedida)
        REFERENCES UnidadMedida(IdUnidadMedida),

    CONSTRAINT FK_Material_Categoria
        FOREIGN KEY (Categoria)
        REFERENCES Categoria(IdCategoria)
);
GO

CREATE TABLE Proveedor
(
    IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Proveedor VARCHAR(50) NOT NULL,
    Telefono VARCHAR(9) NOT NULL UNIQUE,
    Correo VARCHAR(100) NOT NULL UNIQUE,
    Ubicacion VARCHAR(200) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);

GO


CREATE OR ALTER VIEW dbo.VerProveedores AS
SELECT IdProveedor, Nombre_Proveedor AS Proveedor, Telefono, Correo, Ubicacion,
    CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
FROM dbo.Proveedor;
GO

CREATE TABLE Compras
(
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    FechaCompra DATE NOT NULL,
    TotalCompra DECIMAL(10,2) NOT NULL,
    IdProveedor INT NOT NULL,

    FOREIGN KEY (IdProveedor)
        REFERENCES Proveedor(IdProveedor)
);
GO


CREATE TABLE DetalleCompraMaterial
(
    IdDetalleCompraMaterial INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT NOT NULL,
    IdMaterial INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (IdCompra)
        REFERENCES Compras(IdCompra),

    FOREIGN KEY (IdMaterial)
        REFERENCES Material(IdMaterial)
);
GO

CREATE TABLE Cotizacion
(
    IdCotizacion INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    IdCliente INT NOT NULL,
    CondicionPago VARCHAR(200) NOT NULL,
    CondicionEntrega VARCHAR(200) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    Estado VARCHAR(15) NOT NULL
        CHECK (Estado IN ('Aprobada', 'Pendiente', 'Rechazada', 'Finalizada')),
    IdUsuario INT NOT NULL,

    FOREIGN KEY (IdCliente)
        REFERENCES Cliente(IdCliente),

    FOREIGN KEY (IdUsuario)
        REFERENCES Usuario(IdUsuario)
);
GO

CREATE TABLE Productos_Cotizacion
(
    IdProductosCotizacion INT IDENTITY(1,1) PRIMARY KEY,
    DescripcionMueble TEXT NOT NULL,
    Largo INT NOT NULL,
    Ancho INT NOT NULL,
    Alto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL,
    IdCotizacion INT NOT NULL,

    FOREIGN KEY (IdCotizacion)
        REFERENCES Cotizacion(IdCotizacion)
);
GO


CREATE TABLE Pedido
(
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    FechaDePedido DATE NOT NULL,
    FechaDeEntrega DATE NOT NULL,
    Estado VARCHAR(10) NOT NULL
    CHECK (Estado IN ('Finalizado', 'En proceso', 'Cancelado')),
    IdCotizacion INT NOT NULL,

    FOREIGN KEY (IdCotizacion)
        REFERENCES Cotizacion(IdCotizacion)
);
GO

CREATE TABLE DetallePedido
(
    IdDetallePedido INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    Mueble VARCHAR(150) NOT NULL,
    Cantidad INT NOT NULL,
    Medidas NVARCHAR(100),

    CONSTRAINT FK_DetallePedido_Pedido
        FOREIGN KEY (IdPedido)
        REFERENCES Pedido(IdPedido)
);
GO

CREATE TABLE Produccion
(
    IdProduccion INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    Progreso INT NOT NULL,

    CONSTRAINT FK_Produccion_Pedido
        FOREIGN KEY (IdPedido)
        REFERENCES Pedido(IdPedido),

    CONSTRAINT CK_Produccion_Progreso
        CHECK (Progreso BETWEEN 0 AND 100)
);
GO


CREATE TABLE MaterialUtilizado
(
    IdMaterialUtilizado INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad_Utilizada INT NOT NULL,
    IdMaterial INT NOT NULL,
    IdProduccion INT NOT NULL,

    FOREIGN KEY (IdMaterial)
        REFERENCES Material(IdMaterial),

    FOREIGN KEY (IdProduccion)
        REFERENCES Produccion(IdProduccion)
);
GO

CREATE TABLE MetodoPago
(
    IdMetodoPago INT IDENTITY(1,1) PRIMARY KEY,
    MetodoPago VARCHAR(20) NOT NULL
);
GO

CREATE TABLE Venta
(
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    FechaVenta DATE NOT NULL,
    IdCliente INT NOT NULL,
    IdMetodoPago INT NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (IdCliente)
        REFERENCES Cliente(IdCliente),
         FOREIGN KEY (IdMetodoPago)
        REFERENCES MetodoPago(IdMetodoPago)
);
GO

CREATE TABLE DetalleVenta
(
    IdDetalleVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    ProductoVendido VARCHAR(100) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (IdVenta)
        REFERENCES Venta(IdVenta)
);
GO

CREATE TABLE Factura
(
    IdFactura INT IDENTITY(1,1) PRIMARY KEY,
    FechaEmision DATE NOT NULL,
    FechaVencimiento DATE,
    IdVenta INT UNIQUE NOT NULL,
    Observaciones VARCHAR(500),

    FOREIGN KEY (IdVenta)
        REFERENCES Venta(IdVenta)
);
GO

/*--------------------INSERTS EN LAS TABLAS------------------*/

INSERT INTO Usuario (Usuario, Contraseña) 
VALUES 
('Admin', 'Admin12345'), 
('Secretario', 'Secretario2026');

INSERT INTO TipoCliente (TipoCliente) 
VALUES 
('Empresa'), 
('Persona Natural');

INSERT INTO Cliente 
(IdTipoCliente, Identificador1, Identificador2, Documento, Telefono, Correo, Direccion, Estado) 
VALUES 
(1,'Muebles Lopez','Kevin Martínez','61000001','2222-1001','ventas@muebleskeyda.com','San Salvador','Activo'), 
(2,'María','Martínez','10000002','7777-0002','maria.martinez@gmail.com','Santa Ana','Activo'), 
(1,'Carpintería El Roble','José Ramírez','61000003','2222-1003','contacto@elroble.com','Sonsonate','Activo'), 
(2,'Carlos','Pérez','10000004','7777-0004','carlos.perez@gmail.com','La Libertad','Activo'), 
(1,'Maderas San José','Ana Hernández','61000005','2222-1005','ventas@maderassj.com','San Miguel','Activo'), 
(2,'Andrea','Flores','10000006','7777-0006','andrea.flores@gmail.com','Usulután','Activo'), 
(1,'Decoraciones SNOOPY','Ricardo Gómez','61000007','2222-1007','info@decoracionessv.com','Ahuachapán','Activo'), 
(2,'Luis','Martínez','10000008','7777-0008','luis.martinez@gmail.com','La Unión','Activo'), 
(1,'Diseños Modernos','Sofía Castro','61000009','2222-1009','ventas@dmodernos.com','Cuscatlán','Activo'), 
(2,'Gabriela','Rivas','10000010','7777-0010','gabriela.rivas@gmail.com','Chalatenango','Activo'), 
(1,'Wood Style','Fernando López','61000011','2222-1011','info@woodstyle.com','San Vicente','Activo'), 
(2,'Pedro','Castillo','10000012','7777-0012','pedro.castillo@gmail.com','La Paz','Activo'), 
(1,'Muebles Elegantes','Laura Díaz','61000013','2222-1013','ventas@muebleselegantes.com','Morazán','Activo'), 
(2,'Daniel','Morales','10000014','7777-0014','daniel.morales@gmail.com','Cabañas','Activo'), 
(1,'Muebles GREEN','Karen Rivera','61000015','2222-1015','contacto@GREEN.com','San Salvador','Activo'), 
(1,'Empresa Market','Juan Avila','23432563','2134-0009','Empresamarketsv@gmail.com','Cabañas','Activo'), 
(1,'Ingeniría de Soluciones','Jimena Díaz','23725693','2245-1009','SolucionesSV@gmail.com','San Vicente','Activo'), 
(1,'Tigo','Ricardo Cruz','11668673','7256-8890','TigoElSalvador@gmail.com','San Salvador','Activo'), 
(1,'Delicates','Gaby Castillo','88871388','2914-0768','DelicatesEventos@gmail.com','Chalatenango','Activo'), 
(1,'Muebles El Roble','Carlos Martínez','24567892','2234-5678','contacto@muebleselroble.com','San Salvador','Activo'), 
(1,'Ferretería La Central','María Hernández','23456781','2288-3344','ventas@lacentral.com','Santa Ana','Activo'), 
(1,'Distribuidora El Constructor','José Ramírez','25678913','2277-8899','info@constructor.com','La Libertad','Activo'), 
(1,'Decoraciones Modernas','Ana López','26789124','2266-7788','contacto@decoraciones.com','Sonsonate','Activo'), 
(1,'Maderas del Pacífico','Luis Gómez','27891235','2255-6677','ventas@maderaspacifico.com','Usulután','Activo'), 
(1,'Comercial La Estrella','Patricia Castro','28912346','2244-5566','info@laestrella.com','San Miguel','Activo'), 
(2,'Kevin','Pérez','12345678','7123-4567','kevinperez@gmail.com','San Salvador','Activo'), 
(2,'Andrea','Morales','23456789','7234-5678','andreamorales@gmail.com','Santa Ana','Activo'), 
(2,'Miguel','Rivas','34567890','7345-6789','miguelrivas@gmail.com','La Libertad','Activo'), 
(2,'Sofía','Castillo','45678901','7456-7890','sofiacastillo@gmail.com','Sonsonate','Activo'), 
(2,'Daniel','Flores','56789012','7567-8901','danielflores@gmail.com','San Miguel','Activo'), 
(2,'Valeria','Ruiz','67890123','7678-9012','valeriaruiz@gmail.com','Ahuachapán','Activo'), 
(2,'Fernando','Alvarado','78901234','7789-0123','fernandoalvarado@gmail.com','La Paz','Activo'), 
(2,'Gabriela','Méndez','89012345','7890-1234','gabrielamendez@gmail.com','Cuscatlán','Activo');

INSERT INTO Categoria 
(Nombre_Categoria, Descripcion, Estado) 
VALUES 
('Madera', 'Categoría que incluye los tipos de maderas', 'Inactiva'), 
('Ferretería', 'Tornillos, clavos y herrajes', 'Activa'), 
('Pinturas', 'Pinturas para madera', 'Activa'), 
('Barnices', 'Barnices y selladores', 'Activa'), 
('Pegamentos', 'Pegamentos y adhesivos', 'Activa'), 
('Tapicería', 'Espumas, telas y cuero sintético', 'Activa'), 
('Vidrio', 'Vidrio transparente y templado', 'Activa'), 
('Aluminio', 'Perfiles y accesorios de aluminio', 'Activa'), 
('Metal', 'Tubos, láminas y perfiles metálicos', 'Activa'), 
('Bisagras', 'Bisagras para puertas y muebles', 'Activa'), 
('Correderas', 'Correderas para gavetas', 'Activa'), 
('Accesorios', 'Manijas, jaladeras y topes', 'Activa'), 
('Lijas', 'Lijas para acabado de madera', 'Activa'), 
('Herramientas', 'Herramientas y accesorios de trabajo', 'Activa'), 
('Otros', 'Materiales diversos', 'Activa');

INSERT INTO UnidadMedida (UnidadMedida)
VALUES
('Pliego'),       -- ID 1
('Lámina'),       -- ID 2
('Unidad'),       -- ID 3
('Litro'),        -- ID 4
('Kilogramo'),    -- ID 5
('Metro'),        -- ID 6
('Par');          -- ID 7

INSERT INTO Material 
(NombreDelMaterial, IdUnidadDeMedida, Stock, Categoria) 
VALUES 
('Madera de pino', 1, 80, 1), 
('MDF 15 mm', 1, 40, 1), 
('Plywood 18 mm', 2, 35, 1), 
('Tornillo 2 pulgadas', 3, 1000, 2), 
('Clavo 2 pulgadas', 3, 2000, 2), 
('Pintura blanca', 4, 12, 3), 
('Barniz brillante', 4, 10, 4), 
('Sellador', 4, 25, 5), 
('Espuma de alta densidad', 5, 18, 6), 
('Vidrio templado', 6, 15, 7), 
('Perfil de aluminio para pulidora', 5, 30, 8), 
('Tubo cuadrado', 5, 22, 9), 
('Bisagra 2 pulgadas', 3, 150, 10), 
('Manecillas', 7, 60, 11), 
('Manija metálica para baño', 3, 120, 12);

INSERT INTO Proveedor 
(Nombre_Proveedor, Telefono, Correo, Ubicacion) 
VALUES 
('Ferretería El Roble', '2222-1001', 'ventas@elroble.com', 'San Salvador'), 
('Maderas San José', '2222-1002', 'contacto@maderassanjose.com', 'Santa Ana'), 
('Serma S.A.de C.V', '2222-1003', 'SERMA@gmail.com', 'San Miguel'), 
('Pragi S.A.de C.V', '2222-1004', 'Praguii@ferreteriacentral.com', 'Sonsonate'), 
('Distribuidora Los Pinos', '2222-1005', 'contacto@lospinos.com', 'La Libertad'), 
('Vidri S.A.de C.V', '2222-1006', 'ventas@gmail.com', 'San Salvador'), 
('Maderas La Oriental S.A.de C.V', '2222-1007', 'info@tapiceriamoderna.com', 'Usulután'), 
('FREUND S.A.de C.V', '2222-1008', 'FREUND@gamil.com', 'Santa Ana'), 
('La Casa Del Carpintero S.A.de C.V', '2222-1009', 'casacarpintero@gmail.com', 'San Miguel'), 
('GRUPO DURPANEL S.A.de C.V', '2222-1010', 'Durpanel@gmail.com', 'La Unión'), 
('Importadora El Carpintero', '2222-1011', 'info@elcarpintero.com', 'San Salvador'), 
('Distribuidora San Miguel', '2222-1012', 'ventas@dsm.com', 'San Miguel'), 
('Comercial La Madera', '2222-1013', 'contacto@lamadera.com', 'Ahuachapán'), 
('InverCalama S.A.de C.V', '2222-1014', 'Invercalma@gmail.com', 'Cuscatlán'), 
('Suministros Industriales', '2222-1015', 'info@suministrosind.com', 'San Salvador');

INSERT INTO Compras 
(FechaCompra, TotalCompra, IdProveedor) 
VALUES 
('2026-01-05', 350.00, 2), 
('2026-01-08', 420.50, 2), 
('2026-01-10', 185.75, 3), 
('2026-01-12', 690.00, 4), 
('2026-01-15', 510.25, 5), 
('2026-01-18', 275.80, 6), 
('2026-01-20', 980.40, 7), 
('2026-01-22', 320.00, 8), 
('2026-01-24', 745.60, 9), 
('2026-01-26', 890.00, 10), 
('2026-01-28', 410.35, 11), 
('2026-02-01', 560.90, 12), 
('2026-02-03', 299.99, 13), 
('2026-02-05', 640.70, 14), 
('2026-02-08', 815.45, 15);

INSERT INTO DetalleCompraMaterial 
(IdCompra, IdMaterial, Cantidad, PrecioUnitario) 
VALUES 
(1,2,20,15.50), 
(2,2,15,22.75), 
(3,3,10,30.00), 
(4,4,500,0.10), 
(5,5,300,0.08), 
(6,6,8,28.50), 
(7,7,6,35.00), 
(8,8,12,9.50), 
(9,9,10,18.75), 
(10,10,50,2.50), 
(11,11,25,12.00), 
(12,12,18,20.00), 
(13,13,100,1.20), 
(14,14,30,14.80), 
(15,15,40,3.25);

INSERT INTO Cotizacion 
(Fecha, IdCliente, CondicionPago, CondicionEntrega, Total, Estado, IdUsuario) 
VALUES 
('2026-02-10',1,'Anticipo del 50%','Entrega en 15 días',850.00,'Pendiente',1), 
('2026-02-11',2,'Transferencia del 25%','Entrega en 20 días',450.00,'Aprobada',1), 
('2026-02-12',3,'Anticipo de 50%','Entrega en 10 días',1200.00,'Pendiente',1), 
('2026-02-13',4,'Transferencia del 50%','Entrega en 15 días',650.00,'Aprobada',1), 
('2026-02-14',5,'Pago contra entrega','Entrega en 25 días',980.00,'Pendiente',1), 
('2026-02-15',6,'Anticipo del 20%','Entrega en 18 días',720.00,'Pendiente',1), 
('2026-02-16',7,'Anticipo del 50 %','Entrega en 12 días',1500.00,'Aprobada',1), 
('2026-02-17',8,'Pago contra entrega','Entrega en 20 días',890.00,'Pendiente',1), 
('2026-02-18',9,'Pago del material inicial','Entrega en 15 días',1350.00,'Aprobada',1), 
('2026-02-19',10,'Pago contra entrega','Entrega en 22 días',540.00,'Pendiente',1), 
('2026-02-20',11,'Efectivo al momento de entrega','Entrega en 14 días',760.00,'Aprobada',1), 
('2026-02-21',12,'Transferencia','Entrega en 16 días',1100.00,'Pendiente',1), 
('2026-02-22',13,'Anticipo','Entrega en 21 días',930.00,'Aprobada',1), 
('2026-02-23',14,'Anticipo del 50%','Entrega en 19 días',680.00,'Pendiente',1), 
('2026-02-24',15,'Pago contra entrega','Entrega en 15 días',1750.00,'Aprobada',1);

INSERT INTO Productos_Cotizacion
(DescripcionMueble,Largo,Ancho,Alto,Cantidad,PrecioUnitario,SubTotal,IdCotizacion)
VALUES
('Mesa de comedor de 6 puestos', 180.00, 90.00, 75.00, 1, 450.00, 450.00, 1),
('Sillas de comedor', 45., 45, 90, 6, 85.00, 510.00, 2),
('Closet de 3 puertas', 200.00, 60.00, 220.00, 1, 850.00, 850.00, 3),
('Mesa de noche', 50, 40, 55, 2, 120.00, 240.00, 4),
('Cama matrimonial', 190.00, 140.00, 100.00, 1, 650.00, 650.00, 5),
('Mesa de noche', 50, 40, 55, 2, 120.00, 240.00, 6),
('Escritorio de oficina', 140.00, 70.00, 75.00, 1, 380.00, 380.00, 7),
('Silla ejecutiva', 60, 60, 110, 1, 275.00, 275.00,8),
('Centro de entretenimiento', 180.00, 45.00, 160.00, 1, 600.00, 600.00, 9),
('Mueble auxiliar', 80, 40, 90, 2, 180.00, 360.00, 10),
('Cocina integral', 300, 60, 220, 1, 1850.00, 1850.00, 11),
('Librera de madera', 120, 35, 180, 1, 420, 420, 12),
('Armario de dos puertas', 120, 60, 200, 1, 720, 720.00, 12),
('Mueble para TV', 160, 45, 60, 1, 350.00, 350.00, 13),
('Cómoda de 6 gavetas', 120, 45, 90, 1, 480.00, 480.00, 13),
('Mesa de centro', 100, 60, 45, 1, 250.00, 250.00, 13),
('Escritorio juvenil', 120, 60, 75, 1, 320.00, 320.00, 14),
('Banco de madera', 45, 45, 75, 4, 65.00, 260.00, 15),
('Gabinete de cocina', 100, 55, 90, 2, 390.00, 780.00, 12),
('Sofá de tres plazas', 210, 90, 85, 1, 950.00, 950.00, 15);

INSERT INTO Pedido 
(FechaDePedido, FechaDeEntrega, Estado, IdCotizacion) 
VALUES 
('2026-02-11','2026-02-25','En proceso',1), 
('2026-02-12','2026-02-28','Finalizado',2), 
('2026-02-13','2026-03-01','En proceso',3), 
('2026-02-14','2026-03-02','Finalizado',4), 
('2026-02-15','2026-03-05','En proceso',5), 
('2026-02-16','2026-03-06','Finalizado',6), 
('2026-02-17','2026-03-08','En proceso',7), 
('2026-02-18','2026-03-10','En proceso',8), 
('2026-02-19','2026-03-12','Finalizado',9), 
('2026-02-20','2026-03-13','En proceso',10), 
('2026-02-21','2026-03-15','En proceso',11), 
('2026-02-22','2026-03-16','Finalizado',12), 
('2026-02-23','2026-03-18','Finalizado',13), 
('2026-02-24','2026-03-20','En proceso',14);

INSERT INTO Produccion 
(IdPedido, Progreso) 
VALUES 
(14,25), 
(2,0), 
(3,40), 
(4,100), 
(5,0), 
(6,35), 
(7,60), 
(8,0), 
(9,100), 
(10,50), 
(11,10), 
(12,75), 
(13,100), 
(14,80);

INSERT INTO MaterialUtilizado 
(Cantidad_Utilizada, IdMaterial, IdProduccion) 
VALUES 
(6,1,8), 
(2,11,8), 
(15,2,9), 
(300,4,9), 
(4,3,10), 
(1,12,10), 
(10,1,11), 
(2,14,11), 
(7,2,12), 
(4,15,12), 
(8,3,13), 
(2,9,13), 
(6,1,14), 
(250,5,14), 
(12,2,14), 
(3,7,14);

INSERT INTO MetodoPago (MetodoPago)
VALUES
('Efectivo'),
('Transferencia'),
('Tarjeta');


INSERT INTO Venta
(FechaVenta, IdCliente, IdMetodoPago, SubTotal)
VALUES
('2026-03-01', 1, 1, 850.00),
('2026-03-02', 2, 2, 450.00),
('2026-03-03', 3, 3, 1200.00),
('2026-03-04', 4, 1, 400.00),
('2026-03-05', 5, 2, 980.00),
('2026-03-06', 6, 3, 720.00),
('2026-03-07', 7, 1, 1500.00),
('2026-03-08', 8, 2, 890.00),
('2026-03-09', 9, 3, 1350.00),
('2026-03-10', 10, 1, 540.00),
('2026-03-11', 11, 2, 760.00),
('2026-03-12', 12, 3, 1100.00),
('2026-03-13', 13, 1, 930.00),
('2026-03-14', 14, 2, 680.00),
('2026-03-15', 15, 3, 1750.00);


INSERT INTO DetalleVenta 
(IdVenta, ProductoVendido, Cantidad, PrecioUnitario) 
VALUES 
(2,'Closet de 8 compartimientos de cedro',2,10.00), 
(2,'Cama matrimonial con respaldo de roble',3,70.00), 
(3,'Mesas de sala de color gris',5,18.00), 
(4,'Mueble de baño',3,20.00), 
(5,'Escritorio forrado con melamina',4,25.00), 
(6,'Juego de comedor',1,170.00), 
(3,'Closet de 5 compartimientos y tres gavetas abajo',1,30.00), 
(7,'Cuna de 2 metros color lila',1,25.00), 
(8,'Librero de 4 niveles con dos gaveteros con llave arriba',1,30.00), 
(9,'Mesa de cocina',1,40.00), 
(10,'Mueble de despensa de cedro con barniz',1,25.00), 
(11,'Escritorio color lila',3,10.00), 
(12,'Cama con acabo de flores',2,20.00), 
(13,'Mesa de sala',2,10.00), 
(14,'Mesa de noche',3,15.00), 
(15,'Armario de 3 secciones con dos gavetas con llave',1,30.00);


INSERT INTO Factura 
(FechaEmision, FechaVencimiento, IdVenta, Observaciones) 
VALUES 
('2026-03-02','2026-03-17',1,'Pago pendiente'), 
('2026-03-03','2026-03-18',2,'Factura cancelada'), 
('2026-03-04','2026-03-19',4,'Pago pendiente'), 
('2026-03-05','2026-03-20',5,'Factura cancelada'), 
('2026-03-06','2026-03-21',6,'Pago pendiente'), 
('2026-03-07','2026-03-22',7,'Factura cancelada'), 
('2026-03-08','2026-03-23',8,'Pago pendiente'), 
('2026-03-09','2026-03-24',9,'Factura cancelada'), 
('2026-03-10','2026-03-25',10,'Pago pendiente'), 
('2026-03-11','2026-03-26',12,'Factura cancelada'), 
('2026-03-12','2026-03-27',13,'Pago pendiente'), 
('2026-03-13','2026-03-28',14,'Factura cancelada'), 
('2026-03-14','2026-03-29',15,'Pago pendiente'), 
('2026-03-15','2026-03-30',3,'Factura cancelada');


---------------------- VISTA DE CLIENTES ------------------------------------------------------------------
GO

CREATE VIEW VerClientes AS
SELECT
    c.IdCliente,

    CASE
        WHEN c.IdTipoCliente = 2
            THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS Cliente,

    c.Telefono,
    c.Correo,
    c.Direccion,
    c.Estado

FROM Cliente c;
GO

---------------------- VISTA DE COMPRAS ------------------------------------------------------------------

CREATE VIEW VerCompras AS
SELECT
    c.IdCompra,
    c.FechaCompra,
    p.Nombre_Proveedor AS Proveedor,
    c.TotalCompra
FROM Compras c
INNER JOIN Proveedor p
    ON c.IdProveedor = p.IdProveedor;
GO

------------------------------------------------- VISTA DE PEDIDOS ------------------------------------------------------------------
GO

CREATE VIEW VerPedido AS
SELECT 
    p.IdPedido,

    CASE 
        WHEN tc.TipoCliente = 'Persona Natural' 
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS Cliente,

    p.FechaDePedido,
    p.FechaDeEntrega,
    p.Estado

FROM Pedido p

INNER JOIN Cotizacion co
    ON p.IdCotizacion = co.IdCotizacion

INNER JOIN Cliente c
    ON co.IdCliente = c.IdCliente

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;
GO

------------------------------------------------- VISTA DE VER MATERIALES -----------------------------------------------------------
GO
CREATE VIEW VerMaterial AS
SELECT 
    m.IdMaterial,
    m.NombreDelMaterial AS Material,
    c.Nombre_Categoria AS Categoria,
    u.UnidadMedida,
    m.Stock

FROM Material m

INNER JOIN Categoria c
    ON m.Categoria = c.IdCategoria

INNER JOIN UnidadMedida u
    ON m.IdUnidadDeMedida = u.IdUnidadMedida;
GO

------------------------------------------------- VISTA DE COTIZACIONES -----------------------------------------------------------
GO
CREATE VIEW VerCotizaciones AS
SELECT  
    co.IdCotizacion,
    co.Fecha,

    CASE 
        WHEN tc.TipoCliente = 'Persona Natural' 
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS Cliente,

    tc.TipoCliente AS [Tipo de Cliente],
    co.Estado,
    co.Total

FROM Cotizacion co

INNER JOIN Cliente c
    ON co.IdCliente = c.IdCliente

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;
GO

---------------REPORTES DE COTIZACIONESS---------------------------

GO

CREATE VIEW VerCotizaciones2 AS
SELECT
    co.IdCotizacion AS IdCotizacion,

    co.Fecha AS Fecha,

    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS Cliente,

    tc.TipoCliente AS TipoCliente,

    co.Estado AS Estado,

    co.Total AS Total

FROM Cotizacion co

INNER JOIN Cliente c
    ON co.IdCliente = c.IdCliente

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;

GO

------------------------------------------------- VISTA DE VENTAS -----------------------------------------------------------
GO

CREATE VIEW VerVentas AS 
SELECT  
    ve.IdVenta, 
    ve.FechaVenta AS [Fecha de Venta], 
 
    CASE 
        WHEN tc.TipoCliente = 'Persona Natural' 
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2) 
        ELSE c.Identificador1 
    END AS Cliente, 
 
    mp.MetodoPago AS [Metodo de Pago], 
 
    ve.SubTotal, 
 
    CAST(ve.SubTotal * 1.13 AS DECIMAL(10,2)) AS [Total a Pagar]
 
FROM Venta ve 
 
INNER JOIN Cliente c 
    ON ve.IdCliente = c.IdCliente 
 
INNER JOIN TipoCliente tc 
    ON c.IdTipoCliente = tc.IdTipoCliente 
 
INNER JOIN MetodoPago mp 
    ON ve.IdMetodoPago = mp.IdMetodoPago;
GO

------------------------------------------------- VISTA DE PRODUCCION -----------------------------------------------------------
GO
CREATE VIEW VerProduccion AS 
SELECT
    pro.IdProduccion,
    p.IdPedido,

    CASE 
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS Cliente,

    pc.DescripcionMueble AS Producto,
    pc.Largo,
    pc.Ancho,
    pc.Alto,
    pc.Cantidad,

    p.FechaDePedido AS [Fecha de Inicio],
    p.FechaDeEntrega AS [Fecha de Entrega],

    pro.Progreso,

    CASE 
        WHEN pro.Progreso = 0 THEN 'Pendiente'
        WHEN pro.Progreso BETWEEN 1 AND 99 THEN 'En producción'
        WHEN pro.Progreso = 100 THEN 'Finalizado'
    END AS Estado

FROM Produccion pro

INNER JOIN Pedido p
    ON pro.IdPedido = p.IdPedido

INNER JOIN Cotizacion co
    ON p.IdCotizacion = co.IdCotizacion

INNER JOIN Productos_Cotizacion pc
    ON co.IdCotizacion = pc.IdCotizacion

INNER JOIN Cliente c
    ON co.IdCliente = c.IdCliente

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;
GO

------------------------------------------------- VISTA DE FACTURAS -----------------------------------------------------------
ALTER VIEW VerFacturas AS
SELECT   
    f.IdFactura,  
    f.FechaEmision AS [Fecha], 
    f.FechaVencimiento AS [Fecha de Vencimiento], 
 
    CASE 
        WHEN tc.TipoCliente = 'Persona Natural' 
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2) 
        ELSE c.Identificador1 
    END AS Cliente, 
 
    mp.MetodoPago AS [Método de Pago], 
 
    CAST(v.SubTotal AS DECIMAL(10,2)) AS [SubTotal], 
 
    CAST(ROUND(v.SubTotal * 0.13, 2) AS DECIMAL(10,2)) AS [IVA], 
 
    CAST(0.00 AS DECIMAL(10,2)) AS [Descuento], 
 
    CAST(ROUND(v.SubTotal * 1.13, 2) AS DECIMAL(10,2)) AS [Total], 
 
    f.Observaciones AS Observaciones 
 
FROM Factura f 
 
INNER JOIN Venta v 
    ON f.IdVenta = v.IdVenta 
 
INNER JOIN Cliente c 
    ON v.IdCliente = c.IdCliente 
 
INNER JOIN TipoCliente tc 
    ON c.IdTipoCliente = tc.IdTipoCliente 
 
INNER JOIN MetodoPago mp 
    ON v.IdMetodoPago = mp.IdMetodoPago;

GO
---------------------REPORTES DE CLIENTES-------------------------------------------------

CREATE VIEW VerReporteClientes AS 
SELECT
    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS [Nombre del Cliente],

    tc.TipoCliente,

    CASE
        WHEN tc.TipoCliente = 'Empresa'
        THEN c.Identificador2
        ELSE NULL
    END AS Encargado,

    c.Documento,
    c.Telefono AS [Telefono],
    c.Correo,
    c.Direccion AS [Direccion],
    c.FechaRegistro AS [Fecha de Registro]

FROM Cliente c

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;

----Vista para mostrar en el documento de exportacion de visual--------
GO

CREATE VIEW VerReporteClientes2 AS 
SELECT
    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS NombreCliente,

    tc.TipoCliente AS TipoCliente,

    CASE
        WHEN tc.TipoCliente = 'Empresa'
        THEN c.Identificador2
        ELSE NULL
    END AS Encargado,

    c.Documento AS Documento,
    c.Telefono AS Telefono,
    c.Correo AS Correo,
    c.Direccion AS Direccion,
    c.FechaRegistro AS FechaRegistro

FROM Cliente c

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;
GO

----------------------------------REPORTE DE VENTAS---------------------------------------------

------------------DETALLE FACTURA------------------------------------------------
GO
CREATE VIEW DetalleDeFactura AS
SELECT 
    v.Idventa,
    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS [Cliente],
    v.IdMetodoPago,
    v.SubTotal,
    ROUND(v.SubTotal * 1.13,2) AS [Total a Pagar]

FROM Venta v
INNER JOIN Factura f
    ON f.IdFactura=v.IdVenta
INNER JOIN Cliente c
    ON v.IdCliente = c.IdCliente
INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;
GO

--------------DETALLE DE COTIZACION--------------------------------------------------
GO
CREATE VIEW DetalleDeCotizacion AS
SELECT 
    co.IdCotizacion,
    pc.DescripcionMueble,
    pc.Cantidad,
    pc.PrecioUnitario,
    pc.SubTotal
FROM Productos_Cotizacion pc
INNER JOIN Cotizacion co
    ON pc.IdProductosCotizacion=co.IdCotizacion;
GO

--------------DETALLE DE VENTAS -----------------------------------------------------
GO
CREATE VIEW VerDetalleVenta
AS
SELECT
    IdDetalleVenta,
    IdVenta,
    ProductoVendido,
    Cantidad,
    PrecioUnitario,
    (Cantidad * PrecioUnitario) AS SubTotal
FROM DetalleVenta;
GO

------------------MUESTRA LOS MATERIALES UTILIZADOS EN UNA PRODUCCION-----------------------

CREATE VIEW VerMaterialesUtilizados
AS
SELECT
    mu.IdMaterialUtilizado,
    mu.IdProduccion,
    mu.IdMaterial,
    m.NombreDelMaterial,
    mu.Cantidad_Utilizada,
    um.UnidadMedida AS UnidadMedida
FROM MaterialUtilizado mu
INNER JOIN Material m
    ON mu.IdMaterial = m.IdMaterial
INNER JOIN UnidadMedida um
    ON m.IdUnidadDeMedida = um.IdUnidadMedida;

GO
----------MUESTRA LAS UNIDADES DE MEDIDA----------------------------

CREATE VIEW UnidadDeMedida AS SELECT
    m.IdMaterial AS [ #],
    m.NombreDelMaterial AS [Material],
    um.UnidadMedida AS [Unidad de Medida]
FROM Material m
INNER JOIN UnidadMedida um
    ON m.IdUnidadDeMedida = um.IdUnidadMedida;
------------VISTA PARA MOSTRAR PEDIDOS RECIENTES-----------------------------------

 GO 
 CREATE VIEW PedidosRecientes AS
 SELECT TOP 12 p.IdPedido AS
 [# Pedido], CASE WHEN tc.TipoCliente = 'Persona Natural' THEN CONCAT(c.Identificador1, ' ', c.Identificador2) 
 ELSE c.Identificador1 END AS [Cliente],
 p.FechaDePedido AS [Fecha de Pedido],
 p.FechaDeEntrega AS [Fecha de Entrega],
 p.Estado AS [Estado] FROM Pedido p 
 INNER JOIN Cotizacion co ON p.IdCotizacion = co.IdCotizacion 
 INNER JOIN Cliente c ON co.IdCliente = c.IdCliente 
 INNER JOIN TipoCliente tc ON c.IdTipoCliente = tc.IdTipoCliente ORDER BY p.FechaDePedido DESC;

GO

CREATE VIEW VerVentasParaFactura AS
SELECT
    v.IdVenta AS [#],
    v.FechaVenta AS [Fecha de Venta],

    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS Cliente,

    c.Documento,
    c.Telefono,
    c.Correo,

    v.SubTotal

FROM Venta v

INNER JOIN Cliente c
    ON v.IdCliente = c.IdCliente

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente

LEFT JOIN Factura f
    ON v.IdVenta = f.IdVenta

WHERE f.IdFactura IS NULL;

GO

CREATE VIEW SeleccionClientes AS
SELECT 
C.IdCliente AS [#],

  CASE 
WHEN IdTipoCliente = 2 
THEN Identificador1 + ' ' + Identificador2
ELSE Identificador1 
END AS Cliente,
c.Telefono,
c.Correo,
c.Direccion,
c.Estado FROM Cliente c;

GO
CREATE VIEW vw_VerUsuarios
AS
SELECT
    U.IdUsuario,
    U.Nombre,
    U.Usuario,
    U.Contraseña,
    R.Nombre AS Rol,
    U.Estado
FROM Usuario U
INNER JOIN Rol R
    ON U.IdRol = R.IdRol;
GO

-----------------------------------------------------------------------------------------
---BUSCAR EL CORREO INGRESADO EN LOS REGISTROS---

CREATE OR ALTER PROCEDURE sp_Usuario_BuscarPorCorreo
    @Correo VARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdUsuario,
        Nombre,
        Usuario,
        Correo
    FROM Usuario
    WHERE Correo = @Correo
      AND Estado = 1;
END;
GO

CREATE OR ALTER PROCEDURE sp_Recuperacion_Crear
    @IdUsuario INT,
    @Codigo VARCHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO RecuperacionContraseña
    (
        IdUsuario,
        Codigo,
        FechaGeneracion,
        FechaExpiracion,
        Usado
    )
    VALUES
    (
        @IdUsuario,
        @Codigo,
        GETDATE(),
        DATEADD(MINUTE, 10, GETDATE()),
        0
    );
END;
GO
-----------------VERIFICAR EL CODIGO---------------------------
CREATE OR ALTER PROCEDURE sp_Recuperacion_Verificar
    @IdUsuario INT,
    @Codigo VARCHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        IdRecuperacion,
        IdUsuario,
        Codigo,
        FechaGeneracion,
        FechaExpiracion,
        Usado
    FROM RecuperacionContraseña
    WHERE IdUsuario = @IdUsuario
      AND Codigo = @Codigo
      AND Usado = 0
      AND FechaExpiracion > GETDATE()
    ORDER BY IdRecuperacion DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_Usuario_CambiarContraseña
    @IdUsuario INT,
    @NuevaContraseña VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuario
    SET Contraseña = @NuevaContraseña
    WHERE IdUsuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_Recuperacion_MarcarUsado
    @IdRecuperacion INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE RecuperacionContraseña
    SET Usado = 1
    WHERE IdRecuperacion = @IdRecuperacion;
END;
GO



----------------TRIGGER PARA CONTROLAR QUE UN PEDIDO FINALIZADO PASE A SER REGISTRO DE VENTAS------------

CREATE TRIGGER TR_Pedido_Finalizado_Venta
ON Pedido
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Tabla temporal para relacionar cada venta
    -- nueva con su cotizacion correspondiente
    DECLARE @VentasCreadas TABLE
    (
        IdVenta INT,
        IdCotizacion INT
    );

    -- 1. Insertar las ventas
    MERGE INTO Venta AS destino
    USING
    (
        SELECT
            i.IdCotizacion,
            c.IdCliente,
            c.Total
        FROM inserted i
        INNER JOIN deleted d
            ON i.IdPedido = d.IdPedido
        INNER JOIN Cotizacion c
            ON i.IdCotizacion = c.IdCotizacion
        WHERE i.Estado = 'Finalizado'
          AND d.Estado <> 'Finalizado'
    ) AS origen
    ON 1 = 0

    WHEN NOT MATCHED THEN
        INSERT
        (
            FechaVenta,
            IdCliente,
            SubTotal
        )
        VALUES
        (
            GETDATE(),
            origen.IdCliente,
            origen.Total
        )

    OUTPUT
        inserted.IdVenta,
        origen.IdCotizacion
    INTO @VentasCreadas
    (
        IdVenta,
        IdCotizacion
    );

    -- 2. Insertar los productos de cada cotizacion
    -- en el detalle de la venta correspondiente
    INSERT INTO DetalleVenta
    (
        IdVenta,
        ProductoVendido,
        Cantidad,
        PrecioUnitario
    )
    SELECT
        vc.IdVenta,
        pc.DescripcionMueble,
        pc.Cantidad,
        pc.PrecioUnitario
    FROM @VentasCreadas vc
    INNER JOIN Productos_Cotizacion pc
        ON vc.IdCotizacion = pc.IdCotizacion;

END;
GO



SELECT *
FROM Productos_Cotizacion
WHERE IdCotizacion = 5;


SELECT
    v.IdVenta,
    v.FechaVenta,
    v.IdCliente,
    v.SubTotal,
    dv.ProductoVendido,
    dv.Cantidad,
    dv.PrecioUnitario
FROM Venta v
LEFT JOIN DetalleVenta dv
    ON v.IdVenta = dv.IdVenta
ORDER BY v.IdVenta DESC;


SELECT *FROM VerReporteVentas


Select *from VerProveedores

EXEC sp_help 'Factura';
























------------NO CARGAR ESTA SECCION------------------------------------------
SELECT * FROM VerCompras;

SELECT MAX(IdCliente) AS MayorID
FROM Cliente;

DBCC CHECKIDENT ('Cliente', NORESEED);

DBCC CHECKIDENT ('Cliente', RESEED, 33);

DBCC CHECKIDENT ('Cliente', NORESEED);
SELECT * FROM Proveedor;

UPDATE Proveedor
SET Estado = '1';

ALTER TABLE Proveedor
DROP CONSTRAINT DF_Proveedor_Estado;

ALTER TABLE Proveedor
ALTER COLUMN Estado BIT NOT NULL;

ALTER TABLE Proveedor
ADD CONSTRAINT DF_Proveedor_Estado
DEFAULT 1 FOR Estado;