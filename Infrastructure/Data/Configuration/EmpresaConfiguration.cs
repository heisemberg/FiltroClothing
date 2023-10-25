using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(e =>e.Id );
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.Nit)
                   .IsUnique();
            
            builder.Property(e => e.RazonSocial)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(e => e.RepresentanteLegal)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");
            
            builder.HasOne(p => p.Municipios)
                .WithMany(p => p.Empresas)
                .HasForeignKey(p => p.IdMunicipio);
        }
    }
}