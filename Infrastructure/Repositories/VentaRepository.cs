using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class VentaRepository : GenericRepository<Venta>, IVenta
    {
        private readonly FiltroClothingContext _context;

        public VentaRepository(FiltroClothingContext context) : base(context)
        {
            _context = context;
        }
    }
}