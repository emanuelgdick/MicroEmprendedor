using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class ConsultorioContext : DbContext
    {
        public ConsultorioContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Profesion> Profesion { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Mutual> Mutual { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
