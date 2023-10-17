using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities;
public class IntervaloHorario : BaseEntity
{
    public string IntervalosHorarios { get; set; }
    public int NumerosVehiculos { get; set; }
    public ICollection<Cita> Citas { get; set; }
    public ICollection<Entrega> Entregas { get; set; }
    /* 
    Se coloca porque en citas estamos colocando el Id de esta clase.
    La flecha indica de que lado sacarlo y la lineas horizontales 
    señalan en donde toca colocarlo.
     */
}
