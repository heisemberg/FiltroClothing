using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{

    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly FiltroClothingContext _context;

        public EmpleadoRepository(FiltroClothingContext context) : base(context)
        {
            _context = context;
        }
    }
}