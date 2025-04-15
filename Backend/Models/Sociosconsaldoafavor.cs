using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Sociosconsaldoafavor
{
    public int Socio { get; set; }

    public int Anio { get; set; }

    public int Mes { get; set; }

    public decimal Pago { get; set; }

    public int Ucp { get; set; }
}
