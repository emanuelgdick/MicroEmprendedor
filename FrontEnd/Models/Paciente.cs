
using Frontend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata;
using System.Web.Mvc;

namespace FrontEnd.Models
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

        [ForeignKey("Medico")]
        public int? IdMedico { get; set; }
        public Medico? Medico { get; set; }


        [ForeignKey("Mutual")]
        public int? IdMutual { get; set; }
        public Mutual? Mutual { get; set; }
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

        [AllowHtml]
        public string? Historia { get; set; }
        //public string? foto { get; set; }

    }
}
