using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class TipoSoporte
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
