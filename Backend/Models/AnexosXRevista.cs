using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class AnexosXRevista
{
    public long IdAnexo { get; set; }

    public long IdRevista { get; set; }

    public long? Cantidad { get; set; }

    public virtual Revista IdRevistaNavigation { get; set; } = null!;
}
