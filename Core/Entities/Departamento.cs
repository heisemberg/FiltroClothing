using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Departamento : BaseEntity
    {
        [Required]
        public string NombreDep { get; set; }
        public int IdPais { get; set; }
        public Pais Paises { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
        
    }
}