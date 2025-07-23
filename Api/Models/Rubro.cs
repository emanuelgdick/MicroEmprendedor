using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Models
{
    
    public partial class Rubro
    {

        public Rubro() {
            this.MicroEmprendedores = new HashSet<MicroEmprendedor>();   
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

   
        public virtual ICollection<MicroEmprendedor>? MicroEmprendedores { get; set; }
    }

}
