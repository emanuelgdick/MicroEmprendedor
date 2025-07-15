using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class MicroEmprendedorRubro
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MicroEmprendedor")]
        public int? IdMicroEmprendedor { get; set; }
        public MicroEmprendedor? MicroEmprendedor { get; set; }

        [ForeignKey("Rubro")]
        public int? IdRubro { get; set; }
        public Rubro? Rubro { get; set; }
    }
}
