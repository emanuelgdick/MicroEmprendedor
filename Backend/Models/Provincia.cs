using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Provincia
{
    public long IdProvincia { get; set; }

    public long IdPais { get; set; }

    public string? Descripcion { get; set; }
}
