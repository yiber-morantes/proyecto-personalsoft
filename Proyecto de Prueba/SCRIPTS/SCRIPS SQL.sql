CREATE DATABASE MilesCar 
use MilesCar 
go 
 create table Carros(
 IdCarro int PRIMARY KEY IDENTITY(1,1) NOT NULL,
 PlacaCarro  varchar(25) NOT NULL,
 ModeloCarro varchar(25) NOT NULL,
 CiudadRecogidaId   Int NOT NULL,
 CiudadDevoluciónId  Int NOT NULL,
 Activo bit,
 CONSTRAINT fk_CiudadRecogida FOREIGN key(CiudadRecogidaId)references Ciudad(idCiudad),
 CONSTRAINT fk_CiudadDevolucion FOREIGN key(CiudadDevoluciónId)references Ciudad(idCiudad)
 )
 Go
 
 Create Table Ciudad(
 idCiudad int PRIMARY KEY IDENTITY(1,1) NOT NULL,
 nombreCiudad varchar (25) NOT NULL 
 )
go

INSERT INTO Ciudad (nombreCiudad) VALUES ('Barranquilla')
INSERT INTO Ciudad (nombreCiudad) VALUES ('Medellin')
INSERT INTO Ciudad (nombreCiudad) VALUES ('Cali')
INSERT INTO Ciudad (nombreCiudad) VALUES ('Cartagena')
INSERT INTO Ciudad (nombreCiudad) VALUES ('Bogota')

CREATE OR ALTER PROC ListarCiudades(
 @nombreCiudad varchar(25)
) 
as 
Begin
select * from Ciudad
where nombreCiudad like '%'+@nombreCiudad+'%'
end
go

CREATE OR ALTER PROC Listarcarros(
@placaCarro  varchar(25),
@modeloCarro varchar(25),
@activo bit,
@ciudadRecogidaId Int,
@ciudadDevoluciónId  Int
)
as 
Begin
select * from carros
where PlacaCarro  like '%'+@placaCarro +'%' Or modeloCarro like '%'+@modeloCarro +'%' And activo = 1 
And CiudadRecogidaId  like '%'+@ciudadRecogidaId +'%'And ciudadDevoluciónId  like '%'+@ciudadDevoluciónId +'%'
end
go
