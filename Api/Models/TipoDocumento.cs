using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class TipoDocumento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
