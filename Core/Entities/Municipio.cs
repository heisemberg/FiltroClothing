using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Municipio : BaseEntity
    {
        public string NombreMun { get; set; }
        public int IdDepartamento { get; set; }
        public Departamento DepartamentoS { get; set; }
        public ICollection<Empresa> Empresas { get; set; }  
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Empleado> Empleados { get; set; }

    }
}