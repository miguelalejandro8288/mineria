using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Compra : BaseEntity
{
    public int Id { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public int IdProveedor { get; set; }

    public DateOnly FechaCompra { get; set; }

    public decimal TotalCompra { get; set; }

    public int IdUsuarioComercial { get; set; }

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioComercialNavigation { get; set; } = null!;
}
