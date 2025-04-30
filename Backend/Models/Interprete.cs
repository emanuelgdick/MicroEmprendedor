using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Interprete
{
    public long IdInterprete { get; set; }

    public string Descripcion { get; set; } = null!;
}
