using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApeyNom { get; set; }
    }
}
