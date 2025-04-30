using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Prestamo
{
    public long IdPrestamo { get; set; }

    public long NroInventario { get; set; }

    public long IdTipoMovimiento { get; set; }

    public long Socio { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public long? IdSector { get; set; }

    public int? IdTipoMaterial { get; set; }

    public long? IdMovimiento { get; set; }

    public long? IdUsuario { get; set; }

    public virtual TiposDeMovimiento IdTipoMovimientoNavigation { get; set; } = null!;

    public virtual Socio SocioNavigation { get; set; } = null!;
}
