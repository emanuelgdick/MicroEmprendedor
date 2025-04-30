using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class MateriasXMateriale
{
    public long NroInventario { get; set; }

    public long IdMateria { get; set; }

    public virtual Materiale NroInventarioNavigation { get; set; } = null!;
}
