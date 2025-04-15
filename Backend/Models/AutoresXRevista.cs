using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class AutoresXRevista
{
    public long IdRevista { get; set; }

    public long IdAutor { get; set; }

    public bool? Ppal { get; set; }
}
