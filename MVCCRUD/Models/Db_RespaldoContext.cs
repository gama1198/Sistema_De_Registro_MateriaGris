using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCCRUD.Models
{
    public partial class Db_RespaldoContext : DbContext
    {
        public Db_RespaldoContext()
        {
        }

        public Db_RespaldoContext(DbContextOptions<Db_RespaldoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<SubProducto> SubProductos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //              optionsBuilder.UseSqlServer("server=DESKTOP-OPBLDQH\\SQLEXPRESS; database=Db_Respaldo; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("FACTURA");

                entity.HasIndex(e => e.IdProveedores, "REFERENCE_2_FK");

                entity.Property(e => e.IdFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_FACTURA");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdProveedores).HasColumnName("ID_PROVEEDORES");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PRODUCTO");

                entity.HasOne(d => d.IdProveedoresNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdProveedores)
                    .HasConstraintName("FK_FACTURA_REFERENCE_PROVEEDO");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdSubProducto).HasColumnName("ID_SUB_PRODUCTO");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PRODUCTO");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.IdProveedores);

                entity.ToTable("PROVEEDORES");

                entity.Property(e => e.IdProveedores)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PROVEEDORES");

                entity.Property(e => e.FonoProveedor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FONO_PROVEEDOR");

                entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");

                entity.Property(e => e.NombreProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PROVEEDOR");

                entity.Property(e => e.RutProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RUT_PROVEEDOR");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdStock);

                entity.ToTable("STOCK");

                entity.HasIndex(e => e.IdFactura, "REFERENCE_3_FK");

                entity.HasIndex(e => e.IdSubProducto, "REFERENCE_4_FK");

                entity.Property(e => e.IdStock)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_STOCK");

                entity.Property(e => e.CantidadStock).HasColumnName("CANTIDAD_STOCK");

                entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");

                entity.Property(e => e.IdSubProducto).HasColumnName("ID_SUB_PRODUCTO");

                entity.Property(e => e.ValorCosto).HasColumnName("VALOR_COSTO");

                entity.Property(e => e.ValorVenta).HasColumnName("VALOR_VENTA");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_STOCK_REFERENCE_FACTURA");

                entity.HasOne(d => d.IdSubProductoNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdSubProducto)
                    .HasConstraintName("FK_STOCK_REFERENCE_SUB_PROD");
            });

            modelBuilder.Entity<SubProducto>(entity =>
            {
                entity.HasKey(e => e.IdSubProducto);

                entity.ToTable("SUB_PRODUCTO");

                entity.HasIndex(e => e.IdProducto, "REFERENCE_1_FK");

                entity.Property(e => e.IdSubProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SUB_PRODUCTO");

                entity.Property(e => e.DescripcionSubProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_SUB_PRODUCTO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdStock).HasColumnName("ID_STOCK");

                entity.Property(e => e.NombreSubProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_SUB_PRODUCTO");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.SubProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_SUB_PROD_REFERENCE_PRODUCTO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
