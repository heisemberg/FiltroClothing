using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
     {
         public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("InsumoPrenda");

            builder.HasKey(t => new { t.IdPrenda, t.IdInsumo});

             builder.HasOne(p => p.Insumos)
             .WithMany(p => p.InsumoPrendas)
             .HasForeignKey(p => p.IdInsumo);

             builder.HasOne(p => p.Prendas)
                 .WithMany(p => p.InsumoPrendas)
                 .HasForeignKey(p => p.IdPrenda);

             builder.Property(e => e.Cantidad)
                 .IsRequired()
                 .HasColumnType("int");

             }
         }
     }