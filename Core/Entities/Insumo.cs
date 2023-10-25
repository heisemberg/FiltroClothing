using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Insumo : BaseEntity
    {
        [Required]
        public string NombreInsumo { get; set; }
        [Required]
        public double ValorUnit { get; set; }
        [Required]
        public int StockMin { get; set; }
        [Required]
        public int StockMax { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
        public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
    }
}