using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class EstadoDeSocio
{
    public long IdEstadoSocio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Socio> Socios { get; set; } = new List<Socio>();
}
