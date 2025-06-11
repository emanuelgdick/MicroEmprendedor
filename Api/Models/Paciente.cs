
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace Api.Models
{
    public class Paciente
    {
        public int Id { get; set; }


        [ForeignKey("TipoDocumento")]
        public int? IdTipoDocumento { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }

        [ForeignKey("Profesion")]
        public int? IdProfesion { get; set; }
        public Profesion? Profesion { get; set; }

        [ForeignKey("Localidad")]
        public int? IdLocalidad { get; set; }
        public Localidad? Localidad { get; set; }

        public string ApeyNom { get; set; }
        public string NroDocumento { get; set; }
        public char Sexo { get; set; }
        public string? Calle { get; set; }
        public string? Nro { get; set; }
        public string? Piso { get; set; }
        public string? Depto { get; set; }
        public string? TelFijo { get; set; }
        public string? TelCelular { get; set; }
        public string? Email { get; set; }
        public DateTime? Fnac { get; set; }
        public int NroHC { get; set; }
        public string? Observaciones { get; set; }
        public string? Historia { get; set; }


        //public string? foto { get; set; }

    }
}
