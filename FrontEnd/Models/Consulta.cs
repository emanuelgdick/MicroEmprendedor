using FrontEnd.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string observaciones { get; set; }
        public string? Color { get; set; }


    }
}
