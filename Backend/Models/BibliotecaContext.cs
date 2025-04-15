using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anexo> Anexos { get; set; }

    public virtual DbSet<AnexosXMateriale> AnexosXMateriales { get; set; }

    public virtual DbSet<AnexosXRevista> AnexosXRevistas { get; set; }

    public virtual DbSet<ArticulosDeRevista> ArticulosDeRevistas { get; set; }

    public virtual DbSet<ArticulosXMateria> ArticulosXMaterias { get; set; }

    public virtual DbSet<Autor123> Autor123s { get; set; }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<AutoresXMateriale> AutoresXMateriales { get; set; }

    public virtual DbSet<AutoresXRevista> AutoresXRevistas { get; set; }

    public virtual DbSet<Calle> Calles { get; set; }

    public virtual DbSet<CallesSociosActivo> CallesSociosActivos { get; set; }

    public virtual DbSet<CallesXCobradore> CallesXCobradores { get; set; }

    public virtual DbSet<CategoriasDeSocio> CategoriasDeSocios { get; set; }

    public virtual DbSet<Cobradore> Cobradores { get; set; }

    public virtual DbSet<Coleccione> Colecciones { get; set; }

    public virtual DbSet<Cuota> Cuotas { get; set; }

    public virtual DbSet<Directore> Directores { get; set; }

    public virtual DbSet<DirectoresXVideo> DirectoresXVideos { get; set; }

    public virtual DbSet<Editora> Editoras { get; set; }

    public virtual DbSet<Editoriale> Editoriales { get; set; }

    public virtual DbSet<Encuadernacione> Encuadernaciones { get; set; }

    public virtual DbSet<EstadoDeSocio> EstadoDeSocios { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Guionista> Guionistas { get; set; }

    public virtual DbSet<GuionistasXVideo> GuionistasXVideos { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<Interprete> Interpretes { get; set; }

    public virtual DbSet<InterpretesXVideo> InterpretesXVideos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Localidade> Localidades { get; set; }

    public virtual DbSet<Lugare> Lugares { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Materiale> Materiales { get; set; }

    public virtual DbSet<MateriasXMateriale> MateriasXMateriales { get; set; }

    public virtual DbSet<MateriasXRevista> MateriasXRevistas { get; set; }

    public virtual DbSet<MateriasXVideo> MateriasXVideos { get; set; }

    public virtual DbSet<MovimientosDeMaterial> MovimientosDeMaterials { get; set; }

    public virtual DbSet<Novedade> Novedades { get; set; }

    public virtual DbSet<NumerosDeRevista> NumerosDeRevistas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Procedencia> Procedencias { get; set; }

    public virtual DbSet<Productore> Productores { get; set; }

    public virtual DbSet<ProductoresXVideo> ProductoresXVideos { get; set; }

    public virtual DbSet<Profesione> Profesiones { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Revista> Revistas { get; set; }

    public virtual DbSet<Sectore> Sectores { get; set; }

    public virtual DbSet<Series> Series { get; set; }

    public virtual DbSet<Socio> Socios { get; set; }

    public virtual DbSet<Sociosconsaldoafavor> Sociosconsaldoafavors { get; set; }

    public virtual DbSet<Temporal> Temporals { get; set; }

    public virtual DbSet<Temporal2> Temporal2s { get; set; }

    public virtual DbSet<TemporalMateriale> TemporalMateriales { get; set; }

    public virtual DbSet<TiposDeDocumento> TiposDeDocumentos { get; set; }

    public virtual DbSet<TiposDeMaterial> TiposDeMaterials { get; set; }

    public virtual DbSet<TiposDeMovimiento> TiposDeMovimientos { get; set; }

    public virtual DbSet<TiposDeSocio> TiposDeSocios { get; set; }

    public virtual DbSet<TiposDeSoporte> TiposDeSoportes { get; set; }

    public virtual DbSet<TiposDeSuspencion> TiposDeSuspencions { get; set; }

    public virtual DbSet<TiposDeSuspencionXSocio> TiposDeSuspencionXSocios { get; set; }

    public virtual DbSet<Tradprol> Tradprols { get; set; }

    public virtual DbSet<TransferenciasDeMaterial> TransferenciasDeMaterials { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anexo>(entity =>
        {
            entity.HasKey(e => e.IdAnexo).IsClustered(false);

            entity.ToTable("ANEXOS", tb =>
                {
                    tb.HasTrigger("TD_ANEXOS");
                    tb.HasTrigger("TU_ANEXOS");
                });

            entity.Property(e => e.IdAnexo).HasColumnName("ID_ANEXO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<AnexosXMateriale>(entity =>
        {
            entity.HasKey(e => new { e.IdAnexo, e.NroInventario });

            entity.ToTable("ANEXOS_X_MATERIALES", tb =>
                {
                    tb.HasTrigger("TI_ANEXOS_X_LIBROS");
                    tb.HasTrigger("TU_ANEXOS_X_LIBROS");
                });

            entity.HasIndex(e => e.IdAnexo, "RELATIONSHIP_42_FK");

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_43_FK");

            entity.Property(e => e.IdAnexo).HasColumnName("ID_ANEXO");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

            entity.HasOne(d => d.NroInventarioNavigation).WithMany(p => p.AnexosXMateriales)
                .HasForeignKey(d => d.NroInventario)
                .HasConstraintName("FK_ANEXOS_X_RELATIONS_MATERIAL");
        });

        modelBuilder.Entity<AnexosXRevista>(entity =>
        {
            entity.HasKey(e => new { e.IdAnexo, e.IdRevista });

            entity.ToTable("ANEXOS_X_REVISTAS");

            entity.Property(e => e.IdAnexo).HasColumnName("ID_ANEXO");
            entity.Property(e => e.IdRevista).HasColumnName("ID_REVISTA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.AnexosXRevista)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK_ANEXOS_X_RELATIONS_REVISTAS");
        });

        modelBuilder.Entity<ArticulosDeRevista>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).IsClustered(false);

            entity.ToTable("ARTICULOS_DE_REVISTAS", tb =>
                {
                    tb.HasTrigger("TD_ARTICULOS_DE_REVISTAS");
                    tb.HasTrigger("TI_ARTICULOS_DE_REVISTAS");
                    tb.HasTrigger("TU_ARTICULOS_DE_REVISTAS");
                });

            entity.HasIndex(e => e.IdNumero, "RELATIONSHIP_39_FK");

            entity.Property(e => e.IdArticulo).HasColumnName("ID_ARTICULO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdNumero).HasColumnName("ID_NUMERO");
            entity.Property(e => e.NroPagina).HasColumnName("NRO_PAGINA");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
        });

        modelBuilder.Entity<ArticulosXMateria>(entity =>
        {
            entity.HasKey(e => new { e.IdMateria, e.IdArticulo });

            entity.ToTable("ARTICULOS_X_MATERIAS", tb =>
                {
                    tb.HasTrigger("TI_ARTICULOS_X_MATERIAS");
                    tb.HasTrigger("TU_ARTICULOS_X_MATERIAS");
                });

            entity.HasIndex(e => e.IdMateria, "RELATIONSHIP_52_FK");

            entity.HasIndex(e => e.IdArticulo, "RELATIONSHIP_53_FK");

            entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");
            entity.Property(e => e.IdArticulo).HasColumnName("ID_ARTICULO");
        });

        modelBuilder.Entity<Autor123>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("autor123");

            entity.Property(e => e.Autor1)
                .HasMaxLength(255)
                .HasColumnName("autor1");
            entity.Property(e => e.Autor2)
                .HasMaxLength(255)
                .HasColumnName("autor2");
            entity.Property(e => e.Autor3)
                .HasMaxLength(255)
                .HasColumnName("autor3");
            entity.Property(e => e.IdAutor1).HasColumnName("id_autor1");
            entity.Property(e => e.IdAutor2).HasColumnName("id_autor2");
            entity.Property(e => e.IdAutor3).HasColumnName("id_autor3");
            entity.Property(e => e.NroInventario).HasColumnName("nro_inventario");
        });

        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.IdAutor);

            entity.ToTable("AUTORES");

            entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<AutoresXMateriale>(entity =>
        {
            entity.HasKey(e => new { e.NroInventario, e.IdAutor });

            entity.ToTable("AUTORES_X_MATERIALES", tb =>
                {
                    tb.HasTrigger("TI_AUTORES_X_LIBROS");
                    tb.HasTrigger("TU_AUTORES_X_LIBROS");
                });

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_35_FK");

            entity.HasIndex(e => e.IdAutor, "RELATIONSHIP_36_FK");

            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");
            entity.Property(e => e.Ppal).HasColumnName("PPAL");
        });

        modelBuilder.Entity<AutoresXRevista>(entity =>
        {
            entity.HasKey(e => new { e.IdRevista, e.IdAutor });

            entity.ToTable("AUTORES_X_REVISTAS");

            entity.Property(e => e.IdRevista).HasColumnName("ID_REVISTA");
            entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");
            entity.Property(e => e.Ppal).HasColumnName("PPAL");
        });

        modelBuilder.Entity<Calle>(entity =>
        {
            entity.HasKey(e => e.IdCalle).IsClustered(false);

            entity.ToTable("CALLES", tb =>
                {
                    tb.HasTrigger("TD_CALLES");
                    tb.HasTrigger("TU_CALLES");
                });

            entity.Property(e => e.IdCalle).HasColumnName("ID_CALLE");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<CallesSociosActivo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("calles_socios_activos");

            entity.Property(e => e.Cant).HasColumnName("cant");
            entity.Property(e => e.IdCalle).HasColumnName("id_calle");
        });

        modelBuilder.Entity<CallesXCobradore>(entity =>
        {
            entity.HasKey(e => new { e.IdCobrador, e.IdCalle });

            entity.ToTable("CALLES_X_COBRADORES", tb =>
                {
                    tb.HasTrigger("TI_CALLES_X_COBRADOR");
                    tb.HasTrigger("TU_CALLES_X_COBRADOR");
                });

            entity.HasIndex(e => e.IdCobrador, "RELATIONSHIP_23_FK");

            entity.HasIndex(e => e.IdCalle, "RELATIONSHIP_24_FK");

            entity.Property(e => e.IdCobrador).HasColumnName("ID_COBRADOR");
            entity.Property(e => e.IdCalle).HasColumnName("ID_CALLE");
        });

        modelBuilder.Entity<CategoriasDeSocio>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).IsClustered(false);

            entity.ToTable("CATEGORIAS_DE_SOCIOS", tb =>
                {
                    tb.HasTrigger("TD_CATEGORIAS_DE_SOCIOS");
                    tb.HasTrigger("TU_CATEGORIAS_DE_SOCIOS");
                });

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.CantMaterial).HasColumnName("CANT_MATERIAL");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Cobradore>(entity =>
        {
            entity.HasKey(e => e.IdCobrador).IsClustered(false);

            entity.ToTable("COBRADORES", tb =>
                {
                    tb.HasTrigger("TD_COBRADORES");
                    tb.HasTrigger("TU_COBRADORES");
                });

            entity.Property(e => e.IdCobrador).HasColumnName("ID_COBRADOR");
            entity.Property(e => e.Apeynom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("APEYNOM");
        });

        modelBuilder.Entity<Coleccione>(entity =>
        {
            entity.HasKey(e => e.IdColeccion).IsClustered(false);

            entity.ToTable("COLECCIONES", tb =>
                {
                    tb.HasTrigger("TD_COLECCIONES");
                    tb.HasTrigger("TU_COLECCIONES");
                });

            entity.Property(e => e.IdColeccion).HasColumnName("ID_COLECCION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Cuota>(entity =>
        {
            entity.HasKey(e => e.IdCuota).IsClustered(false);

            entity.ToTable("CUOTAS", tb =>
                {
                    tb.HasTrigger("TI_CUOTAS");
                    tb.HasTrigger("TU_CUOTAS");
                });

            entity.HasIndex(e => e.Socio, "RELATIONSHIP_20_FK");

            entity.Property(e => e.IdCuota).HasColumnName("ID_CUOTA");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Importe)
                .HasColumnType("money")
                .HasColumnName("IMPORTE");
            entity.Property(e => e.Mes).HasColumnName("MES");
            entity.Property(e => e.Paga).HasColumnName("PAGA");
            entity.Property(e => e.Socio).HasColumnName("SOCIO");
        });

        modelBuilder.Entity<Directore>(entity =>
        {
            entity.HasKey(e => e.IdDirector);

            entity.ToTable("DIRECTORES");

            entity.Property(e => e.IdDirector).HasColumnName("id_DIRECTOR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<DirectoresXVideo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DIRECTORES_X_VIDEOS");

            entity.Property(e => e.IdDirector).HasColumnName("ID_DIRECTOR");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
        });

        modelBuilder.Entity<Editora>(entity =>
        {
            entity.HasKey(e => e.IdEditora);

            entity.ToTable("EDITORAS");

            entity.Property(e => e.IdEditora).HasColumnName("id_EDITORA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Editoriale>(entity =>
        {
            entity.HasKey(e => e.IdEditorial).IsClustered(false);

            entity.ToTable("EDITORIALES", tb =>
                {
                    tb.HasTrigger("TD_EDITORIALES");
                    tb.HasTrigger("TU_EDITORIALES");
                });

            entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Encuadernacione>(entity =>
        {
            entity.HasKey(e => e.IdEncuadernacion).IsClustered(false);

            entity.ToTable("ENCUADERNACIONES", tb =>
                {
                    tb.HasTrigger("TD_ENCUADERNACIONES");
                    tb.HasTrigger("TU_ENCUADERNACIONES");
                });

            entity.Property(e => e.IdEncuadernacion).HasColumnName("ID_ENCUADERNACION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<EstadoDeSocio>(entity =>
        {
            entity.HasKey(e => e.IdEstadoSocio).IsClustered(false);

            entity.ToTable("ESTADO_DE_SOCIOS");

            entity.Property(e => e.IdEstadoSocio).HasColumnName("ID_ESTADO_SOCIO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.ToTable("GENEROS");

            entity.Property(e => e.IdGenero).HasColumnName("id_GENERO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Guionista>(entity =>
        {
            entity.HasKey(e => e.IdGuionista);

            entity.Property(e => e.IdGuionista).HasColumnName("id_guionista");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<GuionistasXVideo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GUIONISTAS_X_VIDEOS");

            entity.Property(e => e.IdGuionista).HasColumnName("ID_GUIONISTA");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.IdIdioma).IsClustered(false);

            entity.ToTable("IDIOMAS", tb =>
                {
                    tb.HasTrigger("TD_IDIOMAS");
                    tb.HasTrigger("TU_IDIOMAS");
                });

            entity.Property(e => e.IdIdioma).HasColumnName("ID_IDIOMA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Interprete>(entity =>
        {
            entity.HasKey(e => e.IdInterprete);

            entity.ToTable("INTERPRETES");

            entity.Property(e => e.IdInterprete).HasColumnName("ID_INTERPRETE");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<InterpretesXVideo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("INTERPRETES_X_VIDEOS");

            entity.Property(e => e.IdInterprete).HasColumnName("ID_INTERPRETE");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("libro");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(255)
                .HasColumnName("clasificacion");
            entity.Property(e => e.Libris)
                .HasMaxLength(255)
                .HasColumnName("libris");
            entity.Property(e => e.Nro).HasColumnName("nro");
        });

        modelBuilder.Entity<Localidade>(entity =>
        {
            entity.HasKey(e => e.IdLocalidad).IsClustered(false);

            entity.ToTable("LOCALIDADES", tb =>
                {
                    tb.HasTrigger("TD_LOCALIDADES");
                    tb.HasTrigger("TI_LOCALIDADES");
                    tb.HasTrigger("TU_LOCALIDADES");
                });

            entity.HasIndex(e => e.IdProvincia, "RELATIONSHIP_11_FK");

            entity.Property(e => e.IdLocalidad).HasColumnName("ID_LOCALIDAD");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO_POSTAL");
            entity.Property(e => e.Desca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCA");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
        });

        modelBuilder.Entity<Lugare>(entity =>
        {
            entity.HasKey(e => e.IdLugar).HasName("PK_Lugares");

            entity.ToTable("LUGARES");

            entity.Property(e => e.IdLugar).HasColumnName("ID_LUGAR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.IdMateria).IsClustered(false);

            entity.ToTable("MATERIAS");

            entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Materiale>(entity =>
        {
            entity.HasKey(e => e.NroInventario).IsClustered(false);

            entity.ToTable("MATERIALES", tb =>
                {
                    tb.HasTrigger("TD_LIBROS");
                    tb.HasTrigger("TI_LIBROS");
                    tb.HasTrigger("TU_LIBROS");
                });

            entity.HasIndex(e => e.IdProcedencia, "RELATIONSHIP_28_FK");

            entity.HasIndex(e => e.IdIdioma, "RELATIONSHIP_30_FK");

            entity.HasIndex(e => e.IdEncuadernacion, "RELATIONSHIP_33_FK");

            entity.HasIndex(e => e.IdEditorial, "RELATIONSHIP_37_FK");

            entity.HasIndex(e => e.IdColeccion, "RELATIONSHIP_48_FK");

            entity.HasIndex(e => e.IdSerie, "RELATIONSHIP_49_FK");

            entity.HasIndex(e => e.IdTipoMaterial, "RELATIONSHIP_52_FK");

            entity.HasIndex(e => e.IdSector, "RELATIONSHIP_59_FK");

            entity.Property(e => e.NroInventario)
                .ValueGeneratedNever()
                .HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.AnoEdicion)
                .HasMaxLength(255)
                .HasColumnName("ANO_EDICION");
            entity.Property(e => e.CantPaginas)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CANT_PAGINAS");
            entity.Property(e => e.Clase)
                .HasMaxLength(255)
                .HasColumnName("CLASE");
            entity.Property(e => e.EanIsbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EAN_ISBN");
            entity.Property(e => e.Extension)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EXTENSION");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPRA");
            entity.Property(e => e.IdColeccion).HasColumnName("ID_COLECCION");
            entity.Property(e => e.IdEditor).HasColumnName("ID_EDITOR");
            entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");
            entity.Property(e => e.IdEncuadernacion).HasColumnName("ID_ENCUADERNACION");
            entity.Property(e => e.IdIdioma).HasColumnName("ID_IDIOMA");
            entity.Property(e => e.IdIlustrador).HasColumnName("ID_ILUSTRADOR");
            entity.Property(e => e.IdLugar).HasColumnName("ID_LUGAR");
            entity.Property(e => e.IdProcedencia).HasColumnName("ID_PROCEDENCIA");
            entity.Property(e => e.IdProloguista).HasColumnName("ID_PROLOGUISTA");
            entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");
            entity.Property(e => e.IdSerie).HasColumnName("ID_SERIE");
            entity.Property(e => e.IdTipoMaterial).HasColumnName("ID_TIPO_MATERIAL");
            entity.Property(e => e.IdTraductor).HasColumnName("ID_TRADUCTOR");
            entity.Property(e => e.Libristica)
                .HasMaxLength(255)
                .HasColumnName("LIBRISTICA");
            entity.Property(e => e.NroColeccion).HasColumnName("NRO_COLECCION");
            entity.Property(e => e.NroEdicion)
                .HasMaxLength(255)
                .HasColumnName("NRO_EDICION");
            entity.Property(e => e.NroEjemplar)
                .HasMaxLength(255)
                .HasColumnName("NRO_EJEMPLAR");
            entity.Property(e => e.NroTomo).HasColumnName("NRO_TOMO");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("PRECIO");
            entity.Property(e => e.TieneIlustracion).HasColumnName("TIENE_ILUSTRACION");
            entity.Property(e => e.Titulo)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("TITULO");
            entity.Property(e => e.Volumen).HasColumnName("VOLUMEN");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.Materiales)
                .HasForeignKey(d => d.IdSector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATERIAL_RELATIONS_SECTORES");

            entity.HasOne(d => d.IdTipoMaterialNavigation).WithMany(p => p.Materiales)
                .HasForeignKey(d => d.IdTipoMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATERIAL_RELATIONS_TIPOS_DE");
        });

        modelBuilder.Entity<MateriasXMateriale>(entity =>
        {
            entity.HasKey(e => new { e.NroInventario, e.IdMateria });

            entity.ToTable("MATERIAS_X_MATERIALES", tb =>
                {
                    tb.HasTrigger("TI_MATERIAS_X_LIBROS");
                    tb.HasTrigger("TU_MATERIAS_X_LIBROS");
                });

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_71_FK");

            entity.HasIndex(e => e.IdMateria, "RELATIONSHIP_72_FK");

            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");

            entity.HasOne(d => d.NroInventarioNavigation).WithMany(p => p.MateriasXMateriales)
                .HasForeignKey(d => d.NroInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATERIAS_RELATIONS_MATERIAL");
        });

        modelBuilder.Entity<MateriasXRevista>(entity =>
        {
            entity.HasKey(e => new { e.IdRevista, e.IdMateria });

            entity.ToTable("MATERIAS_X_REVISTAS");

            entity.Property(e => e.IdRevista).HasColumnName("ID_REVISTA");
            entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");
        });

        modelBuilder.Entity<MateriasXVideo>(entity =>
        {
            entity.HasKey(e => new { e.IdMateria, e.NroInventario });

            entity.ToTable("MATERIAS_X_VIDEOS");

            entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
        });

        modelBuilder.Entity<MovimientosDeMaterial>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).IsClustered(false);

            entity.ToTable("MOVIMIENTOS_DE_MATERIAL", tb =>
                {
                    tb.HasTrigger("TI_PRESTAMOS");
                    tb.HasTrigger("TU_PRESTAMOS");
                });

            entity.HasIndex(e => e.IdTipoMovimiento, "RELATIONSHIP_53_FK");

            entity.HasIndex(e => e.Socio, "RELATIONSHIP_68_FK");

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_69_FK");

            entity.Property(e => e.IdMovimiento).HasColumnName("ID_MOVIMIENTO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_DEVOLUCION");
            entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");
            entity.Property(e => e.IdTipoMaterial).HasColumnName("ID_TIPO_MATERIAL");
            entity.Property(e => e.IdTipoMovimiento).HasColumnName("ID_TIPO_MOVIMIENTO");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.NroMov).HasColumnName("NRO_MOV");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Socio).HasColumnName("SOCIO");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.MovimientosDeMaterials)
                .HasForeignKey(d => d.IdSector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MOVIMIEN_RELATIONS_SECTORES");

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.MovimientosDeMaterials)
                .HasForeignKey(d => d.IdTipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MOVIMIEN_RELATIONS_TIP");
        });

        modelBuilder.Entity<Novedade>(entity =>
        {
            entity.HasKey(e => e.IdNovedad).IsClustered(false);

            entity.ToTable("NOVEDADES");

            entity.HasIndex(e => e.Socio, "RELATIONSHIP_68_FK");

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_69_FK");

            entity.HasIndex(e => e.IdReserva, "RELATIONSHIP_70_FK");

            entity.HasIndex(e => e.IdPrestamo, "RELATIONSHIP_71_FK");

            entity.Property(e => e.IdNovedad).HasColumnName("ID_NOVEDAD");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdPrestamo).HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.IdReserva).HasColumnName("ID_RESERVA");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.Socio).HasColumnName("SOCIO");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Novedades)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK_NOVEDADE_RELATIONS_RESERVAS");

            entity.HasOne(d => d.NroInventarioNavigation).WithMany(p => p.Novedades)
                .HasForeignKey(d => d.NroInventario)
                .HasConstraintName("FK_NOVEDADE_RELATIONS_MATERIAL");

            entity.HasOne(d => d.SocioNavigation).WithMany(p => p.Novedades)
                .HasForeignKey(d => d.Socio)
                .HasConstraintName("FK_NOVEDADE_RELATIONS_SOCIOS");
        });

        modelBuilder.Entity<NumerosDeRevista>(entity =>
        {
            entity.HasKey(e => e.IdNumero).IsClustered(false);

            entity.ToTable("NUMEROS_DE_REVISTAS", tb =>
                {
                    tb.HasTrigger("TD_NUMEROS_DE_REVISTAS");
                    tb.HasTrigger("TI_NUMEROS_DE_REVISTAS");
                    tb.HasTrigger("TU_NUMEROS_DE_REVISTAS");
                });

            entity.HasIndex(e => e.IdRevista, "RELATIONSHIP_38_FK");

            entity.Property(e => e.IdNumero).HasColumnName("ID_NUMERO");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.IdRevista).HasColumnName("ID_REVISTA");
            entity.Property(e => e.Mes).HasColumnName("MES");
            entity.Property(e => e.Nro).HasColumnName("NRO");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).IsClustered(false);

            entity.ToTable("PAGOS", tb =>
                {
                    tb.HasTrigger("TI_PAGOS");
                    tb.HasTrigger("TU_PAGOS");
                });

            entity.HasIndex(e => e.Socio, "RELATIONSHIP_8_FK");

            entity.Property(e => e.IdPago).HasColumnName("ID_PAGO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.ImporteTotal)
                .HasColumnType("money")
                .HasColumnName("IMPORTE_TOTAL");
            entity.Property(e => e.Socio).HasColumnName("SOCIO");

            entity.HasMany(d => d.IdCuota).WithMany(p => p.IdPagos)
                .UsingEntity<Dictionary<string, object>>(
                    "CuotasXPago",
                    r => r.HasOne<Cuota>().WithMany()
                        .HasForeignKey("IdCuota")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CUOTAS_X_RELATIONS_CUOTAS"),
                    l => l.HasOne<Pago>().WithMany()
                        .HasForeignKey("IdPago")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CUOTAS_X_RELATIONS_PAGOS"),
                    j =>
                    {
                        j.HasKey("IdPago", "IdCuota");
                        j.ToTable("CUOTAS_X_PAGOS");
                        j.HasIndex(new[] { "IdPago" }, "RELATIONSHIP_72_FK");
                        j.HasIndex(new[] { "IdCuota" }, "RELATIONSHIP_73_FK");
                        j.IndexerProperty<long>("IdPago").HasColumnName("ID_PAGO");
                        j.IndexerProperty<long>("IdCuota").HasColumnName("ID_CUOTA");
                    });
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.IdPais).IsClustered(false);

            entity.ToTable("PAISES", tb =>
                {
                    tb.HasTrigger("TD_PAISES");
                    tb.HasTrigger("TU_PAISES");
                });

            entity.Property(e => e.IdPais).HasColumnName("ID_PAIS");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).IsClustered(false);

            entity.ToTable("PRESTAMOS");

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_56_FK");

            entity.HasIndex(e => e.Socio, "RELATIONSHIP_57_FK");

            entity.HasIndex(e => e.IdTipoMovimiento, "RELATIONSHIP_67_FK");

            entity.Property(e => e.IdPrestamo).HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_DEVOLUCION");
            entity.Property(e => e.IdMovimiento).HasColumnName("ID_MOVIMIENTO");
            entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");
            entity.Property(e => e.IdTipoMaterial).HasColumnName("ID_TIPO_MATERIAL");
            entity.Property(e => e.IdTipoMovimiento).HasColumnName("ID_TIPO_MOVIMIENTO");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.Socio).HasColumnName("SOCIO");

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdTipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRESTAMO_RELATIONS_TIPOS_DE");

            entity.HasOne(d => d.SocioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Socio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRESTAMO_RELATIONS_SOCIOS");
        });

        modelBuilder.Entity<Procedencia>(entity =>
        {
            entity.HasKey(e => e.IdProcedencia).IsClustered(false);

            entity.ToTable("PROCEDENCIAS", tb =>
                {
                    tb.HasTrigger("TD_PROCEDENCIAS");
                    tb.HasTrigger("TU_PROCEDENCIAS");
                });

            entity.Property(e => e.IdProcedencia).HasColumnName("ID_PROCEDENCIA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Productore>(entity =>
        {
            entity.HasKey(e => e.IdProductor);

            entity.ToTable("PRODUCTORES");

            entity.Property(e => e.IdProductor).HasColumnName("id_PRODUCTOR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<ProductoresXVideo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PRODUCTORES_X_VIDEOS");

            entity.Property(e => e.IdProductor).HasColumnName("ID_PRODUCTOR");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
        });

        modelBuilder.Entity<Profesione>(entity =>
        {
            entity.HasKey(e => e.IdProfesion);

            entity.ToTable("PROFESIONES");

            entity.Property(e => e.IdProfesion).HasColumnName("ID_PROFESION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).IsClustered(false);

            entity.ToTable("PROVINCIAS", tb =>
                {
                    tb.HasTrigger("TD_PROVINCIAS");
                    tb.HasTrigger("TI_PROVINCIAS");
                    tb.HasTrigger("TU_PROVINCIAS");
                });

            entity.HasIndex(e => e.IdPais, "RELATIONSHIP_10_FK");

            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdPais).HasColumnName("ID_PAIS");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).IsClustered(false);

            entity.ToTable("RESERVAS", tb =>
                {
                    tb.HasTrigger("TI_RESERVAS");
                    tb.HasTrigger("TU_RESERVAS");
                });

            entity.HasIndex(e => e.Socio, "RELATIONSHIP_14_FK");

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_66_FK");

            entity.Property(e => e.IdReserva).HasColumnName("ID_RESERVA");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.Socio).HasColumnName("SOCIO");

            entity.HasOne(d => d.SocioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Socio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVAS_RELATIONS_SOCIOS");
        });

        modelBuilder.Entity<Revista>(entity =>
        {
            entity.HasKey(e => e.IdRevista).IsClustered(false);

            entity.ToTable("REVISTAS");

            entity.Property(e => e.IdRevista).HasColumnName("ID_REVISTA");
            entity.Property(e => e.Ano)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ANO");
            entity.Property(e => e.CantPaginas)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CANT_PAGINAS");
            entity.Property(e => e.Clase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLASE");
            entity.Property(e => e.Ejemplar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EJEMPLAR");
            entity.Property(e => e.Extencion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EXTENCION");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdColeccion).HasColumnName("ID_COLECCION");
            entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");
            entity.Property(e => e.IdIdioma).HasColumnName("ID_IDIOMA");
            entity.Property(e => e.IdLugar).HasColumnName("ID_LUGAR");
            entity.Property(e => e.IdProcedencia).HasColumnName("ID_PROCEDENCIA");
            entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");
            entity.Property(e => e.IdSerie).HasColumnName("ID_SERIE");
            entity.Property(e => e.Issn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ISSN");
            entity.Property(e => e.Libristica)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LIBRISTICA");
            entity.Property(e => e.Nro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NRO");
            entity.Property(e => e.NroColeccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRO_COLECCION");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRECIO");
            entity.Property(e => e.Subtitulo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SUBTITULO");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TITULO");
            entity.Property(e => e.Volumen)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VOLUMEN");
        });

        modelBuilder.Entity<Sectore>(entity =>
        {
            entity.HasKey(e => e.IdSector).IsClustered(false);

            entity.ToTable("SECTORES");

            entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");
            entity.Property(e => e.AdmitePrestamos).HasColumnName("ADMITE_PRESTAMOS");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.HasKey(e => e.IdSerie).IsClustered(false);

            entity.ToTable("SERIES", tb =>
                {
                    tb.HasTrigger("TD_SERIES");
                    tb.HasTrigger("TU_SERIES");
                });

            entity.Property(e => e.IdSerie).HasColumnName("ID_SERIE");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.Socio1).IsClustered(false);

            entity.ToTable("SOCIOS", tb =>
                {
                    tb.HasTrigger("TD_SOCIOS");
                    tb.HasTrigger("TI_SOCIOS");
                    tb.HasTrigger("TU_SOCIOS");
                });

            entity.HasIndex(e => e.IdLocalidad, "RELATIONSHIP_13_FK");

            entity.HasIndex(e => e.IdTipoDocumento, "RELATIONSHIP_1_FK");

            entity.HasIndex(e => e.IdCalle, "RELATIONSHIP_22_FK");

            entity.HasIndex(e => e.IdTipoSocio, "RELATIONSHIP_25_FK");

            entity.HasIndex(e => e.IdCategoria, "RELATIONSHIP_26_FK");

            entity.HasIndex(e => e.IdProfesion, "RELATIONSHIP_2_FK");

            entity.Property(e => e.Socio1)
                .ValueGeneratedNever()
                .HasColumnName("SOCIO");
            entity.Property(e => e.Apeynom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("APEYNOM");
            entity.Property(e => e.Depto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DEPTO");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.Fegreso)
                .HasColumnType("datetime")
                .HasColumnName("FEGRESO");
            entity.Property(e => e.Fingreso)
                .HasColumnType("datetime")
                .HasColumnName("FINGRESO");
            entity.Property(e => e.Fnac)
                .HasColumnType("datetime")
                .HasColumnName("FNAC");
            entity.Property(e => e.IdCalle).HasColumnName("ID_CALLE");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.IdEstadoSocio).HasColumnName("ID_ESTADO_SOCIO");
            entity.Property(e => e.IdLocalidad).HasColumnName("ID_LOCALIDAD");
            entity.Property(e => e.IdProfesion).HasColumnName("ID_PROFESION");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");
            entity.Property(e => e.IdTipoSocio).HasColumnName("ID_TIPO_SOCIO");
            entity.Property(e => e.Nro).HasColumnName("NRO");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Pagaaca).HasColumnName("PAGAACA");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Vitalicio).HasColumnName("VITALICIO");

            entity.HasOne(d => d.IdCalleNavigation).WithMany(p => p.Socios)
                .HasForeignKey(d => d.IdCalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOCIOS_RELATIONS_CALLES");

            entity.HasOne(d => d.IdEstadoSocioNavigation).WithMany(p => p.Socios)
                .HasForeignKey(d => d.IdEstadoSocio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOCIOS_RELATIONS_ESTADO_D");
        });

        modelBuilder.Entity<Sociosconsaldoafavor>(entity =>
        {
            entity.HasKey(e => new { e.Socio, e.Anio, e.Mes });

            entity.ToTable("SOCIOSCONSALDOAFAVOR");

            entity.Property(e => e.Socio).HasColumnName("SOCIO");
            entity.Property(e => e.Anio).HasColumnName("ANIO");
            entity.Property(e => e.Mes).HasColumnName("MES");
            entity.Property(e => e.Pago)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PAGO");
            entity.Property(e => e.Ucp).HasColumnName("UCP");
        });

        modelBuilder.Entity<Temporal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TEMPORAL");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdProfesion).HasColumnName("ID_PROFESION");
        });

        modelBuilder.Entity<Temporal2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TEMPORAL2");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdMateria).HasColumnName("ID_materia");
        });

        modelBuilder.Entity<TemporalMateriale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TEMPORAL_MATERIALES");

            entity.Property(e => e.AnoEdicion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("ANO_EDICION");
            entity.Property(e => e.CantPaginas)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CANT_PAGINAS");
            entity.Property(e => e.Clase)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CLASE");
            entity.Property(e => e.EanIsbn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("EAN_ISBN");
            entity.Property(e => e.Extension)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("EXTENSION");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPRA");
            entity.Property(e => e.IdColeccion).HasColumnName("ID_COLECCION");
            entity.Property(e => e.IdEditor).HasColumnName("ID_EDITOR");
            entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");
            entity.Property(e => e.IdEncuadernacion).HasColumnName("ID_ENCUADERNACION");
            entity.Property(e => e.IdIdioma).HasColumnName("ID_IDIOMA");
            entity.Property(e => e.IdIlustrador).HasColumnName("ID_ILUSTRADOR");
            entity.Property(e => e.IdProcedencia).HasColumnName("ID_PROCEDENCIA");
            entity.Property(e => e.IdProloguista).HasColumnName("ID_PROLOGUISTA");
            entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");
            entity.Property(e => e.IdSerie).HasColumnName("ID_SERIE");
            entity.Property(e => e.IdTipoMaterial).HasColumnName("ID_TIPO_MATERIAL");
            entity.Property(e => e.IdTraductor).HasColumnName("ID_TRADUCTOR");
            entity.Property(e => e.Libristica)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("LIBRISTICA");
            entity.Property(e => e.Lugar)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("LUGAR");
            entity.Property(e => e.NroColeccion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NRO_COLECCION");
            entity.Property(e => e.NroEdicion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NRO_EDICION");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.NroTomo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NRO_TOMO");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Titulo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("TITULO");
            entity.Property(e => e.Volumen)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("VOLUMEN");
        });

        modelBuilder.Entity<TiposDeDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).IsClustered(false);

            entity.ToTable("TIPOS_DE_DOCUMENTOS", tb =>
                {
                    tb.HasTrigger("TD_TIPOS_DE_DOCUMENTOS");
                    tb.HasTrigger("TU_TIPOS_DE_DOCUMENTOS");
                });

            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");
            entity.Property(e => e.Desca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCA");
            entity.Property(e => e.Descc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCC");
        });

        modelBuilder.Entity<TiposDeMaterial>(entity =>
        {
            entity.HasKey(e => e.IdTipoMaterial).IsClustered(false);

            entity.ToTable("TIPOS_DE_MATERIAL");

            entity.Property(e => e.IdTipoMaterial).HasColumnName("ID_TIPO_MATERIAL");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<TiposDeMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoMovimiento).IsClustered(false);

            entity.ToTable("TIPOS_DE_MOVIMIENTOS");

            entity.Property(e => e.IdTipoMovimiento).HasColumnName("ID_TIPO_MOVIMIENTO");
            entity.Property(e => e.CantDias).HasColumnName("CANT_DIAS");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.NroMov).HasColumnName("NRO_MOV");
        });

        modelBuilder.Entity<TiposDeSocio>(entity =>
        {
            entity.HasKey(e => e.IdTipoSocio).IsClustered(false);

            entity.ToTable("TIPOS_DE_SOCIOS", tb =>
                {
                    tb.HasTrigger("TD_TIPOS_DE_SOCIOS");
                    tb.HasTrigger("TU_TIPOS_DE_SOCIOS");
                });

            entity.Property(e => e.IdTipoSocio).HasColumnName("ID_TIPO_SOCIO");
            entity.Property(e => e.Desca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCA");
        });

        modelBuilder.Entity<TiposDeSoporte>(entity =>
        {
            entity.HasKey(e => e.IdTipoSoporte);

            entity.ToTable("TIPOS_DE_SOPORTE");

            entity.Property(e => e.IdTipoSoporte).HasColumnName("ID_TIPO_SOPORTE");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<TiposDeSuspencion>(entity =>
        {
            entity.HasKey(e => e.IdTipoSuspencion).IsClustered(false);

            entity.ToTable("TIPOS_DE_SUSPENCION");

            entity.Property(e => e.IdTipoSuspencion).HasColumnName("ID_TIPO_SUSPENCION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<TiposDeSuspencionXSocio>(entity =>
        {
            entity.HasKey(e => new { e.Socio, e.IdTipoSuspencion }).HasName("PK_TIPOS_DE_SUSPENCION_X_SOCIO");

            entity.ToTable("TIPOS_DE_SUSPENCION_X_SOCIOS");

            entity.HasIndex(e => e.Socio, "RELATIONSHIP_63_FK");

            entity.HasIndex(e => e.IdTipoSuspencion, "RELATIONSHIP_67_FK");

            entity.Property(e => e.Socio).HasColumnName("SOCIO");
            entity.Property(e => e.IdTipoSuspencion).HasColumnName("ID_TIPO_SUSPENCION");
            entity.Property(e => e.SuspendidoHasta)
                .HasColumnType("datetime")
                .HasColumnName("SUSPENDIDO_HASTA");

            entity.HasOne(d => d.IdTipoSuspencionNavigation).WithMany(p => p.TiposDeSuspencionXSocios)
                .HasForeignKey(d => d.IdTipoSuspencion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIPOS_DE_RELATIONS_TIPOS_DE");

            entity.HasOne(d => d.SocioNavigation).WithMany(p => p.TiposDeSuspencionXSocios)
                .HasForeignKey(d => d.Socio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIPOS_DE_RELATIONS_SOCIOS");
        });

        modelBuilder.Entity<Tradprol>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TRADPROL");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdTradprol)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_TRADPROL");
        });

        modelBuilder.Entity<TransferenciasDeMaterial>(entity =>
        {
            entity.HasKey(e => e.IdTransferencia).IsClustered(false);

            entity.ToTable("TRANSFERENCIAS_DE_MATERIAL");

            entity.HasIndex(e => e.NroInventario, "RELATIONSHIP_63_FK");

            entity.Property(e => e.IdTransferencia).HasColumnName("ID_TRANSFERENCIA");
            entity.Property(e => e.Destino).HasColumnName("DESTINO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.NroInventario).HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.Origen).HasColumnName("ORIGEN");

            entity.HasOne(d => d.NroInventarioNavigation).WithMany(p => p.TransferenciasDeMaterials)
                .HasForeignKey(d => d.NroInventario)
                .HasConstraintName("FK_TRANSFER_RELATIONS_MATERIAL");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_USUARIOS")
                .IsClustered(false);

            entity.ToTable("Usuario");

            entity.Property(e => e.ApeyNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.NroInventario);

            entity.ToTable("VIDEOS");

            entity.Property(e => e.NroInventario)
                .ValueGeneratedNever()
                .HasColumnName("NRO_INVENTARIO");
            entity.Property(e => e.Ano)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ANO");
            entity.Property(e => e.Clase)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CLASE");
            entity.Property(e => e.Extension)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EXTENSION");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPRA");
            entity.Property(e => e.IdColeccion).HasColumnName("ID_COLECCION");
            entity.Property(e => e.IdEditora).HasColumnName("ID_EDITORA");
            entity.Property(e => e.IdGenero).HasColumnName("ID_GENERO");
            entity.Property(e => e.IdIdioma).HasColumnName("ID_IDIOMA");
            entity.Property(e => e.IdLugar).HasColumnName("ID_LUGAR");
            entity.Property(e => e.IdProcedencia).HasColumnName("ID_PROCEDENCIA");
            entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");
            entity.Property(e => e.IdSerie).HasColumnName("ID_SERIE");
            entity.Property(e => e.IdTipoMaterial).HasColumnName("ID_TIPO_MATERIAL");
            entity.Property(e => e.IdTipoSoporte).HasColumnName("ID_TIPO_SOPORTE");
            entity.Property(e => e.Libristica)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LIBRISTICA");
            entity.Property(e => e.NroEjemplar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRO_EJEMPLAR");
            entity.Property(e => e.NroTomo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRO_TOMO");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Subtitulo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SUBTITULO");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITULO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
