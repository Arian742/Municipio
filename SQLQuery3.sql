create database MyCompany
go
use MyCompany
go

create table Users(
UserID int identity(1,1) primary key,
LoginName nvarchar (100) unique not null,
Password nvarchar (100) not null,
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
Position nvarchar (100) not null,
Email nvarchar(150)not null
) 

insert into Users values ('admin','admin','Jackson','Collins','Administrator','Support@SystemAll.biz')
insert into Users values ('Ben','abc123456','Benjamin','Thompson','Receptionist','BenThompson@MyCompany.com')                                                         
insert into Users values ('Kathy','abc123456','Kathrine','Smith','Accounting','KathySmith@MyCompany.com')
                                                        
select *from Users where LoginName ='admin' and Password = 'admin5'

declare @user nvarchar(100)='admin'
declare @pass nvarchar(100)='admin'
select *from Users where LoginName=@user and Password=@pass