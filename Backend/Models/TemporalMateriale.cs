using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TemporalMateriale
{
    public long NroInventario { get; set; }

    public long? IdIdioma { get; set; }

    public long? IdProcedencia { get; set; }

    public long? IdSerie { get; set; }

    public long? IdEditorial { get; set; }

    public long IdSector { get; set; }

    public long IdTipoMaterial { get; set; }

    public long? IdEncuadernacion { get; set; }

    public long? IdColeccion { get; set; }

    public long? IdTraductor { get; set; }

    public long? IdProloguista { get; set; }

    public long? IdEditor { get; set; }

    public long? IdIlustrador { get; set; }

    public string? NroTomo { get; set; }

    public string? CantPaginas { get; set; }

    public string? Extension { get; set; }

    public string? Lugar { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaCompra { get; set; }

    public string? EanIsbn { get; set; }

    public string? Volumen { get; set; }

    public string? NroColeccion { get; set; }

    public string? NroEdicion { get; set; }

    public string? AnoEdicion { get; set; }

    public string? Clase { get; set; }

    public string? Libristica { get; set; }

    public string? Titulo { get; set; }

    public string? Observaciones { get; set; }
}
