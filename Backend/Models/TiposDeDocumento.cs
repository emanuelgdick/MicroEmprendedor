using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TiposDeDocumento
{
    public int IdTipoDocumento { get; set; }

    public string? Desca { get; set; }

    public string? Descc { get; set; }
}
