using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TiposDeSuspencion
{
    public long IdTipoSuspencion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<TiposDeSuspencionXSocio> TiposDeSuspencionXSocios { get; set; } = new List<TiposDeSuspencionXSocio>();
}
