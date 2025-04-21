using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Pago
{
    public long IdPago { get; set; }

    public long Socio { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? ImporteTotal { get; set; }

    public virtual ICollection<Cuota> IdCuota { get; set; } = new List<Cuota>();
}
