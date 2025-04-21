using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TransferenciasDeMaterial
{
    public long IdTransferencia { get; set; }

    public long? NroInventario { get; set; }

    public DateTime? Fecha { get; set; }

    public long? Origen { get; set; }

    public long? Destino { get; set; }

    public virtual Materiale? NroInventarioNavigation { get; set; }
}
