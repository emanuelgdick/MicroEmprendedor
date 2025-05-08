using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApeyNom { get; set; }
    }
}
