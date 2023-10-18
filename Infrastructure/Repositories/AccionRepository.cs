using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AccionRepository : GenericRepository<Accion>, IAccionRepository
    {
        private readonly PruebaContext _context;

        public AccionRepository(PruebaContext context) : base(context)
        {
            _context = context;
        }
    }
}