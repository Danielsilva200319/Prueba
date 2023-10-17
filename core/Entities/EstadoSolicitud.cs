using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities;
    public class EstadoSolicitud : BaseEntity
    {
        public string NombreEstado { get; set; }
        public ICollection<Entrega> Entregas { get; set; }
    }