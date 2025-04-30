using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Sectore
{
    public long IdSector { get; set; }

    public string? Descripcion { get; set; }

    public bool? AdmitePrestamos { get; set; }

    public virtual ICollection<Materiale> Materiales { get; set; } = new List<Materiale>();

    public virtual ICollection<MovimientosDeMaterial> MovimientosDeMaterials { get; set; } = new List<MovimientosDeMaterial>();
}
