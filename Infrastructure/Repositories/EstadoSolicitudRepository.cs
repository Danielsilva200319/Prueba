using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EstadoSolicitudRepository : GenericRepository<EstadoSolicitud>, IEstadoSolicitudRepository
    {
        private readonly PruebaContext _context;

        public EstadoSolicitudRepository(PruebaContext context) : base(context)
        {
            _context = context;
        }
    }
}