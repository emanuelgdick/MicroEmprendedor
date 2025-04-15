using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class CategoriasDeSocio
{
    public long IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public long? CantMaterial { get; set; }
}
