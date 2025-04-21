using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TiposDeMovimiento
{
    public long IdTipoMovimiento { get; set; }

    public string? Descripcion { get; set; }

    public int? CantDias { get; set; }

    public long? NroMov { get; set; }

    public virtual ICollection<MovimientosDeMaterial> MovimientosDeMaterials { get; set; } = new List<MovimientosDeMaterial>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
