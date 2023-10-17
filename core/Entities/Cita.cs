using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities;
    public class Cita : BaseEntity
    {
        public int IdIntervaloHorario { get; set; }
        public IntervaloHorario IntervaloHorario { get; set; } 
        public DateOnly Citas { get; set; }
        public ICollection<Entrega> Entregas { get; set; }
    }