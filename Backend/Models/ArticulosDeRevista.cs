using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class ArticulosDeRevista
{
    public long IdArticulo { get; set; }

    public long? IdNumero { get; set; }

    public long? NroPagina { get; set; }

    public string? Descripcion { get; set; }

    public string? Observaciones { get; set; }
}
