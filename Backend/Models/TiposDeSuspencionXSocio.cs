using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TiposDeSuspencionXSocio
{
    public long Socio { get; set; }

    public long IdTipoSuspencion { get; set; }

    public DateTime? SuspendidoHasta { get; set; }

    public virtual TiposDeSuspencion IdTipoSuspencionNavigation { get; set; } = null!;

    public virtual Socio SocioNavigation { get; set; } = null!;
}
