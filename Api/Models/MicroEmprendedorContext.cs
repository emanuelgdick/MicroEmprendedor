using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class MicroEmprendedorContext : DbContext
    {
        public MicroEmprendedorContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MicroEmprendedor> MicroEmprendedor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Rubro> Rubro { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<MicroEmprendedorRubro> MicroEmprendedorRubro { get; set; }


    }
}
