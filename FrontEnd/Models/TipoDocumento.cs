using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class TipoDocumento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescA { get; set; }
        [Required]
        public string DescC { get; set; }
    }
}
