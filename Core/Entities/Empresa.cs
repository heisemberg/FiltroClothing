using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Empresa : BaseEntity
    {
        [Required]
        public int Nit { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string RepresentanteLegal { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        public int IdMunicipio { get; set; }
        public Municipio Municipios { get; set; }
        
    }
}