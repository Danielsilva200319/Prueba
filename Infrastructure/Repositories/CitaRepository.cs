using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
        private readonly PruebaContext _context;

        public CitaRepository(PruebaContext context) : base(context)
        {
            _context = context;
        }
    }
}