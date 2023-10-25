using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TallaRepository : GenericRepository<Talla>, ITalla
    {
        private readonly FiltroClothingContext _context;

        public TallaRepository(FiltroClothingContext context) : base(context)
        {
            _context = context;
        }

    }
}