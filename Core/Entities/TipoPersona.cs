using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TipoPersona : BaseEntity
    {
        [Required]
        public string NombreTipoPersona { get; set; }
        public ICollection<Proveedor> Proveedores { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}