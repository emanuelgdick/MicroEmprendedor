using System.ComponentModel.DataAnnotations;

namespace FrontendApi.Models
{
    public class Coleccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
