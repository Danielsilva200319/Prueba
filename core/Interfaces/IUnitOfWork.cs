using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IUnitOfWork 
    {
        IAccionRepository Acciones { get; }
        ICitaRepository Citas { get; }
        IEntregaRepository Entregas { get; }
        IEstadoSolicitudRepository EstadosSolicitudes { get; }
        IIntervaloHorarioRepository IntervalosHorarios { get; }
        Task<int> SaveAsync();
    }
}