using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Camion : BaseEntity
{
    public int Id { get; set; }

    public string Placa { get; set; } = null!;

    public string ConductorNombre { get; set; } = null!;

    public string? ConductorLicencia { get; set; }

    public decimal? PesoTaraEstimado { get; set; }

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
