using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class Diagnostico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
