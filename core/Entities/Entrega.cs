using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities;
    public class Entrega : BaseEntity
    {
        public int IdCita { get; set; }
        public Cita Citas { get; set; }
        public int IdIntervaloHorario { get; set; }
        public IntervaloHorario IntervalosHorarios { get; set; }
        public int IdAccion { get; set; }
        public Accion Acciones { get; set; }
        public int IdEstadoSolicitud { get; set; }
        public EstadoSolicitud EstadosSolicitudes { get; set; }
        public TimeOnly HoraCita { get; set; }
        public string NumeroEntrega { get; set; }
        public string Cliente { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateOnly CargaPrevista { get; set; }
        public DateOnly EntregaPrevista { get; set; }
        public ICollection<Accion> Accions { get; set; }
    }