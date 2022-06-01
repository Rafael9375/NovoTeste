create table tblMotorista(
	Id int primary key identity(1,1),
	Nome varchar(500),
	Cpf varchar(50),
	DataNascimento datetime,
	Sexo varchar(100),
	Ativo bit
)

insert into TblMotorista values('Rafael Pereira de Paula', '999.999.999-99', '09-05-1993', 'Masculino', 1)