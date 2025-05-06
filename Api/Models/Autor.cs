using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string ApeyNom { get; set; }
    }
}
