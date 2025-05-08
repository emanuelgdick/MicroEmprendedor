using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Calle> Calle { get; set; }
        public DbSet<Cobrador> Cobrador { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoSocio> TipoSocio { get; set; }
        public DbSet<EstadoSocio> EstadoSocio { get; set; }
        public DbSet<CategoriaSocio> CategoriaSocio { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Profesion> Profesion { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Anexo> Anexo { get; set; }
        public DbSet<Coleccion> Coleccion { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Encuadernacion> Encuadernacion { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Guionista> Guionista{get;set;}
        public DbSet<Idioma> Idioma { get; set; }
        public DbSet<Interprete> Intereprete { get; set; }

        public DbSet<Lugar> Lugar { get; set; } 
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Procedencia> Procedencia { get;set; }

        public DbSet<Productor>Productor { get; set; }

        public DbSet<Provincia> Provincia { get; set; }
        

    }
}
