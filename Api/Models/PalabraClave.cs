using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Api.Models;

namespace Api.Models
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
