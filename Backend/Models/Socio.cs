using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Socio
{
    public long Socio1 { get; set; }

    public int IdTipoSocio { get; set; }

    public long IdEstadoSocio { get; set; }

    public long IdCategoria { get; set; }

    public int IdTipoDocumento { get; set; }

    public long IdCalle { get; set; }

    public long? IdProfesion { get; set; }

    public long IdLocalidad { get; set; }

    public string? Apeynom { get; set; }

    public long? Nro { get; set; }

    public string? Depto { get; set; }

    public string? Telefono { get; set; }

    public DateTime? Fnac { get; set; }

    public DateTime? Fingreso { get; set; }

    public DateTime? Fegreso { get; set; }

    public string? Observaciones { get; set; }

    public double? Documento { get; set; }

    public bool? Vitalicio { get; set; }

    public bool? Pagaaca { get; set; }

    public virtual Calle IdCalleNavigation { get; set; } = null!;

    public virtual EstadoDeSocio IdEstadoSocioNavigation { get; set; } = null!;

    public virtual ICollection<Novedade> Novedades { get; set; } = new List<Novedade>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<TiposDeSuspencionXSocio> TiposDeSuspencionXSocios { get; set; } = new List<TiposDeSuspencionXSocio>();
}
