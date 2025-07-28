using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FrontEnd.Models;

namespace FrontEnd.Models
{
    public class PalabraClave
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("IdMicroEmprendedor")]
        public int IdMicroEmprendedor { get; set; }
        public string Palabra { get; set; }

    }
}
