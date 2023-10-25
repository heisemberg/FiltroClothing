using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.FechaOrden)
            .HasColumnType("datetime");

            builder.HasOne(p => p.Empleados)
            .WithMany(p => p.Ordenes)
            .HasForeignKey(p => p.IdEmpleado);

            builder.HasOne(p => p.Clientes)
            .WithMany(p => p.Ordenes)
            .HasForeignKey(p => p.IdCliente);

            builder.HasOne(p => p.Estados)
            .WithMany(p => p.Ordenes)
            .HasForeignKey(p => p.IdEstado);
        }
    }
}