using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Venta");

            builder.HasKey(e => e.Id);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Fecha)
            .IsRequired()
            .HasColumnType("datetime");

            builder.HasOne(p => p.Empleados)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdEmpleado);

            builder.HasOne(p => p.Clientes)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdCliente);

            builder.HasOne(p => p.FormaPagos)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdFormaPago);
        }
    }
}