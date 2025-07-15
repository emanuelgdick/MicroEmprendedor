delete from localidad
dbcc checkident(localidad,reseed,0)
insert into Localidad
values('Ayacucho')
insert into Localidad
values('Mar del Plata')
--select * from localidad
-----------------------------------------------
delete from TipoDocumento
dbcc checkident(TipoDocumento,reseed,0)
insert into TipoDocumento
values('D.N.I','Documento Nacional de Identidad')
insert into TipoDocumento
values('L.E','Libretra de Enrolamiento')
insert into TipoDocumento
values('L.C','Libretra Civica')
--select * from TipoDocumento
-----------------------------------------------
delete from Rubro
dbcc checkident(Rubro,reseed,0)
insert into Rubro
values('Albañilería')
insert into Rubro
values('Plomería')
insert into Rubro
values('Electricista')
--select * from rubro