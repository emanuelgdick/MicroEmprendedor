using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class AutoresXMateriale
{
    public long NroInventario { get; set; }

    public long IdAutor { get; set; }

    public bool? Ppal { get; set; }
}
