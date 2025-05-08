using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Editora
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
