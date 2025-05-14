using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class Interprete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApeyNom { get; set; }
    }
}
