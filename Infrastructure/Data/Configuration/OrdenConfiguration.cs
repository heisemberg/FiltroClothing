using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
     {
         public void Configure(EntityTypeBuilder<Orden> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("Orden");

             builder.Property(p => p.IdOrden).HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn).HasMaxLength(3);    

            
             }
         }
     }