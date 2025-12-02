CREATE DATABASE NeishanyLopez
GO

USE NeishanyLopez;
GO


CREATE TABLE NL_Casos (
    CasoId INT IDENTITY(1,1) PRIMARY KEY,
    Cliente NVARCHAR(100),
    Abogado NVARCHAR(100),
    Titulo NVARCHAR(200),
    Descripcion NVARCHAR(MAX),
    FechaInicio DATE,
    FechaVencimiento DATE,
    Estado NVARCHAR(50)
);

USE NeishanyLopez;
SELECT * FROM NL_Casos;