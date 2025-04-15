using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Video
{
    public long NroInventario { get; set; }

    public long? IdProcedencia { get; set; }

    public long? IdTipoSoporte { get; set; }

    public long? IdGenero { get; set; }

    public long? IdLugar { get; set; }

    public long? IdIdioma { get; set; }

    public long? IdSerie { get; set; }

    public long? IdColeccion { get; set; }

    public long? IdEditora { get; set; }

    public DateTime? FechaCompra { get; set; }

    public decimal? Precio { get; set; }

    public string? Clase { get; set; }

    public string? Libristica { get; set; }

    public string? Titulo { get; set; }

    public string? Subtitulo { get; set; }

    public string? NroTomo { get; set; }

    public string? NroEjemplar { get; set; }

    public string? Extension { get; set; }

    public string? Observaciones { get; set; }

    public string? Ano { get; set; }

    public long? IdSector { get; set; }

    public long? IdTipoMaterial { get; set; }
}
