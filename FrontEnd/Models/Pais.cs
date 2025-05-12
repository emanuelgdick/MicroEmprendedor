using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required] 
        public ICollection<Provincia> Provincia { get; set; }
    }
}
