using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class Mutual
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DescA { get; set; }
        public string? DescC { get; set; }
        public string? Codigo { get; set; }
    }
}
