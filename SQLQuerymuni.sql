create database dbMUNi
go
use dbMUNi
go

create proc sp_listar_trabajador
as
select * from A order by Id
go

create proc sp_buscar_trabajador
@DNI nvarchar(255)
as 
select Id ,[Apellido/s], Nombres, DNI, Nacionalidad,Domicilio, [Estado civil], [Numero de calle], Depto, Piso, Localidad, Provincia, [Telefono particular], Celular from A where DNI like @DNI + '%'
go

create proc sp_mantenimiento_trabajador
@Id int,
@Apellido_s nvarchar(255), -- Cambiar el nombre de la columna con espacios a un nombre válido en SQL Server
@Nombres nvarchar(255),
@DNI nvarchar(max),
@Nacionalidad nvarchar(255),
@EstadoCivil nvarchar(255), -- Cambiar el nombre de la columna con espacios a un nombre válido en SQL Server
@Domicilio nvarchar(max),
@NumeroDeCalle int,
@Depto nvarchar(255),
@Piso nvarchar(255),
@Localidad nvarchar(255),
@Provincia nvarchar(255),
@TelefonoParticular nvarchar(max), -- Cambiar el nombre de la columna con espacios a un nombre válido en SQL Server
@Celular nvarchar(max),
@accion varchar(50) output
as
if(@accion='1')
begin
   declare @Idnuevo varchar(5), @Idmax varchar(5)
   set @Idmax = (select max(Id) from A)
   set @Idmax = isnull(@idmax , 'A0001')
   set @Idmax = 'A'+RIGHT(RIGHT(@Idmax,4)+10001,4)
   insert into A(Id, [Apellido/s], Nombres, DNI,Nacionalidad,[Estado civil], Domicilio, [Numero de calle],Depto, Piso, Localidad, Provincia, [Telefono particular],Celular)
   values (@Idnuevo, @Nombres, @Apellido_s, @DNI, @Nacionalidad,@EstadoCivil,@Domicilio,@NumeroDeCalle,@Depto,@Piso,@Localidad,@Provincia,@TelefonoParticular,@Celular)
   set @accion= 'Se genero el Id: ' +@Idnuevo
   end
   
   else if (@accion='2')
   begin
   update A set Nombres=@Nombres, [Apellido/s]=@Apellido_s, DNI=@DNI, Nacionalidad=@Nacionalidad, [Estado civil]=@EstadoCivil, Domicilio=@Domicilio, [Numero de calle]=@NumeroDeCalle, Depto=@Depto, Piso=@Piso, Localidad=@Localidad, Provincia=@Provincia, [Telefono particular]=@TelefonoParticular, Celular=@Celular where Id=@Id
   set @accion='Se modifico el ID: ' +@Id
   end

   else if(@accion='3')
   begin
   delete from A where Id=@Id
   set @accion='Se borro el Id: ' + @Id
   end
   go

