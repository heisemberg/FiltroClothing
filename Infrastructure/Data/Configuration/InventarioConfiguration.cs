using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.CodInv)
                   .IsUnique();

            builder.HasOne(p => p.Prendas)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(p => p.IdPrenda);

            builder.Property(e => e.ValorVtaCop)
                    .IsRequired()
                    .HasColumnType("double");

            builder.Property(e => e.ValorVtaUsd)
                    .IsRequired()
                    .HasColumnType("double");
        }
    }
}