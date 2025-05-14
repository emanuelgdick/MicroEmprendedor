
delete from Anexo
dbcc checkident(Anexo,reseed,0)
SET IDENTITY_INSERT Anexo ON
insert into Anexo(Id, Descripcion)
select ID_ANEXO, Descripcion from [Biblioteca].dbo.anexos
SET IDENTITY_INSERT Anexo OFF
--select * from Anexo

delete from Autor
dbcc checkident(Autor,reseed,0)
SET IDENTITY_INSERT Autor ON
insert into Autor(Id, ApeyNom)
select ID_AUTOR,DESCRIPCION from [Biblioteca].dbo.autores
SET IDENTITY_INSERT Autor OFF
--select * from autor

delete from calle
dbcc checkident(calle,reseed,0)
SET IDENTITY_INSERT Calle ON
insert into Calle(Id, Descripcion)
select ID_CALLE,DESCRIPCION from [Biblioteca].dbo.Calles
SET IDENTITY_INSERT Calle OFF
--select * from calle

delete from CategoriaSocio
dbcc checkident(categoriaSocio,reseed,0)
SET IDENTITY_INSERT CategoriaSocio ON
insert into CategoriaSocio(Id,Descripcion,cantMaterial)
select ID_CATEGORIA,DESCRIPCION,CANT_MATERIAL from [Biblioteca].dbo.CATEGORIAS_DE_SOCIOS
SET IDENTITY_INSERT CategoriaSocio OFF
--select * from CategoriaSocio

delete from Cobrador
dbcc checkident(Cobrador,reseed,0)
SET IDENTITY_INSERT Cobrador ON
insert into Cobrador(Id,ApeyNom)
select ID_COBRADOR,APEYNOM from [Biblioteca].dbo.COBRADORES
SET IDENTITY_INSERT Cobrador OFF
--select * from Cobrador

delete from Coleccion
dbcc checkident(Coleccion,reseed,0)
SET IDENTITY_INSERT Coleccion ON
insert into Coleccion(Id, Descripcion)
select ID_COLECCION,DESCRIPCION from [Biblioteca].dbo.COLECCIONES
SET IDENTITY_INSERT Coleccion OFF
--select * from Coleccion

delete from Director
dbcc checkident(Director,reseed,0)
SET IDENTITY_INSERT Director ON
insert into Director(Id, ApeyNom)
select id_DIRECTOR,descripcion from [Biblioteca].dbo.DIRECTORES
SET IDENTITY_INSERT Director OFF
--select * from Director

delete from Editor
dbcc checkident(Editor,reseed,0)
SET IDENTITY_INSERT Editor ON
insert into Editor(Id,ApeyNom)
select id_Editora, descripcion from [Biblioteca].dbo.Editoras
SET IDENTITY_INSERT Editor OFF
--select * from Editor


delete from Editorial
dbcc checkident(Editorial,reseed,0)
SET IDENTITY_INSERT Editorial ON
insert into Editorial(Id, Descripcion)
select ID_EDITORIAL,DESCRIPCION from [Biblioteca].dbo.EDITORIALES
SET IDENTITY_INSERT Editorial OFF
--select * from Editorial


delete from Encuadernacion
dbcc checkident(Encuadernacion,reseed,0)
SET IDENTITY_INSERT Encuadernacion ON
insert into Encuadernacion(Id,Descripcion)
select ID_ENCUADERNACION,DESCRIPCION from [Biblioteca].dbo.ENCUADERNACIONES
SET IDENTITY_INSERT Encuadernacion OFF
--select * from Encuadernacion

delete from EstadoSocio
dbcc checkident(EstadoSocio,reseed,0)
SET IDENTITY_INSERT EstadoSocio ON
insert into EstadoSocio(Id,Descripcion)
select ID_ESTADO_SOCIO,DESCRIPCION from [Biblioteca].dbo.ESTADO_DE_SOCIOS
SET IDENTITY_INSERT EstadoSocio OFF
--select * from EstadoSocio

delete from Genero
dbcc checkident(Genero,reseed,0)
SET IDENTITY_INSERT Genero ON
insert into Genero(Id,Descripcion)
select id_GENERO,descripcion from [Biblioteca].dbo.GENEROS
SET IDENTITY_INSERT Genero OFF
--select * from Genero

delete from Guionista
dbcc checkident(Guionista,reseed,0)
SET IDENTITY_INSERT Guionista ON
insert into Guionista(Id,ApeyNom)
select id_guionista,descripcion from [Biblioteca].dbo.Guionistas
SET IDENTITY_INSERT Guionista OFF
--select * from Guionista

delete from Idioma
dbcc checkident(Idioma,reseed,0)
SET IDENTITY_INSERT Idioma ON
insert into Idioma(Id,Descripcion)
select ID_IDIOMA,DESCRIPCION from [Biblioteca].dbo.IDIOMAS
SET IDENTITY_INSERT Idioma OFF
--select * from Idioma

delete from Interprete
dbcc checkident(Interprete,reseed,0)
SET IDENTITY_INSERT Interprete ON
insert into Interprete(Id,ApeyNom)
select ID_INTERPRETE,descripcion from [Biblioteca].dbo.INTERPRETES
SET IDENTITY_INSERT Interprete OFF
--select * from Interprete

delete from Pais
dbcc checkident(Pais,reseed,0)
SET IDENTITY_INSERT Pais ON
insert into Pais(Id,Descripcion)
select ID_PAIS,DESCRIPCION from [Biblioteca].dbo.PAISES
SET IDENTITY_INSERT Pais OFF
--select * from Pais

delete from Provincia
dbcc checkident(Provincia,reseed,0)
SET IDENTITY_INSERT Provincia ON
insert into Provincia(Id,IdPais,Descripcion)
select ID_PROVINCIA,ID_PAIS,DESCRIPCION from [Biblioteca].dbo.PROVINCIAS
SET IDENTITY_INSERT Provincia OFF
--select * from Provincia

delete from Localidad
dbcc checkident(Localidad,reseed,0)
SET IDENTITY_INSERT Localidad ON
insert into Localidad(Id,IdProvincia,Descripcion)
select ID_LOCALIDAD,ID_PROVINCIA,DESCA from [Biblioteca].dbo.LOCALIDADES
SET IDENTITY_INSERT Localidad OFF
--select * from Localidad

delete from Lugar
dbcc checkident(Lugar,reseed,0)
SET IDENTITY_INSERT Lugar ON
insert into Lugar(Id,Descripcion)
select ID_LUGAR,DESCRIPCION from [Biblioteca].dbo.LUGARES
SET IDENTITY_INSERT Lugar OFF
--select * from Lugar

delete from Materia
dbcc checkident(Materia,reseed,0)
SET IDENTITY_INSERT Materia ON
insert into Materia(Id,Descripcion)
select ID_MATERIA,DESCRIPCION from [Biblioteca].dbo.MATERIAS
SET IDENTITY_INSERT Materia OFF
--select * from Materia

delete from Procedencia
dbcc checkident(Procedencia,reseed,0)
SET IDENTITY_INSERT Procedencia ON
insert into Procedencia(Id,Descripcion)
select ID_PROCEDENCIA,DESCRIPCION from [Biblioteca].dbo.PROCEDENCIAS
SET IDENTITY_INSERT Procedencia OFF
--select * from Procedencia

delete from Productor
dbcc checkident(Productor,reseed,0)
SET IDENTITY_INSERT Productor ON
insert into Productor(Id,ApeyNom)
select id_PRODUCTOR,descripcion from [Biblioteca].dbo.PRODUCTORES
SET IDENTITY_INSERT Productor OFF
--select * from Productor

delete from Profesion
dbcc checkident(Profesion,reseed,0)
SET IDENTITY_INSERT Profesion ON
insert into Profesion(Id,Descripcion)
select ID_PROFESION,DESCRIPCION from [Biblioteca].dbo.PROFESIONES
SET IDENTITY_INSERT Profesion OFF
--select * from Profesion

delete from TipoDocumento
dbcc checkident(TipoDocumento,reseed,0)
SET IDENTITY_INSERT TipoDocumento ON
insert into TipoDocumento(Id,DescA,DescC)
select ID_TIPO_DOCUMENTO,DESCA,DESCC from [Biblioteca].dbo.TIPOS_DE_DOCUMENTOS
SET IDENTITY_INSERT TipoDocumento OFF
--select * from TipoDocumento

delete from TipoSocio
dbcc checkident(TipoSocio,reseed,0)
SET IDENTITY_INSERT TipoSocio ON
insert into TipoSocio(Id,Descripcion)
select ID_TIPO_SOCIO,DESCA from [Biblioteca].dbo.TIPOS_DE_SOCIOS
SET IDENTITY_INSERT TipoSocio OFF
--select * from TipoSocio

delete from TipoSuspension
dbcc checkident(TipoSuspension,reseed,0)
SET IDENTITY_INSERT TipoSuspension ON
insert into TipoSuspension(Id,Descripcion)
select ID_TIPO_SUSPENCION,DESCRIPCION from [Biblioteca].dbo.TIPOS_DE_SUSPENCION
SET IDENTITY_INSERT TipoSuspension OFF
--select * from TipoSuspension

delete from TipoSoporte
dbcc checkident(TipoSoporte,reseed,0)
SET IDENTITY_INSERT TipoSoporte ON
insert into TipoSoporte(Id,Descripcion)
select ID_TIPO_SOPORTE,DESCRIPCION from [Biblioteca].dbo.TIPOS_DE_SOPORTE
SET IDENTITY_INSERT TipoSoporte OFF
--select * from TipoSoporte

delete from TipoMaterial
dbcc checkident(TipoMaterial,reseed,0)
SET IDENTITY_INSERT TipoMaterial ON
insert into TipoMaterial(Id,Descripcion)
select ID_TIPO_MATERIAL,DESCRIPCION from [Biblioteca].dbo.TIPOS_DE_MATERIAL
SET IDENTITY_INSERT TipoMaterial OFF
--select * from TipoMaterial

delete from Socio
dbcc checkident(Socio,reseed,0)
insert into Socio(NroSocio,ApeyNom,Nro,Depto,Telefono,Fnac,FIngreso,FEgreso,Observaciones,Documento,Vitalicio,PagaAca,IdTipoSocio,IdEstadoSocio,IdCategoriaSocio,IdTipoDocumento,IdCalle,IdProfesion,IdLocalidad)
select Socio,ApeyNom,Nro,Depto,Telefono,Fnac,FIngreso,FEgreso,Observaciones,Documento,Vitalicio,PagaAca,Id_Tipo_Socio,Id_Estado_Socio,Id_Categoria,Id_Tipo_Documento,Id_Calle,Id_Profesion,Id_Localidad from [Biblioteca].dbo.SOCIOS
--select * from Socio

delete from Prologuista
dbcc checkident(Prologuista,reseed,0)
SET IDENTITY_INSERT Prologuista ON
insert into Prologuista(Id,ApeyNom)
select ID_TRADPROL,DESCRIPCION from [Biblioteca].dbo.TRADPROL WHERE DESCRIPCION LIKE('PROL%')
SET IDENTITY_INSERT Prologuista OFF
--select * from Prologuista

delete from Traductor
dbcc checkident(Traductor,reseed,0)
SET IDENTITY_INSERT Traductor ON
insert into Traductor(Id,ApeyNom)
select ID_TRADPROL,DESCRIPCION from [Biblioteca].dbo.TRADPROL WHERE DESCRIPCION LIKE('TRAD%')
SET IDENTITY_INSERT Traductor OFF
--select * from Traductor

delete from Sector
dbcc checkident(Sector,reseed,0)
SET IDENTITY_INSERT Sector ON
insert into Sector(Id,Descripcion)
select ID_SECTOR,DESCRIPCION from [Biblioteca].dbo.Sectores
SET IDENTITY_INSERT Sector OFF
--select * from Sector


--delete from Ilustrador
--dbcc checkident(Ilustrador,reseed,0)
--SET IDENTITY_INSERT Ilustrador ON
--insert into Ilustrador(Id,ApeyNom)
--select ID_PROLOGUISTA,ApeyNom from [Biblioteca].dbo.Ilustradores
--SET IDENTITY_INSERT Ilustrador OFF
--select * from Ilustrador





delete from Usuario
dbcc checkident(Usuario,reseed,0)
insert into Usuario(ApeyNom,[User],[Password],Rol)
values('Emanuel Gutierrez Dick','emanuelgdick@gmail.com','manolo','Admin')
--select * from Usuario



