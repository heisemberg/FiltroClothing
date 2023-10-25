using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cliente : BaseEntity
    {
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        public int IdTipoPersona { get; set; }
        public TipoPersona TipoPersonas { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public int IdMunicipio { get; set; }    
        public Municipio Municipios { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}