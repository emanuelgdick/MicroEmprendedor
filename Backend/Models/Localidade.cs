using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Localidade
{
    public long IdLocalidad { get; set; }

    public long IdProvincia { get; set; }

    public string? Desca { get; set; }

    public string? CodigoPostal { get; set; }
}
