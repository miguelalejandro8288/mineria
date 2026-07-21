using System;
using System.Collections.Generic;

namespace mineria.Models;

public partial class Usuario : BaseEntity
{
 

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Rol { get; set; } = null!;

  

    

    public virtual ICollection<AnalisisLaboratorio> AnalisisLaboratorios { get; set; } = new List<AnalisisLaboratorio>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
