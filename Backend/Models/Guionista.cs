using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Guionista
{
    public long IdGuionista { get; set; }

    public string Descripcion { get; set; } = null!;
}
