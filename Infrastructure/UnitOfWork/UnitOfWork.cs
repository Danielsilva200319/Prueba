using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PruebaContext _context;

        public UnitOfWork(PruebaContext context)
        {
            _context = context;
        }

        public IAccionRepository Acciones
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICitaRepository Citas
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEntregaRepository Entregas
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEstadoSolicitudRepository EstadosSolicitudes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IIntervaloHorarioRepository IntervalosHorarios
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}