using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class BibliotecaContext:DbContext
    {
        public BibliotecaContext(DbContextOptions options):base(options) 
        {
            
        }

        public DbSet<Calle> Calle { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
