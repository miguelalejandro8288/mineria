using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Lote : BaseEntity
{
    public int Id { get; set; }

    public string CodigoLote { get; set; } = null!;

    public int IdProveedor { get; set; }

    public int IdCamion { get; set; }

    public string ProcedenciaMina { get; set; } = null!;

    public decimal PesoBruto { get; set; }

    public decimal PesoTara { get; set; }

    public decimal? PesoNeto { get; set; }

    public decimal? HumedadPorcentaje { get; set; }

    public decimal? PesoNetoSeco { get; set; }

    public int IdUsuarioBalanza { get; set; }

    public bool? Borrado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<AnalisisLaboratorio> AnalisisLaboratorios { get; set; } = new List<AnalisisLaboratorio>();

    public virtual Camion IdCamionNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioBalanzaNavigation { get; set; } = null!;

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
