using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");

            builder.HasKey(e =>e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.NombreDep)
                   .IsRequired()
                   .HasMaxLength(100);
            
            builder.HasOne(p => p.Paises)
                .WithMany(p => p.Departamentos)
                .HasForeignKey(p => p.IdPais);

        }
    }
}