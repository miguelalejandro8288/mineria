using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Producto : BaseEntity
{
    public int Id { get; set; }

    public string NombreQuimico { get; set; } = null!;

    public string CodigoInterno { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string UnidadMedida { get; set; } = null!;

    public decimal? StockActual { get; set; }

    public decimal StockMinimoSeguridad { get; set; }

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<AnalisisLaboratorio> AnalisisLaboratorios { get; set; } = new List<AnalisisLaboratorio>();

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
