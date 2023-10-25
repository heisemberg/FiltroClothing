using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.NitProveedor).IsUnique();

            builder.Property(e => e.NombreProveedor)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.TipoPersonas)
            .WithMany(p => p.Proveedores)
            .HasForeignKey(p => p.IdTipoPersona);

            builder.HasOne(p => p.Municipios)
            .WithMany(p => p.Proveedores)
            .HasForeignKey(p => p.IdMunicipio);
        }
    }
}