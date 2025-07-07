using Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class ConsultaDiagnostico
    {
        [Key]
        public int Id { get; set; }



        [ForeignKey("Consulta")]
        public int? IdConsulta { get; set; }
        public Consulta? Consulta { get; set; }


        [ForeignKey("Diagnostico")]
        public int? IdDiagnostico { get; set; }
        public Diagnostico? Diagnostico { get; set; }

    }
}
