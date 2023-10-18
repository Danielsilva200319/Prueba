using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EntregaDto
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdIntervaloHorario { get; set; }
        public int IdAccion { get; set; }
        public int IdEstadoSolicitud { get; set; }
        public TimeOnly HoraCita { get; set; }
        public string NumeroEntrega { get; set; }
        public string Cliente { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateOnly CargaPrevista { get; set; }
        public DateOnly EntregaPrevista { get; set; }
    }
}