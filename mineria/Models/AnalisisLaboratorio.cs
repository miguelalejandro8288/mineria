using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class AnalisisLaboratorio : BaseEntity
{
    public int Id { get; set; }

    public int? IdLote { get; set; }

    public int? IdProducto { get; set; }

    public decimal? LeyOro { get; set; }

    public decimal? LeyPlata { get; set; }

    public decimal? LeyCobre { get; set; }

    public decimal? ImpurezasPorcentaje { get; set; }

    public string? EstadoAnalisis { get; set; }

    public string? CertificadoPdfUrl { get; set; }

    public int IdUsuarioLaboratorio { get; set; }

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Lote? IdLoteNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Usuario IdUsuarioLaboratorioNavigation { get; set; } = null!;
}
