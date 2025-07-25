using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Models
{

   
    public partial class MicroEmprendedor
    {

   
        [Key]
        public int Id { get; set; }

        [ForeignKey("TipoDocumento")]
        public int? IdTipoDocumento { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }

        [ForeignKey("Localidad")]
        public int? IdLocalidad { get; set; }
        public Localidad? Localidad { get; set; }

        [Required]
        public string ApeyNom { get; set; }

        public string? Dni { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string? Calle { get; set; }
        public string? Nro { get; set; }
        public string? Piso { get; set; }
        public string? Depto { get; set; }
        public string? TelFijo { get; set; }
        public string? TelCelular { get; set; }
        public string? Correo { get; set; }
        public string? SitioWeb { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Observaciones { get; set; }


        public virtual ICollection<MicroEmprendedorRubro> Rubros { get; set; }

    }
}

