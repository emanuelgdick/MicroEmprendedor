using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Directore
{
    public long IdDirector { get; set; }

    public string Descripcion { get; set; } = null!;
}
