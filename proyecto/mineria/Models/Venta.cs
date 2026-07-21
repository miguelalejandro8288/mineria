using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Venta : BaseEntity
{
    public int Id { get; set; }

    public string NumeroComprobante { get; set; } = null!;

    public string ClienteNombre { get; set; } = null!;

    public string ClienteDocumento { get; set; } = null!;

    public DateOnly FechaVenta { get; set; }

    public decimal TotalVenta { get; set; }

    public int IdUsuarioComercial { get; set; }

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Usuario IdUsuarioComercialNavigation { get; set; } = null!;
}
