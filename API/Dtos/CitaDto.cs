using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CitaDto
    {
        public int Id { get; set; }
        public int IdIntervaloHorario { get; set; }
        public DateOnly Citas { get; set; }
    }
}