using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        protected MappingProfiles()
        {
            CreateMap<Accion, AccionDto>().ReverseMap();
            CreateMap<Cita, CitaDto>().ReverseMap();
            CreateMap<Entrega, EntregaDto>().ReverseMap();
            CreateMap<EstadoSolicitud, EstadoSolicitudDto>().ReverseMap();
            CreateMap<IntervaloHorario, IntervaloHorarioDto>().ReverseMap();
        }
    }
}