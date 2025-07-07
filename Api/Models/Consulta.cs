using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Consulta
    {
        [Key]

        public int Id { get; set; }
        public Medico? Medico { get; set; }
        
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
       
        public  Paciente? Paciente { get; set; }
        
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public string text { get; set; }
        public string? color { get; set; }
        public string? observaciones { get; set; }

        public ICollection<Diagnostico>? Cdiag { get; set; }
    }
}
