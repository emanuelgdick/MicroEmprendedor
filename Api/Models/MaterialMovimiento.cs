using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class MaterialMovimiento
    {
        public int Id { get; set; }

        [ForeignKey("IdTipoMovimiento")]
        public TipoMovimiento TipoMovimiento { get; set; }
        
        [ForeignKey("IdSector")]
        public Sector Sector { get; set; }

        [ForeignKey("IdSocio")]
        public Socio Socio { get; set; }

        [ForeignKey("IdTipoMaterial")]
        public TipoMaterial TipoMaterial { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string NroInventario { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string NroMovimiento { get; set; }
        public string Observaciones { get; set; }
    }
}
