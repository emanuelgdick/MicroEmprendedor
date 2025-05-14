using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class Editorial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
