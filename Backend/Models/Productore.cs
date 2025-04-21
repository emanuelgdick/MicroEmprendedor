using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Productore
{
    public long IdProductor { get; set; }

    public string Descripcion { get; set; } = null!;
}
