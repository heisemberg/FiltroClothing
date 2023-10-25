using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
    {
        public void Configure(EntityTypeBuilder<InventarioTalla> builder)
        {
            builder.ToTable("InventarioTalla");

            builder.HasKey(t => new { t.IdInventario, t.IdTalla});

            builder.HasOne(p => p.Inventarios)
             .WithMany(p => p.InventarioTallas)
             .HasForeignKey(p => p.IdInventario);

             builder.HasOne(p => p.Tallas)
                 .WithMany(p => p.InventarioTallas)
                 .HasForeignKey(p => p.IdTalla);

             builder.Property(e => e.Cantidad)
                 .IsRequired()
                 .HasColumnType("int");


        }
    }
}