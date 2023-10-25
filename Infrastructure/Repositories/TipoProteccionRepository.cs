using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TipoProteccionRepository : GenericRepository<TipoProteccion>, ITipoProteccion
    {
        private readonly FiltroClothingContext _context;

        public TipoProteccionRepository(FiltroClothingContext context) : base(context)
        {
            _context = context;
        }

    }
}