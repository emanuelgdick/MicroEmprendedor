using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public class Localidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        
        [ForeignKey("IdProvincia")]
        public Provincia provincia { get; set; }
    }
}
