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
    Rol VARCHAR(20) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    Correo VARCHAR(150) NOT NULL,

    CONSTRAINT CK_Usuario_Rol
        CHECK (Rol IN ('Administrador', 'Secretario'))
);
GO

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

CREATE TABLE Categoria
(
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Categoria VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200),
    Estado VARCHAR(10) NOT NULL
    CHECK (Estado IN ('Activa', 'Inactiva'))
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
    CondicionPago TEXT NOT NULL,
    CondicionEntrega TEXT NOT NULL,
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


CREATE TABLE Venta
(
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    FechaVenta DATE NOT NULL,
    IdCliente INT NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (IdCliente)
        REFERENCES Cliente(IdCliente)
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
    FechaVencimiento DATE NULL,
    IdVenta INT NOT NULL UNIQUE,
    Descuento DECIMAL(10,2) NOT NULL DEFAULT 0,
    Observaciones VARCHAR(500) NULL,

    CONSTRAINT FK_Factura_Venta
        FOREIGN KEY (IdVenta)
        REFERENCES Venta(IdVenta)
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

GO
----------------CATALOGO DE REGISTROS DE LA APLICACIÓN----------------------

--1.Unidades de medida.
INSERT INTO UnidadMedida (UnidadMedida)
VALUES
('Pliego'),       -- ID 1
('Lámina'),       -- ID 2
('Unidad'),       -- ID 3
('Litro'),        -- ID 4
('Kilogramo'),    -- ID 5
('Metro'),        -- ID 6
('Par');          -- ID 7

--2.Tipos de clientes permitidos para la empresa.
INSERT INTO TipoCliente (TipoCliente) 
VALUES 
('Empresa'), 
('Persona Natural');

GO

--3.Categorías iniciales para poder registrar materiales en el inventario.
INSERT INTO Categoria
(Nombre_Categoria, Descripcion, Estado)
VALUES
('Madera', 'Maderas naturales para fabricación de muebles', 'Activa'),
('MDF', 'Tableros de fibra de densidad media', 'Activa'),
('Melamina', 'Tableros melamínicos para fabricación de muebles', 'Activa'),
('Triplay', 'Tableros de madera contrachapada', 'Activa'),
('Tableros', 'Tableros y placas para fabricación de muebles', 'Activa'),
('Ferretería', 'Tornillos, clavos y herrajes', 'Activa'),
('Pinturas', 'Pinturas para madera y muebles', 'Activa'),
('Barnices', 'Barnices, selladores y productos para acabado', 'Activa'),
('Pegamentos', 'Pegamentos y adhesivos para madera', 'Activa'),
('Tapicería', 'Materiales utilizados para tapizar muebles', 'Activa'),
('Espumas', 'Espumas y materiales de relleno', 'Activa'),
('Telas', 'Telas y materiales textiles para tapicería', 'Activa'),
('Vidrio', 'Vidrio transparente y templado', 'Activa'),
('Aluminio', 'Perfiles y accesorios de aluminio', 'Activa'),
('Metal', 'Tubos, láminas y perfiles metálicos', 'Activa'),
('Bisagras', 'Bisagras para puertas y muebles', 'Activa'),
('Correderas', 'Correderas para gavetas y cajones', 'Activa'),
('Accesorios', 'Manijas, jaladeras, topes y otros accesorios', 'Activa'),
('Lijas', 'Lijas para preparación y acabado de superficies', 'Activa'),
('Herramientas', 'Herramientas y accesorios de trabajo', 'Activa'),
('Otros', 'Materiales diversos que no pertenecen a otra categoría', 'Activa');

GO


--------------------------------SECCION DE VISTAS------------------------------------

--1.Vista para cargar clientes
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

--2.Vista para ver proveedores

CREATE VIEW VerProveedores
AS
SELECT
    p.IdProveedor ,
    P.Nombre_Proveedor AS [Proveedor],
    p.Telefono,
    p.Correo,
    p.Ubicacion,
     CASE
        WHEN Estado = 1 THEN 'Activo'
        WHEN Estado = 0 THEN 'Inactivo'
    END AS Estado
FROM Proveedor p;

GO

--3.Vista para ver las compras

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

--4.Vista para cargar los pedidos

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

--5.Vista para ver materiales

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

--6.Vista para

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

    --7.Vista para 

    CREATE VIEW VerVentas AS 
SELECT  
    ve.IdVenta, 
    ve.FechaVenta AS [Fecha de Venta], 
 
    CASE 
        WHEN tc.TipoCliente = 'Persona Natural' 
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2) 
        ELSE c.Identificador1 
    END AS Cliente, 
 
    ve.SubTotal, 
 
    CAST(ve.SubTotal * 1.13 AS DECIMAL(10,2)) AS [Total a Pagar]
 
FROM Venta ve 
 
INNER JOIN Cliente c 
    ON ve.IdCliente = c.IdCliente 
 
INNER JOIN TipoCliente tc 
    ON c.IdTipoCliente = tc.IdTipoCliente;

    GO

--8.Vista para 

    CREATE VIEW VerProduccion AS SELECT
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

--9.Vista para

CREATE VIEW VerFacturas AS
SELECT   
    f.IdFactura,  
    f.FechaEmision AS [Fecha], 
    f.FechaVencimiento AS [Fecha de Vencimiento], 
 
    CASE 
        WHEN tc.TipoCliente = 'Persona Natural' 
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2) 
        ELSE c.Identificador1 
    END AS Cliente,  
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
    ON c.IdTipoCliente = tc.IdTipoCliente;

GO

--10. Vista para
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
    c.Telefono AS Telefono,
    c.Correo,
    c.Direccion

FROM Cliente c
INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;

GO

---11.Vista para mostrar en el documento de exportacion de visual

CREATE VIEW VerReporteClientes2 AS
SELECT
    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS [Nombre del Cliente],

    tc.TipoCliente AS [Tipo de Cliente],

    CASE
        WHEN tc.TipoCliente = 'Empresa'
        THEN c.Identificador2
        ELSE NULL
    END AS [Encargado],

    c.Documento AS [Documento],
    c.Telefono AS [Teléfono],
    c.Correo AS [Correo],
    c.Direccion AS [Dirección],

    CAST(c.FechaRegistro AS DATE) AS [Fecha de Registro]

FROM Cliente c
INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente;

GO

--12.Vista para

CREATE VIEW VerReporteVentas AS
SELECT
    v.IdVenta,
    f.IdFactura AS [N° FACTURA],

    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS [Nombre De Cliente],

    v.FechaVenta,
    v.SubTotal,
    v.SubTotal AS [TotalAPagar]

FROM Venta v

INNER JOIN Cliente c
    ON v.IdCliente = c.IdCliente

INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente

LEFT JOIN Factura f
    ON v.IdVenta = f.IdVenta;
GO

--13.Vista para

CREATE VIEW DetalleDeFactura AS
SELECT 
    v.Idventa,
    CASE
        WHEN tc.TipoCliente = 'Persona Natural'
        THEN CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE c.Identificador1
    END AS [Cliente],
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

--14.Vista para cargar la informacion de las facturas y que se puedan editar

CREATE VIEW VerFacturaEditar AS 
SELECT
    f.IdFactura,
    f.IdVenta,

    f.FechaEmision,
    f.FechaVencimiento,

    CASE
        WHEN c.IdTipoCliente = 2 THEN
            CONCAT(c.Identificador1, ' ', c.Identificador2)
        ELSE
            c.Identificador1
    END AS Cliente,

    c.Documento,
    c.Telefono,
    c.Correo,

    v.SubTotal,

    ISNULL(f.Descuento, 0.00) AS Descuento,

    CAST(
        (v.SubTotal - ISNULL(f.Descuento, 0.00)) * 0.13
        AS DECIMAL(10,2)
    ) AS IVA,

    CAST(
        (v.SubTotal - ISNULL(f.Descuento, 0.00)) * 1.13
        AS DECIMAL(10,2)
    ) AS Total,

    f.Observaciones

FROM Factura f

INNER JOIN Venta v
    ON f.IdVenta = v.IdVenta

INNER JOIN Cliente c
    ON v.IdCliente = c.IdCliente;
GO

--15.Vista para ver los productos que se vendieron

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

--16.Vista para ver los materiales utilizados en produccion

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

--17.Vista para ver las unidades de medida.

CREATE VIEW UnidadDeMedida AS SELECT
    m.IdMaterial AS [ #],
    m.NombreDelMaterial AS [Material],
    um.UnidadMedida AS [Unidad de Medida]
FROM Material m
INNER JOIN UnidadMedida um
    ON m.IdUnidadDeMedida = um.IdUnidadMedida;

GO

--18.Vista para ver los pedidos recientes.

 CREATE VIEW PedidosRecientes AS

 SELECT TOP 12 p.IdPedido AS [# Pedido],
 
 CASE WHEN tc.TipoCliente = 'Persona Natural' 
 THEN CONCAT(c.Identificador1, ' ', c.Identificador2) 
 ELSE c.Identificador1 END AS [Cliente],

 p.FechaDePedido AS [Fecha de Pedido],

 p.FechaDeEntrega AS [Fecha de Entrega],

 p.Estado AS [Estado] FROM Pedido p 

 INNER JOIN Cotizacion co ON p.IdCotizacion = co.IdCotizacion 
 INNER JOIN Cliente c ON co.IdCliente = c.IdCliente 
 INNER JOIN TipoCliente tc ON c.IdTipoCliente = tc.IdTipoCliente ORDER BY p.FechaDePedido DESC;

 GO

 --19. Vista para 

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

--20.Vista para cargar el listado de clientes registrados.

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
 
 --21.Vista para cargar los usuarios.

 CREATE VIEW VerUsuarios
AS
SELECT
    U.IdUsuario AS [#],
    U.Nombre,
    U.Usuario,
    U.Correo,
    U.Rol,
    CASE
        WHEN U.Estado = 1 THEN 'Activo'
        WHEN U.Estado = 0 THEN 'Inactivo'
    END AS Estado
FROM Usuario U;

GO


--22.Vista para buscar los clientes individuales

CREATE VIEW BuscarClientesIndividuales AS
SELECT
    c.Identificador1 AS Nombre,
    c.Identificador2 AS Apellidos,
    c.Documento AS DUI,
    c.Telefono,
    c.Correo,
    c.Direccion,
    c.Estado
FROM Cliente c
INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente
WHERE tc.TipoCliente = 'Persona Natural';

GO

--23.Vista para 

CREATE VIEW BuscarClientesCorporativos AS
SELECT
    c.Identificador1 AS [Empresa],
    c.Identificador2 AS Encargado,
    c.Documento AS NIT,
    c.Telefono,
    c.Correo,
    c.Direccion,
    c.Estado
FROM Cliente c
INNER JOIN TipoCliente tc
    ON c.IdTipoCliente = tc.IdTipoCliente
WHERE tc.TipoCliente = 'Empresa';

GO

--23.Vista para cargar los productos cotizados.

CREATE VIEW DetalleDeCotizacion AS
SELECT
    co.IdCotizacion,
    pc.DescripcionMueble,
    pc.Cantidad,
    pc.PrecioUnitario,
    pc.SubTotal
FROM Productos_Cotizacion pc
INNER JOIN Cotizacion co
    ON pc.IdCotizacion = co.IdCotizacion;

GO
/*=========================================================*/
              /*PROCEDIMIENTOS ALMACENADOS*/
/*=========================================================*/

/* 1. INDICADORES DEL DASHBOARD */

CREATE OR ALTER PROCEDURE sp_Dashboard_Indicadores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        -- Total de materiales
        (SELECT COUNT(*)
         FROM Material) AS MaterialesRegistrados,

        -- Total de clientes
        (SELECT COUNT(*)
         FROM Cliente) AS ClientesRegistrados,

        -- Ventas del mes actual
        (SELECT ISNULL(SUM([Total a Pagar]), 0)
         FROM VerVentas
         WHERE MONTH([Fecha de Venta]) = MONTH(GETDATE())
           AND YEAR([Fecha de Venta]) = YEAR(GETDATE())) AS VentasDelMes,

        -- Total de cotizaciones
        (SELECT COUNT(*)
         FROM Cotizacion) AS CotizacionesRegistradas,

        -- Materiales registrados este mes
        (SELECT COUNT(*)
         FROM Material) AS MaterialesEsteMes,

        -- Clientes registrados este mes
        (SELECT COUNT(*)
         FROM Cliente
         WHERE MONTH(FechaRegistro) = MONTH(GETDATE())
           AND YEAR(FechaRegistro) = YEAR(GETDATE())) AS ClientesEsteMes,

        -- Cotizaciones registradas este mes
        (SELECT COUNT(*)
         FROM Cotizacion
         WHERE MONTH(Fecha) = MONTH(GETDATE())
           AND YEAR(Fecha) = YEAR(GETDATE())) AS CotizacionesEsteMes;
END;
GO


/* 2. PEDIDOS POR ESTADO */

CREATE OR ALTER PROCEDURE sp_Dashboard_PedidosEstado
    @Mes INT = NULL,
    @Anio INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Estado,
        COUNT(*) AS Cantidad
    FROM Pedido
    WHERE
        (@Mes IS NULL OR MONTH(FechaDePedido) = @Mes)
        AND
        (@Anio IS NULL OR YEAR(FechaDePedido) = @Anio)
    GROUP BY Estado
    ORDER BY Cantidad DESC;
END;
GO


/* 3. COTIZACIONES POR ESTADO */

CREATE OR ALTER PROCEDURE sp_Dashboard_CotizacionesEstado
    @Mes INT = NULL,
    @Anio INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Estado,
        COUNT(*) AS Cantidad
    FROM Cotizacion
    WHERE
        (@Mes IS NULL OR MONTH(Fecha) = @Mes)
        AND
        (@Anio IS NULL OR YEAR(Fecha) = @Anio)
    GROUP BY Estado
    ORDER BY Cantidad DESC;
END;
GO


/* 4. VENTAS MENSUALES */

CREATE OR ALTER PROCEDURE sp_Dashboard_VentasMensuales
    @Anio INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        MONTH([Fecha de Venta]) AS NumeroMes,
        CASE MONTH([Fecha de Venta])
            WHEN 1 THEN 'Ene'
            WHEN 2 THEN 'Feb'
            WHEN 3 THEN 'Mar'
            WHEN 4 THEN 'Abr'
            WHEN 5 THEN 'May'
            WHEN 6 THEN 'Jun'
            WHEN 7 THEN 'Jul'
            WHEN 8 THEN 'Ago'
            WHEN 9 THEN 'Sep'
            WHEN 10 THEN 'Oct'
            WHEN 11 THEN 'Nov'
            WHEN 12 THEN 'Dic'
        END AS Mes,
        ISNULL(SUM([Total a Pagar]), 0) AS TotalVentas
    FROM VerVentas
    WHERE
        @Anio IS NULL
        OR YEAR([Fecha de Venta]) = @Anio
    GROUP BY
        MONTH([Fecha de Venta])
    ORDER BY
        MONTH([Fecha de Venta]);
END;
GO
CREATE PROCEDURE sp_Dashboard_InventarioEstado
AS
BEGIN

    SELECT
        'Agotados' AS EstadoInventario,
        COUNT(*) AS Cantidad
    FROM VerMaterial
    WHERE Stock = 0

    UNION ALL

    SELECT
        'Por agotarse' AS EstadoInventario,
        COUNT(*) AS Cantidad
    FROM VerMaterial
    WHERE Stock BETWEEN 1 AND 15

    UNION ALL

    SELECT
        'Disponibles' AS EstadoInventario,
        COUNT(*) AS Cantidad
    FROM VerMaterial
    WHERE Stock > 15;

END
GO
---Indicador de pedidos activos para dashboard de Secretario
CREATE PROCEDURE sp_ContarPedidosActivos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS TotalPedidosActivos
    FROM Pedido
    WHERE Estado = 'En proceso';
END;
GO


USE MueblesKeyda;
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