using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Empleado : BaseEntity
    {
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string NombreEmp { get; set; }
        public int IdCargo { get; set; }
        public Cargo Cargos { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
        public int MunicipioId { get; set; }
        public Municipio Municipios { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}