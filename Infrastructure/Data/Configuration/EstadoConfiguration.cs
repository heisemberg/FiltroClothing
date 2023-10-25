using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.HasOne(p => p.TipoEstados)
                .WithMany(p => p.Estados)
                .HasForeignKey(p => p.IdTipoEstado);
        }
    }
}