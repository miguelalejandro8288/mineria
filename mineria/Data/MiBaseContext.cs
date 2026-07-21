using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mineria.Models;

namespace mineria.Data;

public partial class MiBaseContext : DbContext
{
    public MiBaseContext()
    {
    }
    

    public MiBaseContext(DbContextOptions<MiBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnalisisLaboratorio> AnalisisLaboratorios { get; set; }

    public virtual DbSet<Camion> Camions { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Lote> Lotes { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mineria;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnalisisLaboratorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Analisis__3214EC0706CFA235");

            entity.ToTable("AnalisisLaboratorio");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.CertificadoPdfUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EstadoAnalisis)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImpurezasPorcentaje)
                .HasDefaultValue(0.00m)
                .HasColumnType("numeric(5, 2)");
            entity.Property(e => e.LeyCobre)
                .HasDefaultValue(0.00m)
                .HasColumnType("numeric(5, 2)");
            entity.Property(e => e.LeyOro)
                .HasDefaultValue(0.000m)
                .HasColumnType("numeric(8, 3)");
            entity.Property(e => e.LeyPlata)
                .HasDefaultValue(0.000m)
                .HasColumnType("numeric(8, 3)");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.AnalisisLaboratorios)
                .HasForeignKey(d => d.IdLote)
                .HasConstraintName("FK_Analisis_Lote");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.AnalisisLaboratorios)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_Analisis_Producto");

            entity.HasOne(d => d.IdUsuarioLaboratorioNavigation).WithMany(p => p.AnalisisLaboratorios)
                .HasForeignKey(d => d.IdUsuarioLaboratorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Analisis_Usuario");
        });

        modelBuilder.Entity<Camion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Camion__3214EC0729A0CAF9");

            entity.ToTable("Camion");

            entity.HasIndex(e => e.Placa, "UQ__Camion__8310F99DD9635959").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.ConductorLicencia)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ConductorNombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PesoTaraEstimado).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.Placa)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Compra__3214EC0793BEAC69");

            entity.ToTable("Compra");

            entity.HasIndex(e => e.NumeroFactura, "UQ__Compra__CF12F9A621906D6E").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalCompra).HasColumnType("numeric(12, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Proveedor");

            entity.HasOne(d => d.IdUsuarioComercialNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuarioComercial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Usuario");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleC__3214EC07BAB68B98");

            entity.ToTable("DetalleCompra");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Cantidad).HasColumnType("numeric(12, 3)");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PrecioUnitario).HasColumnType("numeric(12, 4)");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", false)
                .HasColumnType("numeric(25, 7)");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK_DetalleCompra_Compra");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Producto");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleV__3214EC0786F56615");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Cantidad).HasColumnType("numeric(12, 3)");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PrecioUnitario).HasColumnType("numeric(12, 4)");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", false)
                .HasColumnType("numeric(25, 7)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVenta_Producto");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK_DetalleVenta_Venta");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lote__3214EC07700BA152");

            entity.ToTable("Lote");

            entity.HasIndex(e => e.CodigoLote, "UQ__Lote__DFCD3B6CFBAD6BCE").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.CodigoLote)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HumedadPorcentaje)
                .HasDefaultValue(0.00m)
                .HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PesoBruto).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.PesoNeto)
                .HasComputedColumnSql("([PesoBruto]-[PesoTara])", false)
                .HasColumnType("numeric(11, 3)");
            entity.Property(e => e.PesoNetoSeco).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.PesoTara).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.ProcedenciaMina)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCamionNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdCamion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lote_Camion");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lote_Proveedor");

            entity.HasOne(d => d.IdUsuarioBalanzaNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdUsuarioBalanza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lote_Usuario");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orden__3214EC07FC019964");

            entity.ToTable("Orden");

            entity.HasIndex(e => e.CodigoOrden, "UQ__Orden__1B9107A40EC87A56").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.CodigoOrden)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EstadoOrden)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LeyFinalDespacho)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PesoDespachado).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.TipoSalida)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ValorLiquidacion).HasColumnType("numeric(12, 2)");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.IdLote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orden_Lote");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC070F2656B4");

            entity.ToTable("Producto");

            entity.HasIndex(e => e.CodigoInterno, "UQ__Producto__28C928759A30C9B8").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.CodigoInterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreQuimico)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.StockActual)
                .HasDefaultValue(0.000m)
                .HasColumnType("numeric(12, 3)");
            entity.Property(e => e.StockMinimoSeguridad).HasColumnType("numeric(12, 3)");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC0717B1C9C6");

            entity.ToTable("Proveedor");

            entity.HasIndex(e => e.RucNit, "UQ__Proveedo__8690CC915707A422").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.RucNit)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoProveedor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07C2C34C55");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A1948D6AEDE").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venta__3214EC07F26D20F0");

            entity.HasIndex(e => e.NumeroComprobante, "UQ__Venta__7AA8EFFCDC6C067F").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.ClienteDocumento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ClienteNombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NumeroComprobante)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalVenta).HasColumnType("numeric(12, 2)");

            entity.HasOne(d => d.IdUsuarioComercialNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuarioComercial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
