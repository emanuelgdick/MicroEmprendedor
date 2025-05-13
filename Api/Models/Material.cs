using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Material
    {
        public int Id { get; set; }

        [ForeignKey("IdIdioma")]
        public Idioma Idioma { get; set; }

        [ForeignKey("IdProcedencia")]
        public Procedencia Procedencia { get; set; }

        [ForeignKey("IdSerie")]
        public Serie Serie { get; set; }

        [ForeignKey("IdEditorial")]
        public Editorial Editorial { get; set; }

        [ForeignKey("IdSector")]
        public Sector Sector { get; set; }

        [ForeignKey("IdTipoMaterial")]
        public TipoMaterial TipoMaterial { get; set; }

        [ForeignKey("IdEncuadernacion")]
        public Encuadernacion Encuadernacion { get; set; }

        [ForeignKey("IdColeccion")]
        public Coleccion Coleccion { get; set; }

        [ForeignKey("IdTraductor")]
        public Traductor Traductor { get; set; }

        [ForeignKey("IdProloguista")]
        public Prologuista Prologuista { get; set; }

        [ForeignKey("IdEditor")]
        public Editor Editor { get; set; }

        [ForeignKey("IdIlustrador")]
        public Ilustrador Ilustrador { get; set; }

        [ForeignKey("IdLugar")]
        public Lugar Lugar { get; set; }

        public int NroInventario { get; set; }
        public string NroTomo { get; set; }
        public string CantPaginas { get; set; }
        public string Extension { get; set; }
        public string Precio { get; set; }
        public string FechaCompra { get; set; }
        public string EanIsbn { get; set; }
        public string Volumen { get; set; }
        public string NroColeccion { get; set; }
        public string NroEdicion { get; set; }
        public string AnoEdicion { get; set; }
        public string Clase { get; set; }
        public string Libristica { get; set; }
        public string Titulo { get; set; }
        public string Observaciones { get; set; }
        public bool TieneIlustracion { get; set; }
        public string NroEjemplar { get; set; }

    }
}
