using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.Ventas)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdVenta);

            builder.HasOne(p => p.Inventarios)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdInventario);

            builder.HasOne(p => p.Tallas)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdTalla);

            builder.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasColumnType("int");
            
            builder.Property(e => e.ValorUnitario)
                    .IsRequired()
                    .HasColumnType("double");
        }
    }
}