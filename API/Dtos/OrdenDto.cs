using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrdenDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpledo { get; set; }
        public int IdCliente { get; set; }
        public int IdEstado { get; set; }
    }
}