using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Models
{
    [DataContract(IsReference = true)]
    public class Rubro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public ICollection<MicroEmprendedorRubro> MicroEmprendedores { get; set; }
    }

}
