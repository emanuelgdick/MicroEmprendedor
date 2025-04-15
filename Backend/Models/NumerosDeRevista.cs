using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class NumerosDeRevista
{
    public long IdNumero { get; set; }

    public long? IdRevista { get; set; }

    public long? Nro { get; set; }

    public long? Ano { get; set; }

    public long? Mes { get; set; }

    public string? Observaciones { get; set; }
}
