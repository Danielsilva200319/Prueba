using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EntregaRepository : GenericRepository<Entrega>, IEntregaRepository
    {
        private readonly PruebaContext _context;

        public EntregaRepository(PruebaContext context) : base(context)
        {
            _context = context;
        }
    }
}