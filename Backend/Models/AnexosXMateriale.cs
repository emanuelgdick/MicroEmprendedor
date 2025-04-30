using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class AnexosXMateriale
{
    public long IdAnexo { get; set; }

    public long NroInventario { get; set; }

    public long? Cantidad { get; set; }

    public virtual Materiale NroInventarioNavigation { get; set; } = null!;
}
