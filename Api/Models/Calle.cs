using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Calle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
