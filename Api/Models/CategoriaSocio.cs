using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CategoriaSocio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int cantMaterial { get; set; }
    }
}
