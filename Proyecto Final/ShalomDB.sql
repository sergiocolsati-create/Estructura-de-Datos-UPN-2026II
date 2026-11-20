--=====================
-- SHALOM_ESTRC.DTS
--=====================
IF DB_ID('ShalomDB_Final') IS NULL
    CREATE DATABASE ShalomDB_Final;
GO

USE ShalomDB_Final;
GO

--=====================================================
-- BORRAR TABLAS (para poder volver a ejecutar el script)
-- Orden inverso a las claves foráneas: primero las que
-- dependen de otras. ¡Se pierden los datos registrados!
--=====================================================
DROP TABLE IF EXISTS Usuario;          -- Primero: depende de Sede
DROP TABLE IF EXISTS ParadaRuta;
DROP TABLE IF EXISTS HistorialEnvio;
DROP TABLE IF EXISTS Envio;
DROP TABLE IF EXISTS Tarifa;
DROP TABLE IF EXISTS Vehiculo;
DROP TABLE IF EXISTS Persona;
DROP TABLE IF EXISTS Sede;
GO

--=====================
-- CREACION DE TABLAS
--=====================

CREATE TABLE Sede (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(5) NOT NULL UNIQUE,
    Nombre NVARCHAR(50) NOT NULL,
    Ciudad NVARCHAR(50) NOT NULL,
    Direccion NVARCHAR(150) NULL
);

-- Usuarios que pueden entrar al sistema (login).
-- Cada uno tiene su nombre y la sede donde trabaja.
-- Activo = 0 permite bloquear a alguien sin borrarlo.
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(30) NOT NULL UNIQUE,
    Contrasena VARCHAR(60) NOT NULL,
    Nombres NVARCHAR(100) NOT NULL,
    SedeId INT NULL REFERENCES Sede(Id),
    Activo BIT NOT NULL DEFAULT 1,
    UltimoAcceso DATETIME NULL
);

CREATE TABLE Persona (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoDocumento VARCHAR(5) NOT NULL,
    NumeroDocumento VARCHAR(15) NOT NULL UNIQUE,
    Nombres NVARCHAR(100) NOT NULL,
    Telefono VARCHAR(15) NULL
    -- El formato de DNI (8 dígitos) y teléfono (9 dígitos) se valida en el formulario.
    -- Aquí solo queda la regla de que no se repitan (UNIQUE), como respaldo.
);

CREATE UNIQUE INDEX UX_Persona_Telefono
ON Persona(Telefono)
WHERE Telefono IS NOT NULL;

CREATE TABLE Vehiculo (
    Placa VARCHAR(10) PRIMARY KEY,
    Conductor NVARCHAR(100) NOT NULL,
    CapacidadKg DECIMAL(10,2) NOT NULL
        CHECK (CapacidadKg > 0)
);

CREATE TABLE Tarifa (
    SedeOrigenId INT NOT NULL REFERENCES Sede(Id),
    SedeDestinoId INT NOT NULL REFERENCES Sede(Id),
    PrecioBase DECIMAL(10,2) NOT NULL
        CHECK (PrecioBase > 0),
    PrecioPorKg DECIMAL(10,2) NOT NULL
        CHECK (PrecioPorKg >= 0),
    PRIMARY KEY (SedeOrigenId, SedeDestinoId),
    CHECK (SedeOrigenId <> SedeDestinoId)
);

CREATE TABLE Envio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL UNIQUE,
    ClaveSeguridad VARCHAR(4) NOT NULL,
    SedeOrigenId INT NOT NULL REFERENCES Sede(Id),
    SedeDestinoId INT NOT NULL REFERENCES Sede(Id),
    RemitenteId INT NOT NULL REFERENCES Persona(Id),
    DestinatarioId INT NOT NULL REFERENCES Persona(Id),

    Tipo VARCHAR(10) NOT NULL
        CHECK (Tipo IN ('Caja', 'Sobre')),

    Descripcion NVARCHAR(200) NULL,

    PesoKg DECIMAL(10,2) NOT NULL
        CHECK (PesoKg > 0),

    Precio DECIMAL(10,2) NOT NULL
        CHECK (Precio >= 0),

    ModalidadPago VARCHAR(25) NOT NULL
        CHECK (ModalidadPago IN (
            'PagadoEnOrigen',
            'PorCobrarEnDestino'
        )),

    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    FechaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),

    Estado VARCHAR(20) NOT NULL DEFAULT 'Registrado'
        CHECK (Estado IN (
            'Registrado',
            'EnPreparacion',
            'EnTransito',
            'EnReparto',
            'Entregado',
            'Incidencia'
        )),

    PlacaVehiculo VARCHAR(10) NULL
        REFERENCES Vehiculo(Placa)
);

CREATE TABLE HistorialEnvio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CodigoEnvio VARCHAR(20) NOT NULL
        REFERENCES Envio(Codigo),

    Fecha DATETIME NOT NULL,

    Estado VARCHAR(20) NOT NULL
        CHECK (Estado IN (
            'Registrado',
            'EnPreparacion',
            'EnTransito',
            'EnReparto',
            'Entregado',
            'Incidencia'
        )),

    Ubicacion NVARCHAR(100) NULL,
    Observacion NVARCHAR(200) NULL,
    PendienteSincronizar BIT NOT NULL DEFAULT 0
);

CREATE TABLE ParadaRuta (
    Id INT IDENTITY(1,1) PRIMARY KEY,

    PlacaVehiculo VARCHAR(10) NOT NULL
        REFERENCES Vehiculo(Placa),

    CodigoEnvio VARCHAR(20) NOT NULL
        REFERENCES Envio(Codigo),

    Orden INT NOT NULL CHECK (Orden > 0),

    CONSTRAINT UQ_ParadaRuta_Vehiculo_Orden
        UNIQUE (PlacaVehiculo, Orden),

    CONSTRAINT UQ_ParadaRuta_Vehiculo_Envio
        UNIQUE (PlacaVehiculo, CodigoEnvio)
);
GO

--==================
-- DATOS DE PRUEBA
--==================

INSERT INTO Sede (Codigo, Nombre, Ciudad, Direccion)
VALUES
('LIM', N'Sede Lima', N'Lima', N'Direccion ficticia 100'),
('ARE', N'Sede Arequipa', N'Arequipa', N'Direccion ficticia 200'),
('TRU', N'Sede Trujillo', N'Trujillo', N'Direccion ficticia 300'),
('CUS', N'Sede Cusco', N'Cusco', N'Direccion ficticia 400');

--====================
-- USUARIOS DEL SISTEMA (integrantes del grupo)
-- Usuario    = inicial del primer nombre + primer apellido
-- Contraseña = código de alumno (distingue mayúsculas: N mayúscula)
--====================

INSERT INTO Usuario (NombreUsuario, Contrasena, Nombres, SedeId, Activo)
VALUES
('amoscoso',   'N00574312', N'Alfonso David Moscoso Yparraguirre', 1, 1),
('aquezada',   'N00474619', N'Anshely Aznaila Quezada Prado',      1, 1),
('ecastaneda', 'N00480736', N'Estrella Valeria Castañeda Rivas',   1, 0),
('scolan',     'N00525394', N'Sergio Isaac Colán Sánchez',         1, 1),
('yacori',     'N00469214', N'Yanela Liz Acori Sanchez',           1, 1);

--====================
-- TARIFAS POR TRAYECTO
--====================

INSERT INTO Tarifa
    (SedeOrigenId, SedeDestinoId, PrecioBase, PrecioPorKg)
SELECT
    origen.Id,
    destino.Id,
    datos.PrecioBase,
    datos.PrecioPorKg
FROM (
    VALUES
        ('LIM', 'CUS', 12.00, 3.00),
        ('LIM', 'TRU', 8.00, 2.00),
        ('LIM', 'ARE', 10.00, 2.50),
        ('CUS', 'LIM', 12.00, 3.00),
        ('CUS', 'TRU', 15.00, 3.50),
        ('CUS', 'ARE', 10.00, 2.50),
        ('TRU', 'LIM', 8.00, 2.00),
        ('TRU', 'CUS', 15.00, 3.50),
        ('TRU', 'ARE', 14.00, 3.00),
        ('ARE', 'LIM', 10.00, 2.50),
        ('ARE', 'CUS', 10.00, 2.50),
        ('ARE', 'TRU', 14.00, 3.00)
) AS datos (Origen, Destino, PrecioBase, PrecioPorKg)

INNER JOIN Sede AS origen
    ON origen.Codigo = datos.Origen

INNER JOIN Sede AS destino
    ON destino.Codigo = datos.Destino;

--====================
-- PERSONAS DE PRUEBA (16 originales + 34 nuevas, datos ficticios)
--====================

-- Se indica el Id para que RemitenteId y DestinatarioId apunten siempre a la misma persona
SET IDENTITY_INSERT Persona ON;

INSERT INTO Persona
(Id, TipoDocumento, NumeroDocumento, Nombres, Telefono)
VALUES
(1, 'DNI','70000001',N'Persona Prueba Uno','900000001'),
(2, 'DNI','80000001',N'Persona Destino Uno','900000002'),
(3, 'DNI','70000002',N'Persona Prueba Dos','900000003'),
(4, 'DNI','80000002',N'Persona Destino Dos','900000004'),
(5, 'DNI','70000003',N'Persona Prueba Tres','900000005'),
(6, 'DNI','80000003',N'Persona Destino Tres','900000006'),
(7, 'DNI','70000004',N'Persona Prueba Cuatro','900000007'),
(8, 'DNI','80000004',N'Persona Destino Cuatro','900000008'),
(9, 'DNI','70000005',N'Persona Prueba Cinco','900000009'),
(10, 'DNI','80000005',N'Persona Destino Cinco','900000010'),
(11, 'DNI','70000006',N'Persona Prueba Seis','900000011'),
(12, 'DNI','80000006',N'Persona Destino Seis','900000012'),
(13, 'DNI','70000007',N'Persona Prueba Siete','900000013'),
(14, 'DNI','80000007',N'Persona Destino Siete','900000014'),
(15, 'DNI','70000008',N'Persona Prueba Ocho','900000015'),
(16, 'DNI','80000008',N'Persona Destino Ocho','900000016'),
(17, 'DNI','71230122',N'María Fernanda Quispe Huamán','910000041'),
(18, 'DNI','71231886',N'José Luis Mamani Condori','910104795'),
(19, 'DNI','71233405',N'Rosa Elena Flores Ccori','910209472'),
(20, 'DNI','71234342',N'Carlos Alberto Rojas Paredes','910314264'),
(21, 'DNI','71236121',N'Lucía Milagros Chávez Ríos','910418988'),
(22, 'DNI','71237286',N'Pedro Pablo Salazar Vega','910523719'),
(23, 'DNI','71238787',N'Ana Sofía Gutiérrez León','910628468'),
(24, 'DNI','71240393',N'Jorge Enrique Ramírez Soto','910733202'),
(25, 'DNI','71241471',N'Carmen Rosa Huanca Apaza','910837929'),
(26, 'DNI','71243131',N'Diego Armando Torres Cruz','910942637'),
(27, 'DNI','71244162',N'Valeria Nicole Castro Medina','911047321'),
(28, 'DNI','71245084',N'Luis Fernando Vargas Ortiz','911152098'),
(29, 'DNI','71246535',N'Gabriela Andrea Ponce Ruiz','911256763'),
(30, 'DNI','71248118',N'Miguel Ángel Ccahuana Quispe','911361490'),
(31, 'DNI','71249655',N'Patricia Isabel Zúñiga Rivas','911466208'),
(32, 'DNI','71251400',N'Ricardo Javier Mendoza Llanos','911571023'),
(33, 'DNI','71252439',N'Daniela Alejandra Ríos Pinto','911675751'),
(34, 'DNI','71253629',N'Fernando José Aguilar Tapia','911780420'),
(35, 'DNI','71255085',N'Claudia Beatriz Silva Romero','911885155'),
(36, 'DNI','71256406',N'Héctor Manuel Cárdenas Luna','911989897'),
(37, 'DNI','71258245',N'Jimena Paola Benites Vera','912094629'),
(38, 'DNI','71259555',N'Raúl Ernesto Paucar Mayta','912199375'),
(39, 'DNI','71260816',N'Sandra Liliana Herrera Olivos','912304048'),
(40, 'DNI','71262274',N'Óscar Iván Delgado Campos','912408811'),
(41, 'DNI','71262996',N'Milagros del Pilar Arias Neyra','912513568'),
(42, 'DNI','71264826',N'Kevin Josué Palomino Ruiz','912618263'),
(43, 'DNI','71265941',N'Fiorella Andrea Yupanqui Soto','912723013'),
(44, 'DNI','71267162',N'Martín Alonso Espinoza Tello','912827766'),
(45, 'DNI','71269109',N'Katherine Lizeth Ramos Díaz','912932504'),
(46, 'DNI','71270351',N'Renato César Huamaní Pari','913037181'),
(47, 'DNI','71271156',N'Brenda Sofía Lazo Cáceres','913141961'),
(48, 'DNI','71272879',N'Álvaro Daniel Núñez Ccama','913246646'),
(49, 'DNI','71274345',N'Noemí Esther Villanueva Puma','913351383'),
(50, 'DNI','71275336',N'Julio César Quiroz Alarcón','913456109');

SET IDENTITY_INSERT Persona OFF;

--====================
-- VEHICULOS (6)
--====================

INSERT INTO Vehiculo (Placa, Conductor, CapacidadKg)
VALUES
('ABC-123', N'Juan Pérez', 500),
('XYZ-789', N'Luis Ramos', 800),
('DEF-456', N'Carlos Mendoza', 600),
('GHI-321', N'Miguel Torres', 750),
('JKL-654', N'Andrés Castillo', 1000),
('MNO-987', N'Pedro Vargas', 900);

--====================
-- ENVIOS DE PRUEBA (102, ficticios, de agosto a noviembre de 2026)
--   Registrado    → cola de Recepción        (18)
--   EnPreparacion → cola del Almacén         (18)
--   EnTransito    → pila de cada vehículo    (3 por vehículo = 18)
--   EnReparto     → ruta de cada vehículo    (3 por vehículo = 18)
--   Entregado     → solo historial/reportes  (30)
-- La guía sigue el formato del sistema: ORIGEN-DESTINO-Id (6 dígitos).
-- Cada vehículo sale de una sede: ABC-123, XYZ-789 y JKL-654 de Lima,
-- DEF-456 de Arequipa, GHI-321 de Trujillo y MNO-987 de Cusco.
-- Precio = PrecioBase + PesoKg × PrecioPorKg (tabla Tarifa).
--====================

-- Se indica el Id para que coincida con el número de la guía (LIM-ARE-000007 → Id 7)
SET IDENTITY_INSERT Envio ON;

INSERT INTO Envio
(
    Id, Codigo, ClaveSeguridad,
    SedeOrigenId, SedeDestinoId,
    RemitenteId, DestinatarioId,
    Tipo, Descripcion, PesoKg, Precio,
    ModalidadPago, FechaRegistro, FechaActualizacion, Estado, PlacaVehiculo
)
VALUES
(1, 'TRU-LIM-000001','2010',3,1,11,40,'Caja',N'Artesanía en cerámica',25.5,59.00,'PagadoEnOrigen','2026-08-03T16:40:00','2026-08-07T10:59:00','Entregado','GHI-321'),
(2, 'LIM-ARE-000002','5341',1,2,20,29,'Sobre',N'Facturas originales',0.82,12.05,'PagadoEnOrigen','2026-08-07T13:40:00','2026-08-10T11:09:00','Entregado','ABC-123'),
(3, 'LIM-TRU-000003','5077',1,3,16,2,'Caja',N'Artesanía en cerámica',1.5,11.00,'PagadoEnOrigen','2026-08-09T08:45:00','2026-08-11T20:07:00','Entregado','JKL-654'),
(4, 'CUS-LIM-000004','0789',4,1,42,35,'Sobre',N'Documentos legales',1.4,16.20,'PagadoEnOrigen','2026-08-09T16:45:00','2026-08-12T15:59:00','Entregado','MNO-987'),
(5, 'ARE-TRU-000005','0229',2,3,10,29,'Caja',N'Frutos secos',7.6,36.80,'PagadoEnOrigen','2026-08-09T18:30:00','2026-08-12T18:24:00','Entregado','DEF-456'),
(6, 'LIM-TRU-000006','2568',1,3,2,23,'Caja',N'Café orgánico',29.3,66.60,'PagadoEnOrigen','2026-08-12T15:40:00','2026-08-15T10:32:00','Entregado','ABC-123'),
(7, 'LIM-CUS-000007','2069',1,4,28,38,'Caja',N'Ropa de temporada',23.3,81.90,'PagadoEnOrigen','2026-08-17T16:40:00','2026-08-20T07:19:00','Entregado','ABC-123'),
(8, 'CUS-LIM-000008','3047',4,1,9,11,'Caja',N'Medicamentos sin receta',8.4,37.20,'PagadoEnOrigen','2026-08-25T15:00:00','2026-08-28T05:06:00','Entregado','MNO-987'),
(9, 'ARE-LIM-000009','8020',2,1,30,34,'Sobre',N'Certificados de estudios',1.05,12.62,'PagadoEnOrigen','2026-08-26T12:30:00','2026-08-29T12:16:00','Entregado','DEF-456'),
(10, 'LIM-CUS-000010','0550',1,4,36,43,'Caja',N'Frutos secos',17.9,65.70,'PagadoEnOrigen','2026-09-03T15:50:00','2026-09-06T18:10:00','Entregado','XYZ-789'),
(11, 'TRU-ARE-000011','1738',3,2,25,1,'Caja',N'Juguetes educativos',18.7,70.10,'PagadoEnOrigen','2026-09-09T16:45:00','2026-09-12T14:34:00','Entregado','GHI-321'),
(12, 'CUS-ARE-000012','2209',4,2,45,47,'Caja',N'Cuadernos y papelería',20.5,61.25,'PorCobrarEnDestino','2026-09-15T10:00:00','2026-09-18T02:15:00','Entregado','MNO-987'),
(13, 'ARE-TRU-000013','8869',2,3,35,2,'Caja',N'Café orgánico',27.3,95.90,'PorCobrarEnDestino','2026-09-19T14:20:00','2026-09-23T01:24:00','Entregado','DEF-456'),
(14, 'TRU-LIM-000014','5156',3,1,27,17,'Sobre',N'Tarjetas de presentación',0.56,9.12,'PagadoEnOrigen','2026-09-20T12:15:00','2026-09-23T23:37:00','Entregado','GHI-321'),
(15, 'TRU-ARE-000015','7484',3,2,41,45,'Caja',N'Artesanía en cerámica',29.9,103.70,'PorCobrarEnDestino','2026-09-24T15:15:00','2026-09-28T08:22:00','Entregado','GHI-321'),
(16, 'LIM-ARE-000016','8152',1,2,17,30,'Caja',N'Café orgánico',7.4,28.50,'PagadoEnOrigen','2026-09-24T16:45:00','2026-09-28T15:06:00','Entregado','JKL-654'),
(17, 'LIM-CUS-000017','4399',1,4,49,35,'Caja',N'Repuestos de motocicleta',9.4,40.20,'PorCobrarEnDestino','2026-09-27T17:10:00','2026-09-30T08:13:00','Entregado','ABC-123'),
(18, 'LIM-CUS-000018','6975',1,4,29,12,'Caja',N'Zapatillas deportivas',33.7,113.10,'PorCobrarEnDestino','2026-09-28T09:50:00','2026-10-02T21:11:00','Entregado','JKL-654'),
(19, 'LIM-CUS-000019','3511',1,4,18,7,'Caja',N'Medicamentos sin receta',5.1,27.30,'PagadoEnOrigen','2026-09-29T10:40:00','2026-10-03T20:39:00','Entregado','JKL-654'),
(20, 'TRU-CUS-000020','5837',3,4,25,19,'Caja',N'Zapatillas deportivas',18.0,78.00,'PagadoEnOrigen','2026-09-29T14:10:00','2026-10-03T20:45:00','Entregado','GHI-321'),
(21, 'ARE-LIM-000021','3822',2,1,30,39,'Caja',N'Útiles escolares',8.0,30.00,'PorCobrarEnDestino','2026-09-29T17:15:00','2026-10-04T13:43:00','Entregado','DEF-456'),
(22, 'LIM-CUS-000022','2623',1,4,27,43,'Caja',N'Libros universitarios',18.2,66.60,'PagadoEnOrigen','2026-09-30T17:15:00','2026-10-04T21:17:00','Entregado','XYZ-789'),
(23, 'TRU-CUS-000023','1680',3,4,46,34,'Sobre',N'Documentos legales',0.37,16.30,'PorCobrarEnDestino','2026-10-01T16:00:00','2026-10-06T02:19:00','Entregado','GHI-321'),
(24, 'TRU-ARE-000024','4237',3,2,26,34,'Caja',N'Cuadernos y papelería',26.5,93.50,'PagadoEnOrigen','2026-10-10T15:10:00','2026-10-13T14:03:00','Entregado','GHI-321'),
(25, 'CUS-ARE-000025','5836',4,2,44,4,'Sobre',N'Documentos legales',0.77,11.93,'PorCobrarEnDestino','2026-10-11T10:10:00','2026-10-15T02:33:00','Entregado','MNO-987'),
(26, 'LIM-CUS-000026','2644',1,4,19,21,'Caja',N'Libros universitarios',21.0,75.00,'PagadoEnOrigen','2026-10-22T18:10:00','2026-10-26T00:22:00','Entregado','XYZ-789'),
(27, 'CUS-LIM-000027','0714',4,1,19,40,'Caja',N'Ropa de temporada',10.5,43.50,'PagadoEnOrigen','2026-10-27T12:10:00','2026-10-28T05:04:00','EnPreparacion',NULL),
(28, 'LIM-TRU-000028','9957',1,3,26,21,'Caja',N'Repuestos de motocicleta',21.6,51.20,'PagadoEnOrigen','2026-10-27T16:40:00','2026-10-30T08:36:00','Entregado','ABC-123'),
(29, 'TRU-LIM-000029','9221',3,1,37,19,'Caja',N'Juguetes educativos',10.5,29.00,'PagadoEnOrigen','2026-10-27T17:20:00','2026-10-31T03:50:00','Entregado','GHI-321'),
(30, 'CUS-LIM-000030','3335',4,1,8,12,'Caja',N'Café orgánico',13.0,51.00,'PorCobrarEnDestino','2026-10-28T11:20:00','2026-10-28T23:37:00','EnPreparacion',NULL),
(31, 'TRU-CUS-000031','8874',3,4,32,4,'Caja',N'Herramientas manuales',20.8,87.80,'PagadoEnOrigen','2026-10-28T16:15:00','2026-10-29T07:59:00','EnPreparacion',NULL),
(32, 'ARE-CUS-000032','2767',2,4,18,42,'Sobre',N'Tarjetas de presentación',1.18,12.95,'PagadoEnOrigen','2026-10-31T11:15:00','2026-10-31T21:10:00','EnPreparacion',NULL),
(33, 'CUS-ARE-000033','6826',4,2,20,50,'Caja',N'Artesanía en cerámica',10.8,37.00,'PagadoEnOrigen','2026-10-31T14:00:00','2026-11-02T19:16:00','Entregado','MNO-987'),
(34, 'ARE-CUS-000034','7846',2,4,42,33,'Caja',N'Piezas de computadora',34.9,97.25,'PagadoEnOrigen','2026-10-31T16:30:00','2026-11-02T13:58:00','Entregado','DEF-456'),
(35, 'LIM-ARE-000035','8533',1,2,49,39,'Caja',N'Libros universitarios',26.5,76.25,'PagadoEnOrigen','2026-10-31T16:30:00','2026-11-01T06:01:00','EnPreparacion',NULL),
(36, 'CUS-TRU-000036','5983',4,3,19,48,'Caja',N'Zapatillas deportivas',23.0,95.50,'PagadoEnOrigen','2026-11-01T14:00:00','2026-11-02T09:25:00','EnPreparacion',NULL),
(37, 'LIM-TRU-000037','9213',1,3,14,46,'Sobre',N'Documentos legales',0.42,8.84,'PagadoEnOrigen','2026-11-03T10:30:00','2026-11-04T03:04:00','EnPreparacion',NULL),
(38, 'TRU-ARE-000038','6037',3,2,8,37,'Caja',N'Medicamentos sin receta',18.7,70.10,'PagadoEnOrigen','2026-11-03T14:00:00','2026-11-03T18:31:00','EnPreparacion',NULL),
(39, 'TRU-ARE-000039','6552',3,2,18,33,'Caja',N'Licuadora nueva',16.8,64.40,'PagadoEnOrigen','2026-11-05T15:40:00','2026-11-07T14:26:00','EnReparto','GHI-321'),
(40, 'LIM-TRU-000040','7087',1,3,11,21,'Caja',N'Herramientas manuales',10.0,28.00,'PorCobrarEnDestino','2026-11-06T09:10:00','2026-11-08T17:57:00','EnReparto','JKL-654'),
(41, 'LIM-CUS-000041','9711',1,4,3,48,'Caja',N'Productos de limpieza',19.6,70.80,'PorCobrarEnDestino','2026-11-06T09:15:00','2026-11-07T08:18:00','EnReparto','XYZ-789'),
(42, 'LIM-CUS-000042','1722',1,4,9,2,'Caja',N'Útiles escolares',1.7,17.10,'PagadoEnOrigen','2026-11-07T18:50:00','2026-11-07T23:24:00','EnPreparacion',NULL),
(43, 'TRU-LIM-000043','9675',3,1,38,31,'Caja',N'Artesanía en cerámica',15.9,39.80,'PagadoEnOrigen','2026-11-08T08:50:00','2026-11-08T12:17:00','EnPreparacion',NULL),
(44, 'LIM-TRU-000044','0154',1,3,13,48,'Caja',N'Mantas de alpaca',13.1,34.20,'PorCobrarEnDestino','2026-11-08T10:30:00','2026-11-09T14:39:00','EnReparto','XYZ-789'),
(45, 'TRU-ARE-000045','4892',3,2,44,35,'Caja',N'Medicamentos sin receta',25.7,91.10,'PagadoEnOrigen','2026-11-08T17:00:00','2026-11-11T02:57:00','EnReparto','GHI-321'),
(46, 'ARE-CUS-000046','7489',2,4,50,14,'Caja',N'Ropa de temporada',10.1,35.25,'PorCobrarEnDestino','2026-11-08T18:10:00','2026-11-10T15:33:00','EnReparto','DEF-456'),
(47, 'LIM-TRU-000047','9994',1,3,10,39,'Sobre',N'Certificados de estudios',0.59,9.18,'PagadoEnOrigen','2026-11-09T09:00:00','2026-11-11T10:05:00','EnTransito','XYZ-789'),
(48, 'CUS-LIM-000048','8102',4,1,16,15,'Caja',N'Café orgánico',15.7,59.10,'PagadoEnOrigen','2026-11-09T10:20:00','2026-11-10T14:52:00','EnTransito','MNO-987'),
(49, 'TRU-CUS-000049','7552',3,4,44,6,'Caja',N'Zapatillas deportivas',12.1,57.35,'PagadoEnOrigen','2026-11-09T14:00:00','2026-11-09T16:44:00','EnPreparacion',NULL),
(50, 'ARE-LIM-000050','5406',2,1,7,10,'Caja',N'Ropa de temporada',7.4,28.50,'PagadoEnOrigen','2026-11-09T17:40:00','2026-11-11T08:33:00','EnReparto','DEF-456'),
(51, 'LIM-CUS-000051','2471',1,4,44,33,'Caja',N'Herramientas manuales',17.0,63.00,'PorCobrarEnDestino','2026-11-10T08:00:00','2026-11-12T05:33:00','EnReparto','ABC-123'),
(52, 'ARE-TRU-000052','5591',2,3,15,31,'Sobre',N'Certificados de estudios',0.92,16.76,'PagadoEnOrigen','2026-11-10T08:30:00','2026-11-12T05:29:00','EnTransito','DEF-456'),
(53, 'CUS-LIM-000053','6781',4,1,44,10,'Sobre',N'Contrato firmado',0.27,12.81,'PorCobrarEnDestino','2026-11-10T10:50:00','2026-11-11T15:17:00','EnReparto','MNO-987'),
(54, 'LIM-CUS-000054','5389',1,4,28,18,'Caja',N'Accesorios de celular',6.2,30.60,'PagadoEnOrigen','2026-11-10T13:45:00','2026-11-13T09:09:00','EnReparto','JKL-654'),
(55, 'LIM-TRU-000055','9589',1,3,44,30,'Sobre',N'Expediente universitario',0.87,9.74,'PagadoEnOrigen','2026-11-10T13:50:00','2026-11-12T09:34:00','EnTransito','XYZ-789'),
(56, 'LIM-TRU-000056','9169',1,3,7,10,'Caja',N'Accesorios de celular',17.6,43.20,'PagadoEnOrigen','2026-11-10T16:50:00','2026-11-10T22:50:00','EnPreparacion',NULL),
(57, 'CUS-LIM-000057','3949',4,1,9,19,'Caja',N'Equipo de sonido pequeño',2.2,18.60,'PorCobrarEnDestino','2026-11-11T08:50:00','2026-11-11T09:51:00','EnPreparacion',NULL),
(58, 'LIM-TRU-000058','4939',1,3,25,17,'Sobre',N'Documentos legales',1.29,10.58,'PorCobrarEnDestino','2026-11-11T09:40:00','2026-11-13T05:01:00','EnTransito','XYZ-789'),
(59, 'LIM-CUS-000059','7524',1,4,24,23,'Caja',N'Juguetes educativos',12.7,50.10,'PorCobrarEnDestino','2026-11-11T13:20:00','2026-11-13T04:44:00','EnReparto','ABC-123'),
(60, 'TRU-ARE-000060','5337',3,2,36,44,'Caja',N'Accesorios de celular',25.4,90.20,'PagadoEnOrigen','2026-11-11T16:20:00','2026-11-13T08:58:00','EnTransito','GHI-321'),
(61, 'LIM-TRU-000061','4002',1,3,26,1,'Caja',N'Frutos secos',28.3,64.60,'PagadoEnOrigen','2026-11-12T10:50:00','2026-11-12T16:58:00','EnPreparacion',NULL),
(62, 'LIM-CUS-000062','2371',1,4,21,35,'Sobre',N'Contrato firmado',0.87,14.61,'PagadoEnOrigen','2026-11-12T14:40:00','2026-11-13T23:04:00','EnReparto','XYZ-789'),
(63, 'ARE-LIM-000063','7227',2,1,36,6,'Sobre',N'Tarjetas de presentación',0.22,10.55,'PorCobrarEnDestino','2026-11-12T14:50:00','2026-11-13T01:54:00','EnPreparacion',NULL),
(64, 'TRU-ARE-000064','7412',3,2,5,34,'Caja',N'Repuestos de motocicleta',3.7,25.10,'PorCobrarEnDestino','2026-11-12T16:10:00','2026-11-12T18:13:00','EnPreparacion',NULL),
(65, 'LIM-CUS-000065','2589',1,4,34,42,'Sobre',N'Certificados de estudios',0.71,14.13,'PorCobrarEnDestino','2026-11-12T17:30:00','2026-11-13T10:36:00','EnTransito','ABC-123'),
(66, 'CUS-ARE-000066','0567',4,2,33,41,'Caja',N'Equipo de sonido pequeño',34.3,95.75,'PagadoEnOrigen','2026-11-12T18:00:00','2026-11-13T10:55:00','EnPreparacion',NULL),
(67, 'ARE-TRU-000067','0192',2,3,31,22,'Caja',N'Cuadernos y papelería',21.8,79.40,'PagadoEnOrigen','2026-11-13T12:15:00','2026-11-15T01:18:00','EnReparto','DEF-456'),
(68, 'LIM-CUS-000068','5518',1,4,44,27,'Caja',N'Útiles escolares',1.7,17.10,'PagadoEnOrigen','2026-11-13T12:50:00','2026-11-15T18:10:00','EnTransito','JKL-654'),
(69, 'LIM-CUS-000069','7771',1,4,50,16,'Caja',N'Medicamentos sin receta',34.4,115.20,'PorCobrarEnDestino','2026-11-13T13:10:00','2026-11-13T13:10:00','Registrado',NULL),
(70, 'LIM-CUS-000070','7585',1,4,12,13,'Caja',N'Útiles escolares',17.8,65.40,'PagadoEnOrigen','2026-11-13T13:40:00','2026-11-15T06:48:00','EnReparto','JKL-654'),
(71, 'ARE-LIM-000071','2466',2,1,39,19,'Caja',N'Equipo de sonido pequeño',9.6,34.00,'PagadoEnOrigen','2026-11-13T17:30:00','2026-11-13T17:30:00','Registrado',NULL),
(72, 'CUS-LIM-000072','2967',4,1,22,39,'Caja',N'Cuadernos y papelería',19.9,71.70,'PagadoEnOrigen','2026-11-13T18:10:00','2026-11-13T18:10:00','Registrado',NULL),
(73, 'CUS-ARE-000073','8852',4,2,9,18,'Caja',N'Café orgánico',33.0,92.50,'PorCobrarEnDestino','2026-11-14T08:00:00','2026-11-16T04:21:00','EnReparto','MNO-987'),
(74, 'LIM-CUS-000074','8527',1,4,17,22,'Sobre',N'Certificados de estudios',1.33,15.99,'PorCobrarEnDestino','2026-11-14T09:15:00','2026-11-16T06:00:00','EnReparto','ABC-123'),
(75, 'TRU-ARE-000075','2856',3,2,5,36,'Caja',N'Café orgánico',12.5,51.50,'PagadoEnOrigen','2026-11-14T09:40:00','2026-11-15T21:38:00','EnReparto','GHI-321'),
(76, 'CUS-ARE-000076','4214',4,2,46,45,'Sobre',N'Certificados de estudios',0.32,10.80,'PagadoEnOrigen','2026-11-14T10:00:00','2026-11-16T06:34:00','EnTransito','MNO-987'),
(77, 'CUS-LIM-000077','9510',4,1,11,28,'Caja',N'Productos de limpieza',29.0,99.00,'PagadoEnOrigen','2026-11-14T10:30:00','2026-11-14T10:30:00','Registrado',NULL),
(78, 'CUS-TRU-000078','7216',4,3,20,41,'Caja',N'Juguetes educativos',30.1,120.35,'PorCobrarEnDestino','2026-11-14T10:45:00','2026-11-16T01:39:00','EnTransito','MNO-987'),
(79, 'CUS-ARE-000079','2875',4,2,22,48,'Caja',N'Ropa de temporada',1.4,13.50,'PorCobrarEnDestino','2026-11-14T12:15:00','2026-11-14T12:15:00','Registrado',NULL),
(80, 'ARE-LIM-000080','6310',2,1,7,15,'Caja',N'Café orgánico',23.6,69.00,'PagadoEnOrigen','2026-11-14T12:45:00','2026-11-14T12:45:00','Registrado',NULL),
(81, 'LIM-TRU-000081','9196',1,3,22,10,'Sobre',N'Contrato firmado',1.01,10.02,'PagadoEnOrigen','2026-11-14T12:50:00','2026-11-15T16:52:00','EnTransito','JKL-654'),
(82, 'ARE-TRU-000082','8028',2,3,3,42,'Caja',N'Zapatillas deportivas',12.1,50.30,'PagadoEnOrigen','2026-11-14T13:50:00','2026-11-15T20:21:00','EnTransito','DEF-456'),
(83, 'CUS-ARE-000083','6664',4,2,6,30,'Sobre',N'Certificados de estudios',0.67,11.68,'PagadoEnOrigen','2026-11-14T15:00:00','2026-11-15T17:32:00','EnReparto','MNO-987'),
(84, 'ARE-LIM-000084','8452',2,1,39,23,'Sobre',N'Tarjetas de presentación',0.72,11.80,'PorCobrarEnDestino','2026-11-15T08:10:00','2026-11-15T08:10:00','Registrado',NULL),
(85, 'LIM-ARE-000085','1650',1,2,9,46,'Caja',N'Zapatillas deportivas',19.6,59.00,'PagadoEnOrigen','2026-11-15T08:15:00','2026-11-16T18:42:00','EnTransito','ABC-123'),
(86, 'TRU-ARE-000086','8977',3,2,7,40,'Caja',N'Café orgánico',11.6,48.80,'PagadoEnOrigen','2026-11-15T15:45:00','2026-11-15T15:45:00','Registrado',NULL),
(87, 'TRU-LIM-000087','2150',3,1,47,10,'Caja',N'Accesorios de celular',25.0,58.00,'PorCobrarEnDestino','2026-11-15T16:20:00','2026-11-16T16:44:00','EnTransito','GHI-321'),
(88, 'TRU-CUS-000088','8323',3,4,14,28,'Caja',N'Herramientas manuales',2.0,22.00,'PorCobrarEnDestino','2026-11-15T18:10:00','2026-11-17T05:48:00','EnTransito','GHI-321'),
(89, 'ARE-CUS-000089','9161',2,4,44,38,'Caja',N'Medicamentos sin receta',20.3,60.75,'PagadoEnOrigen','2026-11-16T11:15:00','2026-11-17T22:42:00','EnTransito','DEF-456'),
(90, 'LIM-TRU-000090','2468',1,3,49,22,'Caja',N'Libros universitarios',4.3,16.60,'PagadoEnOrigen','2026-11-16T11:40:00','2026-11-16T11:40:00','Registrado',NULL),
(91, 'LIM-CUS-000091','0087',1,4,10,32,'Caja',N'Frutos secos',7.4,34.20,'PagadoEnOrigen','2026-11-16T16:50:00','2026-11-17T12:45:00','EnTransito','ABC-123'),
(92, 'LIM-ARE-000092','7188',1,2,25,18,'Sobre',N'Documentos legales',0.62,11.55,'PagadoEnOrigen','2026-11-16T17:10:00','2026-11-16T17:10:00','Registrado',NULL),
(93, 'LIM-TRU-000093','0172',1,3,47,12,'Caja',N'Mantas de alpaca',12.2,32.40,'PagadoEnOrigen','2026-11-16T18:20:00','2026-11-18T15:25:00','EnTransito','JKL-654'),
(94, 'CUS-TRU-000094','5528',4,3,39,33,'Sobre',N'Documentos legales',0.6,17.10,'PorCobrarEnDestino','2026-11-16T18:50:00','2026-11-16T18:50:00','Registrado',NULL),
(95, 'CUS-TRU-000095','1853',4,3,43,31,'Caja',N'Medicamentos sin receta',33.0,130.50,'PagadoEnOrigen','2026-11-17T09:20:00','2026-11-17T09:20:00','Registrado',NULL),
(96, 'TRU-ARE-000096','6554',3,2,45,16,'Sobre',N'Tarjetas de presentación',1.13,17.39,'PagadoEnOrigen','2026-11-17T10:30:00','2026-11-17T23:46:00','EnPreparacion',NULL),
(97, 'ARE-TRU-000097','8159',2,3,6,45,'Caja',N'Mantas de alpaca',5.7,31.10,'PorCobrarEnDestino','2026-11-18T13:15:00','2026-11-18T13:15:00','Registrado',NULL),
(98, 'TRU-LIM-000098','4319',3,1,35,25,'Caja',N'Piezas de computadora',11.3,30.60,'PagadoEnOrigen','2026-11-18T16:45:00','2026-11-18T16:45:00','Registrado',NULL),
(99, 'CUS-TRU-000099','3899',4,3,42,17,'Caja',N'Ropa de temporada',3.8,28.30,'PagadoEnOrigen','2026-11-18T17:40:00','2026-11-18T17:40:00','Registrado',NULL),
(100, 'TRU-LIM-000100','7134',3,1,31,11,'Sobre',N'Tarjetas de presentación',0.84,9.68,'PorCobrarEnDestino','2026-11-19T08:10:00','2026-11-19T08:10:00','Registrado',NULL),
(101, 'TRU-CUS-000101','8290',3,4,19,43,'Caja',N'Medicamentos sin receta',19.2,82.20,'PagadoEnOrigen','2026-11-19T14:20:00','2026-11-19T14:20:00','Registrado',NULL),
(102, 'TRU-LIM-000102','9578',3,1,16,36,'Caja',N'Licuadora nueva',15.6,39.20,'PagadoEnOrigen','2026-11-19T14:20:00','2026-11-19T14:20:00','Registrado',NULL);

SET IDENTITY_INSERT Envio OFF;

--====================
-- HISTORIAL DE ENVIOS
-- Cada envío tiene un evento por cada etapa por la que pasó.
-- Las incidencias solo agregan un evento (no cambian el estado del envío).
--====================

INSERT INTO HistorialEnvio
(CodigoEnvio, Fecha, Estado, Ubicacion, Observacion)
VALUES
('TRU-LIM-000001','2026-08-03T16:40:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('TRU-LIM-000001','2026-08-04T12:27:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('TRU-LIM-000001','2026-08-05T21:36:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('TRU-LIM-000001','2026-08-06T14:03:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('TRU-LIM-000001','2026-08-07T10:59:00','Entregado',N'Sede Lima',N'Entregado al destinatario'),
('LIM-ARE-000002','2026-08-07T13:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-ARE-000002','2026-08-07T17:46:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-ARE-000002','2026-08-08T00:28:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('LIM-ARE-000002','2026-08-08T18:17:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('LIM-TRU-000003','2026-08-09T08:45:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-TRU-000003','2026-08-09T11:53:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-LIM-000004','2026-08-09T16:45:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('ARE-TRU-000005','2026-08-09T18:30:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('ARE-TRU-000005','2026-08-09T21:06:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('LIM-TRU-000003','2026-08-10T08:57:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('CUS-LIM-000004','2026-08-10T09:04:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('LIM-ARE-000002','2026-08-10T11:09:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('ARE-TRU-000005','2026-08-10T17:00:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('ARE-TRU-000005','2026-08-11T01:11:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('LIM-TRU-000003','2026-08-11T03:56:00','EnReparto',N'Ruta JKL-654',N'Asignado a la ruta de reparto'),
('CUS-LIM-000004','2026-08-11T07:17:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('LIM-TRU-000003','2026-08-11T20:07:00','Entregado',N'Sede Trujillo',N'Entregado al destinatario'),
('CUS-LIM-000004','2026-08-11T21:16:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('LIM-TRU-000006','2026-08-12T15:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('CUS-LIM-000004','2026-08-12T15:59:00','Entregado',N'Sede Lima',N'Entregado al destinatario'),
('ARE-TRU-000005','2026-08-12T18:24:00','Entregado',N'Sede Trujillo',N'Entregado al destinatario'),
('LIM-TRU-000006','2026-08-12T19:00:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-TRU-000006','2026-08-13T09:43:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('LIM-TRU-000006','2026-08-14T05:36:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('LIM-TRU-000006','2026-08-15T10:32:00','Entregado',N'Sede Trujillo',N'Entregado al destinatario'),
('LIM-CUS-000007','2026-08-17T16:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000007','2026-08-18T08:09:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000007','2026-08-18T13:00:00','Incidencia',N'Rastreo',N'Caja con golpe leve, se re-embaló'),
('LIM-CUS-000007','2026-08-18T17:52:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('LIM-CUS-000007','2026-08-19T07:48:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('LIM-CUS-000007','2026-08-20T07:19:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('CUS-LIM-000008','2026-08-25T15:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('CUS-LIM-000008','2026-08-26T02:29:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('ARE-LIM-000009','2026-08-26T12:30:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('CUS-LIM-000008','2026-08-26T17:17:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('ARE-LIM-000009','2026-08-26T21:13:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('CUS-LIM-000008','2026-08-27T10:07:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('ARE-LIM-000009','2026-08-27T15:40:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('ARE-LIM-000009','2026-08-27T20:15:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('CUS-LIM-000008','2026-08-28T05:06:00','Entregado',N'Sede Lima',N'Entregado al destinatario'),
('ARE-LIM-000009','2026-08-29T12:16:00','Entregado',N'Sede Lima',N'Entregado al destinatario'),
('LIM-CUS-000010','2026-09-03T15:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000010','2026-09-03T19:39:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000010','2026-09-04T21:22:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-CUS-000010','2026-09-05T02:52:00','Incidencia',N'Rastreo',N'Bloqueo de vía, ruta alterna'),
('LIM-CUS-000010','2026-09-05T08:23:00','EnReparto',N'Ruta XYZ-789',N'Asignado a la ruta de reparto'),
('LIM-CUS-000010','2026-09-06T18:10:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('TRU-ARE-000011','2026-09-09T16:45:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('TRU-ARE-000011','2026-09-10T04:21:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('TRU-ARE-000011','2026-09-10T18:20:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('TRU-ARE-000011','2026-09-11T14:12:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('TRU-ARE-000011','2026-09-12T14:34:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('CUS-ARE-000012','2026-09-15T10:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('CUS-ARE-000012','2026-09-16T05:00:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('CUS-ARE-000012','2026-09-17T01:18:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('CUS-ARE-000012','2026-09-17T11:56:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('CUS-ARE-000012','2026-09-17T19:05:00','Incidencia',N'Rastreo',N'Bloqueo de vía, ruta alterna'),
('CUS-ARE-000012','2026-09-18T02:15:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('ARE-TRU-000013','2026-09-19T14:20:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('ARE-TRU-000013','2026-09-19T23:55:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('TRU-LIM-000014','2026-09-20T12:15:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('ARE-TRU-000013','2026-09-20T23:54:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('TRU-LIM-000014','2026-09-21T03:21:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('ARE-TRU-000013','2026-09-21T17:36:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('TRU-LIM-000014','2026-09-22T10:33:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('TRU-LIM-000014','2026-09-22T21:26:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('ARE-TRU-000013','2026-09-23T01:24:00','Entregado',N'Sede Trujillo',N'Entregado al destinatario'),
('TRU-LIM-000014','2026-09-23T23:37:00','Entregado',N'Sede Lima',N'Entregado al destinatario'),
('TRU-ARE-000015','2026-09-24T15:15:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-ARE-000016','2026-09-24T16:45:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-ARE-000016','2026-09-25T04:17:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('TRU-ARE-000015','2026-09-25T07:19:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('TRU-ARE-000015','2026-09-25T18:52:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('TRU-ARE-000015','2026-09-26T09:04:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('LIM-ARE-000016','2026-09-26T18:48:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('LIM-ARE-000016','2026-09-27T05:51:00','EnReparto',N'Ruta JKL-654',N'Asignado a la ruta de reparto'),
('LIM-CUS-000017','2026-09-27T17:10:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000017','2026-09-27T21:55:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('TRU-ARE-000015','2026-09-28T08:22:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('LIM-CUS-000018','2026-09-28T09:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-ARE-000016','2026-09-28T15:06:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('LIM-CUS-000018','2026-09-28T17:35:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000017','2026-09-29T09:41:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('LIM-CUS-000019','2026-09-29T10:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-CUS-000020','2026-09-29T14:10:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('ARE-LIM-000021','2026-09-29T17:15:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-CUS-000018','2026-09-29T20:05:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('LIM-CUS-000017','2026-09-29T20:06:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('LIM-CUS-000019','2026-09-29T22:31:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('TRU-CUS-000020','2026-09-30T02:39:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-CUS-000017','2026-09-30T08:13:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('LIM-CUS-000018','2026-09-30T09:36:00','EnReparto',N'Ruta JKL-654',N'Asignado a la ruta de reparto'),
('ARE-LIM-000021','2026-09-30T10:00:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('LIM-CUS-000022','2026-09-30T17:15:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000022','2026-09-30T21:53:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('TRU-CUS-000020','2026-09-30T22:30:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('LIM-CUS-000019','2026-10-01T05:21:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('LIM-CUS-000019','2026-10-01T11:32:00','EnReparto',N'Ruta JKL-654',N'Asignado a la ruta de reparto'),
('ARE-LIM-000021','2026-10-01T12:46:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('TRU-CUS-000020','2026-10-01T14:58:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('TRU-CUS-000023','2026-10-01T16:00:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('ARE-LIM-000021','2026-10-02T03:36:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('TRU-CUS-000023','2026-10-02T08:27:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-CUS-000022','2026-10-02T13:11:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-CUS-000018','2026-10-02T21:11:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('LIM-CUS-000022','2026-10-03T03:54:00','EnReparto',N'Ruta XYZ-789',N'Asignado a la ruta de reparto'),
('TRU-CUS-000023','2026-10-03T10:23:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('LIM-CUS-000019','2026-10-03T20:39:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('TRU-CUS-000020','2026-10-03T20:45:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('TRU-CUS-000023','2026-10-03T23:27:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('ARE-LIM-000021','2026-10-04T13:43:00','Entregado',N'Sede Lima',N'Entregado al destinatario'),
('LIM-CUS-000022','2026-10-04T21:17:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('TRU-CUS-000023','2026-10-06T02:19:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('TRU-ARE-000024','2026-10-10T15:10:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('TRU-ARE-000024','2026-10-11T05:02:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('CUS-ARE-000025','2026-10-11T10:10:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('TRU-ARE-000024','2026-10-11T23:15:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('CUS-ARE-000025','2026-10-12T00:21:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('TRU-ARE-000024','2026-10-12T01:44:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('CUS-ARE-000025','2026-10-13T07:27:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('TRU-ARE-000024','2026-10-13T14:03:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('CUS-ARE-000025','2026-10-13T21:25:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('CUS-ARE-000025','2026-10-15T02:33:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('LIM-CUS-000026','2026-10-22T18:10:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000026','2026-10-23T11:32:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000026','2026-10-23T17:52:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-CUS-000026','2026-10-24T08:09:00','EnReparto',N'Ruta XYZ-789',N'Asignado a la ruta de reparto'),
('LIM-CUS-000026','2026-10-26T00:22:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('CUS-LIM-000027','2026-10-27T12:10:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('LIM-TRU-000028','2026-10-27T16:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-LIM-000029','2026-10-27T17:20:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000028','2026-10-27T19:10:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-LIM-000027','2026-10-28T05:04:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('CUS-LIM-000030','2026-10-28T11:20:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('TRU-LIM-000029','2026-10-28T12:46:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('TRU-CUS-000031','2026-10-28T16:15:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000028','2026-10-28T21:45:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('CUS-LIM-000030','2026-10-28T23:37:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('LIM-TRU-000028','2026-10-29T00:32:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('TRU-CUS-000031','2026-10-29T07:59:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('TRU-LIM-000029','2026-10-30T04:04:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('TRU-LIM-000029','2026-10-30T07:55:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('LIM-TRU-000028','2026-10-30T08:36:00','Entregado',N'Sede Trujillo',N'Entregado al destinatario'),
('TRU-LIM-000029','2026-10-31T03:50:00','Entregado',N'Sede Lima',N'Entregado al destinatario'),
('ARE-CUS-000032','2026-10-31T11:15:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('CUS-ARE-000033','2026-10-31T14:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('ARE-CUS-000034','2026-10-31T16:30:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-ARE-000035','2026-10-31T16:30:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('ARE-CUS-000034','2026-10-31T19:28:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('ARE-CUS-000032','2026-10-31T21:10:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('ARE-CUS-000034','2026-10-31T23:47:00','Incidencia',N'Rastreo',N'Paquete mal rotulado, se corrigió la etiqueta'),
('CUS-ARE-000033','2026-11-01T04:06:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('ARE-CUS-000034','2026-11-01T04:07:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('LIM-ARE-000035','2026-11-01T06:01:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-ARE-000033','2026-11-01T12:13:00','Incidencia',N'Rastreo',N'Caja con golpe leve, se re-embaló'),
('ARE-CUS-000034','2026-11-01T13:55:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('CUS-TRU-000036','2026-11-01T14:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('CUS-ARE-000033','2026-11-01T20:20:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('CUS-ARE-000033','2026-11-02T07:07:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('CUS-TRU-000036','2026-11-02T09:25:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('ARE-CUS-000034','2026-11-02T13:58:00','Entregado',N'Sede Cusco',N'Entregado al destinatario'),
('CUS-ARE-000033','2026-11-02T19:16:00','Entregado',N'Sede Arequipa',N'Entregado al destinatario'),
('LIM-TRU-000037','2026-11-03T10:30:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-ARE-000038','2026-11-03T14:00:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('TRU-ARE-000038','2026-11-03T18:31:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-TRU-000037','2026-11-04T03:04:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('TRU-ARE-000039','2026-11-05T15:40:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000040','2026-11-06T09:10:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000041','2026-11-06T09:15:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-ARE-000039','2026-11-06T10:58:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-TRU-000040','2026-11-06T13:51:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000041','2026-11-06T18:04:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000041','2026-11-07T04:02:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-CUS-000041','2026-11-07T08:18:00','EnReparto',N'Ruta XYZ-789',N'Asignado a la ruta de reparto'),
('TRU-ARE-000039','2026-11-07T10:35:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('TRU-ARE-000039','2026-11-07T12:30:00','Incidencia',N'Rastreo',N'Caja con golpe leve, se re-embaló'),
('TRU-ARE-000039','2026-11-07T14:26:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('LIM-CUS-000042','2026-11-07T18:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000042','2026-11-07T23:24:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-TRU-000040','2026-11-08T01:41:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('TRU-LIM-000043','2026-11-08T08:50:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000044','2026-11-08T10:30:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-LIM-000043','2026-11-08T12:17:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('TRU-ARE-000045','2026-11-08T17:00:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000040','2026-11-08T17:57:00','EnReparto',N'Ruta JKL-654',N'Asignado a la ruta de reparto'),
('ARE-CUS-000046','2026-11-08T18:10:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-TRU-000044','2026-11-09T00:44:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('ARE-CUS-000046','2026-11-09T04:57:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('LIM-TRU-000044','2026-11-09T07:59:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-TRU-000047','2026-11-09T09:00:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-ARE-000045','2026-11-09T09:02:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('CUS-LIM-000048','2026-11-09T10:20:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('TRU-CUS-000049','2026-11-09T14:00:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000044','2026-11-09T14:39:00','EnReparto',N'Ruta XYZ-789',N'Asignado a la ruta de reparto'),
('TRU-CUS-000049','2026-11-09T16:44:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('ARE-LIM-000050','2026-11-09T17:40:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('ARE-CUS-000046','2026-11-10T00:54:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('CUS-LIM-000048','2026-11-10T02:23:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('LIM-TRU-000047','2026-11-10T05:00:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000051','2026-11-10T08:00:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('ARE-TRU-000052','2026-11-10T08:30:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('ARE-LIM-000050','2026-11-10T08:49:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('CUS-LIM-000053','2026-11-10T10:50:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('CUS-LIM-000053','2026-11-10T13:29:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('LIM-CUS-000054','2026-11-10T13:45:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-TRU-000055','2026-11-10T13:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('CUS-LIM-000048','2026-11-10T14:52:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('ARE-CUS-000046','2026-11-10T15:33:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('LIM-TRU-000056','2026-11-10T16:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000051','2026-11-10T18:07:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-LIM-000053','2026-11-10T21:49:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('LIM-TRU-000056','2026-11-10T22:50:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('ARE-TRU-000052','2026-11-10T23:03:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('TRU-ARE-000045','2026-11-11T00:08:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('ARE-LIM-000050','2026-11-11T01:27:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('TRU-ARE-000045','2026-11-11T02:57:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('LIM-CUS-000054','2026-11-11T04:49:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-TRU-000055','2026-11-11T05:53:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('ARE-LIM-000050','2026-11-11T08:33:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('CUS-LIM-000057','2026-11-11T08:50:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('LIM-TRU-000058','2026-11-11T09:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('CUS-LIM-000057','2026-11-11T09:51:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('LIM-TRU-000047','2026-11-11T10:05:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-CUS-000059','2026-11-11T13:20:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('CUS-LIM-000053','2026-11-11T15:17:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('TRU-ARE-000060','2026-11-11T16:20:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000058','2026-11-11T20:28:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000051','2026-11-11T21:56:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('LIM-CUS-000059','2026-11-12T05:00:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('ARE-TRU-000052','2026-11-12T05:29:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('LIM-CUS-000051','2026-11-12T05:33:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('TRU-ARE-000060','2026-11-12T09:06:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-TRU-000055','2026-11-12T09:34:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-TRU-000061','2026-11-12T10:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-TRU-000058','2026-11-12T12:44:00','Incidencia',N'Rastreo',N'Caja con golpe leve, se re-embaló'),
('LIM-CUS-000062','2026-11-12T14:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('ARE-LIM-000063','2026-11-12T14:50:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-CUS-000054','2026-11-12T14:51:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('TRU-ARE-000064','2026-11-12T16:10:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000061','2026-11-12T16:58:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000065','2026-11-12T17:30:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000059','2026-11-12T17:32:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('CUS-ARE-000066','2026-11-12T18:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('TRU-ARE-000064','2026-11-12T18:13:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-CUS-000065','2026-11-12T22:01:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-CUS-000062','2026-11-12T22:40:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('ARE-LIM-000063','2026-11-13T01:54:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('LIM-CUS-000059','2026-11-13T04:44:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('LIM-TRU-000058','2026-11-13T05:01:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('TRU-ARE-000060','2026-11-13T08:58:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('LIM-CUS-000054','2026-11-13T09:09:00','EnReparto',N'Ruta JKL-654',N'Asignado a la ruta de reparto'),
('LIM-CUS-000065','2026-11-13T10:36:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('CUS-ARE-000066','2026-11-13T10:55:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('ARE-TRU-000067','2026-11-13T12:15:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-CUS-000068','2026-11-13T12:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000069','2026-11-13T13:10:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000070','2026-11-13T13:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-CUS-000062','2026-11-13T15:38:00','EnTransito',N'Vehículo XYZ-789',N'Cargado en el vehículo'),
('LIM-CUS-000070','2026-11-13T17:12:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('ARE-LIM-000071','2026-11-13T17:30:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('CUS-LIM-000072','2026-11-13T18:10:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('LIM-CUS-000062','2026-11-13T23:04:00','EnReparto',N'Ruta XYZ-789',N'Asignado a la ruta de reparto'),
('ARE-TRU-000067','2026-11-14T02:25:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('LIM-CUS-000068','2026-11-14T03:10:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-ARE-000073','2026-11-14T08:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('LIM-CUS-000074','2026-11-14T09:15:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-ARE-000075','2026-11-14T09:40:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('CUS-ARE-000076','2026-11-14T10:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('CUS-LIM-000077','2026-11-14T10:30:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('CUS-TRU-000078','2026-11-14T10:45:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('ARE-TRU-000067','2026-11-14T11:02:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('CUS-ARE-000079','2026-11-14T12:15:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('ARE-LIM-000080','2026-11-14T12:45:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-TRU-000081','2026-11-14T12:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('ARE-TRU-000082','2026-11-14T13:50:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('CUS-ARE-000083','2026-11-14T15:00:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('CUS-TRU-000078','2026-11-14T15:32:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('TRU-ARE-000075','2026-11-14T17:18:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-CUS-000074','2026-11-14T19:41:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-ARE-000073','2026-11-14T21:31:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('CUS-ARE-000083','2026-11-14T21:49:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('ARE-TRU-000082','2026-11-14T22:31:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('ARE-TRU-000067','2026-11-15T01:18:00','EnReparto',N'Ruta DEF-456',N'Asignado a la ruta de reparto'),
('TRU-ARE-000075','2026-11-15T02:06:00','Incidencia',N'Rastreo',N'Destinatario no ubicado, se reprograma la entrega'),
('LIM-CUS-000070','2026-11-15T04:28:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('CUS-ARE-000076','2026-11-15T05:23:00','EnPreparacion',N'Almacén Sede Cusco',N'Ingresó al almacén'),
('LIM-CUS-000070','2026-11-15T06:48:00','EnReparto',N'Ruta JKL-654',N'Asignado a la ruta de reparto'),
('ARE-LIM-000084','2026-11-15T08:10:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-ARE-000085','2026-11-15T08:15:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-TRU-000081','2026-11-15T08:23:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-ARE-000083','2026-11-15T08:55:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('ARE-TRU-000082','2026-11-15T09:26:00','Incidencia',N'Rastreo',N'Caja con golpe leve, se re-embaló'),
('TRU-ARE-000075','2026-11-15T10:54:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('TRU-ARE-000086','2026-11-15T15:45:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('TRU-LIM-000087','2026-11-15T16:20:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-TRU-000081','2026-11-15T16:52:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('CUS-ARE-000083','2026-11-15T17:32:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('LIM-CUS-000068','2026-11-15T18:10:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('TRU-CUS-000088','2026-11-15T18:10:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('ARE-TRU-000082','2026-11-15T20:21:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('LIM-CUS-000074','2026-11-15T20:32:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('TRU-LIM-000087','2026-11-15T21:25:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('TRU-ARE-000075','2026-11-15T21:38:00','EnReparto',N'Ruta GHI-321',N'Asignado a la ruta de reparto'),
('CUS-ARE-000073','2026-11-15T23:12:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('CUS-TRU-000078','2026-11-16T01:39:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('TRU-CUS-000088','2026-11-16T03:44:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('LIM-ARE-000085','2026-11-16T04:06:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('CUS-ARE-000073','2026-11-16T04:21:00','EnReparto',N'Ruta MNO-987',N'Asignado a la ruta de reparto'),
('LIM-CUS-000074','2026-11-16T06:00:00','EnReparto',N'Ruta ABC-123',N'Asignado a la ruta de reparto'),
('CUS-ARE-000076','2026-11-16T06:34:00','EnTransito',N'Vehículo MNO-987',N'Cargado en el vehículo'),
('ARE-CUS-000089','2026-11-16T11:15:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-TRU-000090','2026-11-16T11:40:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('TRU-LIM-000087','2026-11-16T16:44:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('LIM-CUS-000091','2026-11-16T16:50:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-ARE-000092','2026-11-16T17:10:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-TRU-000093','2026-11-16T18:20:00','Registrado',N'Sede Lima',N'Envío registrado en recepción'),
('LIM-ARE-000085','2026-11-16T18:42:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('CUS-TRU-000094','2026-11-16T18:50:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('LIM-CUS-000091','2026-11-17T00:21:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('LIM-TRU-000093','2026-11-17T01:24:00','EnPreparacion',N'Almacén Sede Lima',N'Ingresó al almacén'),
('ARE-CUS-000089','2026-11-17T04:19:00','EnPreparacion',N'Almacén Sede Arequipa',N'Ingresó al almacén'),
('TRU-CUS-000088','2026-11-17T05:48:00','EnTransito',N'Vehículo GHI-321',N'Cargado en el vehículo'),
('CUS-TRU-000095','2026-11-17T09:20:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('TRU-ARE-000096','2026-11-17T10:30:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('LIM-CUS-000091','2026-11-17T12:45:00','EnTransito',N'Vehículo ABC-123',N'Cargado en el vehículo'),
('ARE-CUS-000089','2026-11-17T22:42:00','EnTransito',N'Vehículo DEF-456',N'Cargado en el vehículo'),
('TRU-ARE-000096','2026-11-17T23:46:00','EnPreparacion',N'Almacén Sede Trujillo',N'Ingresó al almacén'),
('ARE-TRU-000097','2026-11-18T13:15:00','Registrado',N'Sede Arequipa',N'Envío registrado en recepción'),
('LIM-TRU-000093','2026-11-18T15:25:00','EnTransito',N'Vehículo JKL-654',N'Cargado en el vehículo'),
('TRU-LIM-000098','2026-11-18T16:45:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('CUS-TRU-000099','2026-11-18T17:40:00','Registrado',N'Sede Cusco',N'Envío registrado en recepción'),
('TRU-LIM-000100','2026-11-19T08:10:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('TRU-CUS-000101','2026-11-19T14:20:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción'),
('TRU-LIM-000102','2026-11-19T14:20:00','Registrado',N'Sede Trujillo',N'Envío registrado en recepción');

--====================
-- PARADAS DE RUTA (solo envíos En reparto, en orden de asignación)
--====================

INSERT INTO ParadaRuta (PlacaVehiculo, CodigoEnvio, Orden)
VALUES
('ABC-123','LIM-CUS-000051',1),
('ABC-123','LIM-CUS-000059',2),
('ABC-123','LIM-CUS-000074',3),
('XYZ-789','LIM-CUS-000041',1),
('XYZ-789','LIM-TRU-000044',2),
('XYZ-789','LIM-CUS-000062',3),
('JKL-654','LIM-TRU-000040',1),
('JKL-654','LIM-CUS-000054',2),
('JKL-654','LIM-CUS-000070',3),
('DEF-456','ARE-CUS-000046',1),
('DEF-456','ARE-LIM-000050',2),
('DEF-456','ARE-TRU-000067',3),
('GHI-321','TRU-ARE-000039',1),
('GHI-321','TRU-ARE-000045',2),
('GHI-321','TRU-ARE-000075',3),
('MNO-987','CUS-LIM-000053',1),
('MNO-987','CUS-ARE-000083',2),
('MNO-987','CUS-ARE-000073',3);
GO

--====================
-- PRUEBAS Y CONSULTAS
--====================

SELECT u.NombreUsuario, u.Nombres, s.Nombre AS Sede, u.Activo, u.UltimoAcceso
FROM Usuario AS u
LEFT JOIN Sede AS s ON s.Id = u.SedeId
ORDER BY u.Id;

SELECT
    Codigo, Tipo, PesoKg, Precio,
    ModalidadPago, Estado
FROM Envio
ORDER BY Id;

SELECT Codigo, Nombre, Ciudad
FROM Sede
ORDER BY Id;

SELECT Placa, Conductor, CapacidadKg
FROM Vehiculo
ORDER BY Placa;

SELECT
    origen.Nombre AS Origen,
    destino.Nombre AS Destino,
    t.PrecioBase,
    t.PrecioPorKg
FROM Tarifa AS t
INNER JOIN Sede AS origen
    ON origen.Id = t.SedeOrigenId
INNER JOIN Sede AS destino
    ON destino.Id = t.SedeDestinoId
ORDER BY origen.Nombre, destino.Nombre;

-- Cantidad de envíos por estado (para revisar los datos de prueba)
SELECT Estado, COUNT(*) AS Cantidad
FROM Envio
GROUP BY Estado
ORDER BY Estado;

-- Envíos por mes de registro (para los reportes)
SELECT FORMAT(FechaRegistro, 'yyyy-MM') AS Mes, COUNT(*) AS Envios
FROM Envio
GROUP BY FORMAT(FechaRegistro, 'yyyy-MM')
ORDER BY Mes;

--============================
-- BUSQUEDA DE PERSONAS POR DNI
--============================

SELECT
    Id,
    TipoDocumento,
    NumeroDocumento AS DNI,
    Nombres,
    Telefono
FROM Persona
WHERE NumeroDocumento = '70000001';
GO