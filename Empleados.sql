create database Empleados
go

use Empleados
go

create table tbl_Empleados(
	idEmp int identity primary key,
	nombres varchar(70),
	apellidos varchar(70),
	correo varchar(60),
	fechaNac date,
	sueldo decimal(8,2)
)
go


select * from tbl_Empleados

