using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Proveedor : BaseEntity
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string RucNit { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string TipoProveedor { get; set; } = null!;

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
