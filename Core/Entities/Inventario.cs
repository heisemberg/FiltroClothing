using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Inventario : BaseEntity
    {
        public int CodInv { get; set; }
        public int IdPrenda { get; set; }
        public Prenda Prendas { get; set; }
        [Required]
        public double ValorVtaCop { get; set; }
        [Required]
        public double ValorVtaUsd { get; set; }
        public ICollection<InventarioTalla> InventarioTallas { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}