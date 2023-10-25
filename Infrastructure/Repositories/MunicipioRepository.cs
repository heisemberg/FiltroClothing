using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MunicipioRepository : GenericRepository<Municipio>, IMunicipio
    {
        private readonly FiltroClothingContext _context;

        public MunicipioRepository(FiltroClothingContext context) : base(context)
        {
            _context = context;
        }

    }
}