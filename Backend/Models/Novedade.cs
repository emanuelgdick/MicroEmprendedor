using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Novedade
{
    public long IdNovedad { get; set; }

    public long? IdPrestamo { get; set; }

    public long? IdReserva { get; set; }

    public long? Socio { get; set; }

    public long? NroInventario { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }

    public virtual Materiale? NroInventarioNavigation { get; set; }

    public virtual Socio? SocioNavigation { get; set; }
}
