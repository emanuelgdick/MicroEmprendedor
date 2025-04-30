using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Editora
{
    public long IdEditora { get; set; }

    public string Descripcion { get; set; } = null!;
}
