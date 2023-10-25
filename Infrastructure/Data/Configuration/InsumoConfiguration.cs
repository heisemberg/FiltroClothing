using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("Insumo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.NombreInsumo)
                 .IsRequired()
                 .HasMaxLength(100);
            
            builder.Property(e => e.ValorUnit)
                    .IsRequired()
                    .HasColumnType("double");

            builder.Property(e => e.StockMin)
                 .IsRequired()
                 .HasColumnType("int");

            builder.Property(e => e.StockMax)
                 .IsRequired()
                 .HasColumnType("int");
        }
    }
}