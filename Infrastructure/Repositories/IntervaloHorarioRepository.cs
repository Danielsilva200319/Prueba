using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class IntervaloHorarioRepository : GenericRepository<IntervaloHorario>, IIntervaloHorarioRepository
    {
        private readonly PruebaContext _context;

        public IntervaloHorarioRepository(PruebaContext context) : base(context)
        {
            _context = context;
        }
    }
}