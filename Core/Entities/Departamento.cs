using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Departamento : BaseEntity
    {
        public string NombreDep { get; set; }
        public int IdPais { get; set; }
        public Pais Pais { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
        
    }
}