create database CRUD_Employee

use CRUD_Employee


create table Rol(
IdRol int primary key identity(1,1),
Detail nvarchar(50)
);

create table Employee(
IdEmployee int primary key identity(1,1),
UserName varchar(100),
Mail varchar(50),
Cellphone varchar(50),
Rolid int

constraint FK_Rol foreign key(Rolid) references Rol(IdRol)
);


insert into Rol(Detail)
values
('Software Engineer'),
('Data Analyst'),
('Security Analist');

insert into Employee(UserName,Mail,Cellphone,Rolid)
values
('Cristopher Marinez','CRZ@outlook.com','8098711478',1),
('Pedro Jimenez','BigP@gmail.com','8499632587',2),
('Randy Cave','CavePR@hotmail.com','8299637896',3);

select
e.UserName as [NAME],
e.Mail as [PERSONAL MAIL],
e.Cellphone as[CELLPHONE],
r.Detail as[EMPLOYEE ROL]

from Employee e
inner join Rol r
on e.Rolid = r.IdRol




