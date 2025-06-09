using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class Localidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }

    }
}
