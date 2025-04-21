using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Genero
{
    public long IdGenero { get; set; }

    public string Descripcion { get; set; } = null!;
}
