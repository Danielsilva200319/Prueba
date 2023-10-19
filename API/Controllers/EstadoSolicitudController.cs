using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using ApiNoti.Controllers;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstadoSolicitudController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoSolicitudController(IUnitOfWork  unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoSolicitudDto>>> Get()
        {
            var estadosSolicitudes = await _unitOfWork.EstadosSolicitudes.GetAllAsync();
            return _mapper.Map<List<EstadoSolicitudDto>>(estadosSolicitudes);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoSolicitudDto>>Get(int id)
        {
            var estadoSolicitud = await _unitOfWork.EstadosSolicitudes.GetByIdAsync(id);
            if(estadoSolicitud == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadoSolicitudDto>(estadoSolicitud);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoSolicitudDto>>Post(EstadoSolicitudDto estadoSolicitudDto)
        {
            var estadoSolicitud = _mapper.Map<EstadoSolicitud>(estadoSolicitudDto);
            this._unitOfWork.EstadosSolicitudes.Add(estadoSolicitud);
            await _unitOfWork.SaveAsync();
            if(estadoSolicitud == null)
            {
                return BadRequest();
            }
            estadoSolicitudDto.Id = estadoSolicitud.Id;
            return CreatedAtAction(nameof(Post), new {id = estadoSolicitudDto.Id}, estadoSolicitudDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoSolicitudDto>> Put(int id, [FromBody] EstadoSolicitudDto estadoSolicitudDto)
        {
            if(estadoSolicitudDto == null)
            {
                return NotFound();
            }
            var estadosSolicitudes = _mapper.Map<EstadoSolicitud>(estadoSolicitudDto);
            _unitOfWork.EstadosSolicitudes.Update(estadosSolicitudes);
            await _unitOfWork.SaveAsync();
            return estadoSolicitudDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var estadoSolicitud = await _unitOfWork.EstadosSolicitudes.GetByIdAsync(id);
            if(estadoSolicitud == null)
            {
                return NotFound();
            }
            _unitOfWork.EstadosSolicitudes.Remove(estadoSolicitud);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}