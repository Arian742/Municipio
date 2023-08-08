-- Creacion de Base de datos
create database dbMUNi
go
use dbMUNi
go

---	Consultas 

--  sp_listar_trabajador 
CREATE PROC sp_listar_trabajador
AS
BEGIN
    SELECT * FROM A ORDER BY [Apellido/s]; -- Aquí corregimos el campo de ordenamiento
END
GO

-- Buscar trabajador
CREATE PROC sp_buscar_trabajador
@DNI nvarchar(255)
AS 
BEGIN
    SELECT Id, [Apellido/s], Nombres, DNI, Nacionalidad, Domicilio, [Estado civil], [Numero de calle], Depto, Piso, Localidad, Provincia, [Telefono particular], Celular 
    FROM A 
    WHERE DNI LIKE @DNI + '%'
END
GO

--Insercion de datos, eliminacion y modificar
CREATE PROC sp_mantenimiento_trabajador
@Id int,
@Apellido_s nvarchar(255),
@Nombres nvarchar(255),
@DNI nvarchar(max),
@Nacionalidad nvarchar(255),
@EstadoCivil nvarchar(255),
@Domicilio nvarchar(max),
@NumeroDeCalle int,
@Depto nvarchar(255),
@Piso nvarchar(255),
@Localidad nvarchar(255),
@Provincia nvarchar(255),
@TelefonoParticular nvarchar(max),
@Celular nvarchar(max),
@accion varchar(50) OUTPUT
AS
BEGIN
    IF @accion = '1'
    BEGIN
        -- Insertar nuevo registro
        INSERT INTO A(Id, [Apellido/s], Nombres, DNI, Nacionalidad, [Estado civil], Domicilio, [Numero de calle], Depto, Piso, Localidad, Provincia, [Telefono particular], Celular)
       VALUES (@Id, @Apellido_s, @Nombres, @DNI, @Nacionalidad, @EstadoCivil, @Domicilio, @NumeroDeCalle, @Depto, @Piso, @Localidad, @Provincia, @TelefonoParticular, @Celular)
        SET @accion = 'Se generó el Legajo: ' + @Nombres
    END
    ELSE IF @accion = '2'
    BEGIN
        -- Actualizar registro existente
        UPDATE A
        SET Nombres = @Nombres, [Apellido/s] = @Apellido_s, DNI = @DNI, Nacionalidad = @Nacionalidad, [Estado civil] = @EstadoCivil, Domicilio = @Domicilio, [Numero de calle] = @NumeroDeCalle, Depto = @Depto, Piso = @Piso, Localidad = @Localidad, Provincia = @Provincia, [Telefono particular] = @TelefonoParticular, Celular = @Celular
        WHERE DNI = @DNI
        SET @accion = 'Se modificó el Legajo: ' + CONVERT(varchar(10), @DNI)
    END
    ELSE IF @accion = '3'
    BEGIN
        -- Eliminar registro
        DELETE FROM A
        WHERE DNI = @DNI
        SET @accion = 'Se borró el Legajo: ' + CONVERT(varchar(10), @DNI)
    END

    
END
GO


--Tabla User

   create table Users(
UserID int identity(1,1) primary key,
LoginName nvarchar (100) unique not null,
Password nvarchar (100) not null,
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
Position nvarchar (100) not null,
Email nvarchar(150)not null
) 
-- Datos insertados en U
insert into Users values ('admin','admin','Jackson','Collins','Administrator','Support@SystemAll.biz')
insert into Users values ('Ben','abc123456','Benjamin','Thompson','Receptionist','BenThompson@MyCompany.com')                                                         
insert into Users values ('Kathy','abc123456','Kathrine','Smith','Accounting','KathySmith@MyCompany.com')
                                                        
select *from Users where LoginName ='admin' and Password = 'admin5'

declare @user nvarchar(100)='admin'
declare @pass nvarchar(100)='admin'
select *from Users where LoginName=@user and Password=@pass




