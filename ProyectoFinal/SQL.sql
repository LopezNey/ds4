CREATE DATABASE TurismoTransporte;
GO
USE TurismoTransporte;
GO

CREATE TABLE Vehiculos (
  Id INT IDENTITY PRIMARY KEY,
  Nombre NVARCHAR(60) NOT NULL,
  Tipo NVARCHAR(30) NOT NULL,
  Capacidad INT NOT NULL,
  Maletas INT NOT NULL,
  PrecioBase DECIMAL(10,2) NOT NULL,
  FotoUrl NVARCHAR(300) NULL,
  Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Destinos (
  Id INT IDENTITY PRIMARY KEY,
  Nombre NVARCHAR(80) NOT NULL,
  Zona NVARCHAR(60) NOT NULL,
  Descripcion NVARCHAR(300) NULL,
  ImagenUrl NVARCHAR(300) NULL,
  Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Tarifas (
  Id INT IDENTITY PRIMARY KEY,
  DestinoId INT NOT NULL FOREIGN KEY REFERENCES Destinos(Id),
  TipoVehiculo NVARCHAR(30) NOT NULL,
  Precio DECIMAL(10,2) NOT NULL
);

CREATE TABLE Slots (
  Id INT IDENTITY PRIMARY KEY,
  Fecha DATE NOT NULL,
  Hora TIME NOT NULL,
  Estado NVARCHAR(15) NOT NULL DEFAULT 'LIBRE' -- LIBRE/RESERVADO
);

CREATE TABLE Reservas (
  Id INT IDENTITY PRIMARY KEY,
  NombreCliente NVARCHAR(80) NOT NULL,
  Telefono NVARCHAR(20) NOT NULL,
  Email NVARCHAR(80) NULL,
  VehiculoId INT NOT NULL FOREIGN KEY REFERENCES Vehiculos(Id),
  DestinoId INT NOT NULL FOREIGN KEY REFERENCES Destinos(Id),
  Fecha DATE NOT NULL,
  Hora TIME NOT NULL,
  Pasajeros INT NOT NULL,
  PrecioEstimado DECIMAL(10,2) NOT NULL,
  Estado NVARCHAR(20) NOT NULL DEFAULT 'PENDIENTE',
  CreadoEn DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE OR ALTER PROCEDURE sp_Cotizar
  @DestinoId INT,
  @TipoVehiculo NVARCHAR(30)
AS
BEGIN
  SELECT TOP 1 Precio
  FROM Tarifas
  WHERE DestinoId = @DestinoId AND TipoVehiculo = @TipoVehiculo;
END
GO

CREATE OR ALTER PROCEDURE sp_SlotsLibresPorFecha
  @Fecha DATE
AS
BEGIN
  SELECT Id, Fecha, Hora
  FROM Slots
  WHERE Fecha = @Fecha AND Estado = 'LIBRE'
  ORDER BY Hora;
END
GO

CREATE OR ALTER PROCEDURE sp_CrearReserva
  @NombreCliente NVARCHAR(80),
  @Telefono NVARCHAR(20),
  @Email NVARCHAR(80),
  @VehiculoId INT,
  @DestinoId INT,
  @Fecha DATE,
  @Hora TIME,
  @Pasajeros INT,
  @PrecioEstimado DECIMAL(10,2)
AS
BEGIN
  IF EXISTS (SELECT 1 FROM Slots WHERE Fecha=@Fecha AND Hora=@Hora AND Estado='LIBRE')
  BEGIN
    UPDATE Slots SET Estado='RESERVADO'
    WHERE Fecha=@Fecha AND Hora=@Hora;

    INSERT INTO Reservas(NombreCliente,Telefono,Email,VehiculoId,DestinoId,Fecha,Hora,Pasajeros,PrecioEstimado)
    VALUES(@NombreCliente,@Telefono,@Email,@VehiculoId,@DestinoId,@Fecha,@Hora,@Pasajeros,@PrecioEstimado);

    SELECT SCOPE_IDENTITY() AS ReservaId;
  END
  ELSE
  BEGIN
    RAISERROR('El slot ya está reservado.', 16, 1);
  END
END
GO

USE TurismoTransporte;
GO
INSERT INTO Vehiculos (Nombre, Tipo, Capacidad, Maletas, PrecioBase, FotoUrl, Activo)
VALUES
('Toyota Corolla', 'Sedan', 3, 2, 10.00, '/Content/img/sedan.jpg', 1),
('Hyundai Elantra', 'Sedan', 3, 2, 10.00, '/Content/img/sedan2.jpg', 1),
('Toyota Fortuner', 'SUV', 5, 4, 15.00, '/Content/img/suv.jpg', 1),
('Kia Sorento', 'SUV', 5, 4, 15.00, '/Content/img/suv2.jpg', 1),
('Toyota Hiace', 'Van', 10, 10, 20.00, '/Content/img/van.jpg', 1),
('Coaster (MiniBus)', 'Van', 15, 15, 25.00, '/Content/img/van2.jpg', 1);
GO

USE TurismoTransporte;
GO
INSERT INTO Destinos (Nombre, Zona, Descripcion, ImagenUrl, Activo)
VALUES
('Aeropuerto Tocumen', 'Ciudad', 'Traslados desde/hacia el aeropuerto internacional.', '/Content/img/tocumen.jpg', 1),
('Casco Viejo', 'Ciudad', 'Centro histórico, restaurantes, vida nocturna.', '/Content/img/casco.jpg', 1),
('Canal de Panamá (Miraflores)', 'Ciudad', 'Visita al centro de visitantes de Miraflores.', '/Content/img/canal.jpg', 1),
('Calzada de Amador', 'Ciudad', 'Paseo frente al mar con vistas a la ciudad.', '/Content/img/amador.jpg', 1),
('Gamboa', 'Ciudad', 'Naturaleza, teleférico y actividades ecológicas.', '/Content/img/gamboa.jpg', 1),
('Playa Blanca', 'Pacífico', 'Destino de playa, ideal para día completo.', '/Content/img/playablanca.jpg', 1),
('El Valle de Antón', 'Interior', 'Clima fresco, naturaleza y turismo local.', '/Content/img/valle.jpg', 1),
('San Blas', 'Caribe', 'Excursión a islas paradisíacas (día completo).', '/Content/img/sanblas.jpg', 1),
('Boquete', 'Chiriquí', 'Zona de montaña y café (viaje largo).', '/Content/img/boquete.jpg', 1);
GO

USE TurismoTransporte;
GO
INSERT INTO Tarifas (DestinoId, TipoVehiculo, Precio)
SELECT d.Id, v.TipoVehiculo,
CASE
  WHEN d.Nombre = 'Aeropuerto Tocumen' AND v.TipoVehiculo = 'Sedan' THEN 25
  WHEN d.Nombre = 'Aeropuerto Tocumen' AND v.TipoVehiculo = 'SUV'   THEN 35
  WHEN d.Nombre = 'Aeropuerto Tocumen' AND v.TipoVehiculo = 'Van'   THEN 45

  WHEN d.Nombre = 'Casco Viejo' AND v.TipoVehiculo = 'Sedan' THEN 15
  WHEN d.Nombre = 'Casco Viejo' AND v.TipoVehiculo = 'SUV'   THEN 25
  WHEN d.Nombre = 'Casco Viejo' AND v.TipoVehiculo = 'Van'   THEN 35

  WHEN d.Nombre = 'Canal de Panamá (Miraflores)' AND v.TipoVehiculo = 'Sedan' THEN 18
  WHEN d.Nombre = 'Canal de Panamá (Miraflores)' AND v.TipoVehiculo = 'SUV'   THEN 28
  WHEN d.Nombre = 'Canal de Panamá (Miraflores)' AND v.TipoVehiculo = 'Van'   THEN 38

  WHEN d.Nombre = 'Calzada de Amador' AND v.TipoVehiculo = 'Sedan' THEN 18
  WHEN d.Nombre = 'Calzada de Amador' AND v.TipoVehiculo = 'SUV'   THEN 28
  WHEN d.Nombre = 'Calzada de Amador' AND v.TipoVehiculo = 'Van'   THEN 38

  WHEN d.Nombre = 'Gamboa' AND v.TipoVehiculo = 'Sedan' THEN 35
  WHEN d.Nombre = 'Gamboa' AND v.TipoVehiculo = 'SUV'   THEN 50
  WHEN d.Nombre = 'Gamboa' AND v.TipoVehiculo = 'Van'   THEN 65

  WHEN d.Nombre = 'Playa Blanca' AND v.TipoVehiculo = 'Sedan' THEN 70
  WHEN d.Nombre = 'Playa Blanca' AND v.TipoVehiculo = 'SUV'   THEN 90
  WHEN d.Nombre = 'Playa Blanca' AND v.TipoVehiculo = 'Van'   THEN 120

  WHEN d.Nombre = 'El Valle de Antón' AND v.TipoVehiculo = 'Sedan' THEN 60
  WHEN d.Nombre = 'El Valle de Antón' AND v.TipoVehiculo = 'SUV'   THEN 80
  WHEN d.Nombre = 'El Valle de Antón' AND v.TipoVehiculo = 'Van'   THEN 110

  WHEN d.Nombre = 'San Blas' AND v.TipoVehiculo = 'Sedan' THEN 140
  WHEN d.Nombre = 'San Blas' AND v.TipoVehiculo = 'SUV'   THEN 170
  WHEN d.Nombre = 'San Blas' AND v.TipoVehiculo = 'Van'   THEN 220

  WHEN d.Nombre = 'Boquete' AND v.TipoVehiculo = 'Sedan' THEN 300
  WHEN d.Nombre = 'Boquete' AND v.TipoVehiculo = 'SUV'   THEN 360
  WHEN d.Nombre = 'Boquete' AND v.TipoVehiculo = 'Van'   THEN 450

  ELSE 40
END
FROM Destinos d
CROSS JOIN (SELECT 'Sedan' AS TipoVehiculo UNION ALL SELECT 'SUV' UNION ALL SELECT 'Van') v;
GO

-- Limpia slots existentes (opcional)
-- DELETE FROM Slots;
USE TurismoTransporte;
GO
SELECT COUNT(*) FROM Slots

DECLARE @StartDate DATE = CAST(GETDATE() AS DATE);
DECLARE @Days INT = 30;

;WITH N AS (
    SELECT TOP (48) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
    FROM sys.all_objects
),
Times AS (
    -- 8:00 a 17:30 cada 30 min -> 20 slots por día
    SELECT CAST(DATEADD(MINUTE, n*30, CAST('08:00' AS TIME)) AS TIME) AS Hora
    FROM N
    WHERE DATEADD(MINUTE, n*30, CAST('08:00' AS TIME)) <= CAST('17:30' AS TIME)
),
Dates AS (
    SELECT DATEADD(DAY, v.number, @StartDate) AS Fecha
    FROM master..spt_values v
    WHERE v.type='P' AND v.number BETWEEN 0 AND (@Days - 1)
)
INSERT INTO Slots (Fecha, Hora, Estado)
SELECT d.Fecha, t.Hora, 'LIBRE'
FROM Dates d
CROSS JOIN Times t;
GO
