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
        //  public Paciente Paciente { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string text { get; set; }
        public string? color { get; set; }


    }
}
