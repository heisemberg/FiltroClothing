using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MunicipioDto
    {
        public int Id { get; set; }
        public string NombreMun { get; set; }
        public int IdDepartamento { get; set; }
    }
}