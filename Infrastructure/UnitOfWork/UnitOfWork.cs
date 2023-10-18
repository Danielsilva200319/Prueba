using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PruebaContext _context;
        private AccionRepository _acciones;
        private CitaRepository _citas;
        private EntregaRepository _entregas;
        private EstadoSolicitudRepository _estadosSolicitudes;
        private IntervaloHorarioRepository _intervalosHorarios;

        public UnitOfWork(PruebaContext context)
        {
            _context = context;
        }

        public IAccionRepository Acciones
        {
            get
            {
                if (_acciones == null)
                {
                    _acciones = new AccionRepository(_context);
                }
                return _acciones;
            }
        }

        public ICitaRepository Citas
        {
            get
            {
                if (_citas == null)
                {
                    _citas = new CitaRepository(_context);
                }
                return _citas;
            }
        }

        public IEntregaRepository Entregas
        {
            get
            {
                if (_entregas == null)
                {
                    _entregas = new EntregaRepository(_context);
                }
                return _entregas;
            }
        }

        public IEstadoSolicitudRepository EstadosSolicitudes
        {
            get
            {
                if (_estadosSolicitudes == null)
                {
                    _estadosSolicitudes = new EstadoSolicitudRepository(_context);
                }
                return _estadosSolicitudes;
            }
        }

        public IIntervaloHorarioRepository IntervalosHorarios
        {
            get
            {
                if (_intervalosHorarios == null)
                {
                    _intervalosHorarios = new IntervaloHorarioRepository(_context);
                }
                return _intervalosHorarios;
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