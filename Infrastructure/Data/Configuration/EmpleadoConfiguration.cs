using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
     {
         public void Configure(EntityTypeBuilder<Empleado> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("Empleado");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.HasIndex(e => e.IdEmpleado)
                 .IsUnique();

             builder.Property(e => e.NombreEmp)
                 .IsRequired()
                 .HasMaxLength(100);
             
             builder.HasOne(p => p.Cargos)
                 .WithMany(p => p.Empleados)
                 .HasForeignKey(p => p.IdCargo);

             
             }
         }
     }