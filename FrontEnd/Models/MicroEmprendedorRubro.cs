using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FrontEnd.Models;

namespace FrontEnd.Models
{
    public class MicroEmprendedorRubro
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("IdMicroEmprendedor")]
        public int IdMicroEmprendedor { get; set; }
        //public MicroEmprendedor? MicroEmprendedor { get; set; }

        [ForeignKey("IdRubro")]
        public int IdRubro { get; set; }
        //public Rubro? Rubro { get; set; }

    }
}
