using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Venta : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }
        public Empleado Empleados { get; set; }
        public int IdCliente { get; set; }
        public Cliente Clientes { get; set; }
        public int IdFormaPago { get; set; }
        public FormaPago FormaPagos { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}