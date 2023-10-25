using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Insumo : BaseEntity
    {
        public string NombreInsumo { get; set; }
        public double ValorUnit { get; set; }
        public int StockMin { get; set; }
        public int StoclMax { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
        public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
    }
}