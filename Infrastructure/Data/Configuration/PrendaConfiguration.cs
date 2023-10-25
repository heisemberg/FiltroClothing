using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            builder.ToTable("prenda");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.IdPrenda).IsUnique();

            builder.Property(e => e.NombrePrenda)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.ValorUnitCop)
            .IsRequired()
            .HasColumnType("double");

            builder.Property(e => e.ValorUnitUsd)
            .IsRequired()
            .HasColumnType("double");

            builder.HasOne(p => p.Estados)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdEstado);

            builder.HasOne(p => p.TiposProtecciones)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdTipoProteccion);

            builder.HasOne(p => p.Generos)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdGenero);
        }
    }
}