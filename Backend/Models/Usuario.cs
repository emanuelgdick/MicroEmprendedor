using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Usuario
{
    public long Id { get; set; }

    public string? ApeyNom { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }
}
