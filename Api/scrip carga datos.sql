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

delete from MicroEmprendedor
dbcc checkident(MicroEmprendedor,reseed,0)
delete from MicroEmprendedorRubro
dbcc checkident(MicroEmprendedorRubro,reseed,0)
select * from MicroEmprendedor
select * from MicroEmprendedorRubro
select * from Localidad

/*
{
  "Id": 0,
  "IdTipoDocumento": 1,
  "TipoDocumento": {
    "Id": 1,
    "DescA": "D.N.I",
    "DescC": "Documento Nacional de Identidad"
  },
  "IdLocalidad": 1,
  "Localidad": {
    "Id": 1,
    "Descripcion": "Ayacucho"
  },
  "ApeyNom": "Gutierrez Dick, Emanuel",
  "Dni": "26888310",
  "FechaNacimiento": "1978-09-29T11:56:05.139Z",
  "Sexo": "M",
  "Calle": "Belgrano",
  "Nro": "875",
  "Piso": "1",
  "Depto": "2",
  "TelFijo": "45111 4",
  "TelCelular": "2494013268",
  "Correo": "emanuelgdick@gmail.com",
  "SitioWeb": "www.manolo.com",
  "Instagram": "ig",
  "Facebook": "Facebook",
  "Observaciones": "obs de Manolo",
  "Rubros": [
    {
      "Id": 0,
      "IdMicroEmprendedor": 0,
      "IdRubro": 1
    },
    {
      "Id": 0,
      "IdMicroEmprendedor": 0,
      "IdRubro": 2
    }
  ]
}
*/