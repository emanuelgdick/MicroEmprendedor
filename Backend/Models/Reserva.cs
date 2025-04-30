using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Reserva
{
    public long IdReserva { get; set; }

    public long Socio { get; set; }

    public long? NroInventario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<Novedade> Novedades { get; set; } = new List<Novedade>();

    public virtual Socio SocioNavigation { get; set; } = null!;
}
