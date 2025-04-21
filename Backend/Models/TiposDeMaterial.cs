using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TiposDeMaterial
{
    public long IdTipoMaterial { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Materiale> Materiales { get; set; } = new List<Materiale>();
}
