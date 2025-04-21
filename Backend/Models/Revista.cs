using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Revista
{
    public long IdRevista { get; set; }

    public long? IdEditorial { get; set; }

    public int? IdSector { get; set; }

    public long? IdProcedencia { get; set; }

    public long? IdSerie { get; set; }

    public long? IdColeccion { get; set; }

    public long? IdLugar { get; set; }

    public string? Clase { get; set; }

    public string? Libristica { get; set; }

    public DateTime? Fecha { get; set; }

    public long? IdIdioma { get; set; }

    public string? Nro { get; set; }

    public string? Ano { get; set; }

    public string? Volumen { get; set; }

    public string? Ejemplar { get; set; }

    public string? Issn { get; set; }

    public string? Titulo { get; set; }

    public string? Subtitulo { get; set; }

    public string? Observaciones { get; set; }

    public string? CantPaginas { get; set; }

    public string? Extencion { get; set; }

    public string? NroColeccion { get; set; }

    public string? Precio { get; set; }

    public virtual ICollection<AnexosXRevista> AnexosXRevista { get; set; } = new List<AnexosXRevista>();
}
