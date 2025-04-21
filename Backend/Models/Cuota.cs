using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Cuota
{
    public long IdCuota { get; set; }

    public long Socio { get; set; }

    public long? Mes { get; set; }

    public long? Ano { get; set; }

    public decimal? Importe { get; set; }

    public bool? Paga { get; set; }

    public virtual ICollection<Pago> IdPagos { get; set; } = new List<Pago>();
}
