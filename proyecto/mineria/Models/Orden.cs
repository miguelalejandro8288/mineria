using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Orden : BaseEntity
{
    public int Id { get; set; }

    public string CodigoOrden { get; set; } = null!;

    public int IdLote { get; set; }

    public string EstadoOrden { get; set; } = null!;

    public string TipoSalida { get; set; } = null!;

    public decimal? PesoDespachado { get; set; }

    public string? LeyFinalDespacho { get; set; }

    public decimal? ValorLiquidacion { get; set; }

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Lote IdLoteNavigation { get; set; } = null!;
}
