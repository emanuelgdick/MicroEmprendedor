using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        
        
        [ForeignKey("IdPais")]
        public Pais Pais { get; set; }
        public ICollection<Localidad> Localidad { get; set; }
    }
}
