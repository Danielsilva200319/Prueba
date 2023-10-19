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
    public class IntervaloHorarioController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IntervaloHorarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<IntervaloHorarioDto>>> Get()
        {
            var intervalosHorarios = await _unitOfWork.IntervalosHorarios.GetAllAsync();
            return _mapper.Map<List<IntervaloHorarioDto>>(intervalosHorarios);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IntervaloHorarioDto>>Get(int id)
        {
            var intervaloHorario = await _unitOfWork.IntervalosHorarios.GetByIdAsync(id);
            if(intervaloHorario == null)
            {
                return NotFound();
            }
            return _mapper.Map<IntervaloHorarioDto>(intervaloHorario);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IntervaloHorarioDto>>Post(IntervaloHorarioDto intervaloHorarioDto)
        {
            var intervaloHorario = _mapper.Map<IntervaloHorario>(intervaloHorarioDto);
            this._unitOfWork.IntervalosHorarios.Add(intervaloHorario);
            await _unitOfWork.SaveAsync();
            if(intervaloHorario == null)
            {
                return BadRequest();
            }
            intervaloHorarioDto.Id = intervaloHorario.Id;
            return CreatedAtAction(nameof(Post), new {id = intervaloHorarioDto.Id}, intervaloHorarioDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IntervaloHorarioDto>> Put(int id, [FromBody] IntervaloHorarioDto intervaloHorarioDto)
        {
            if(intervaloHorarioDto == null)
            {
                return NotFound();
            }
            var intervalosHorarios = _mapper.Map<IntervaloHorario>(intervaloHorarioDto);
            _unitOfWork.IntervalosHorarios.Update(intervalosHorarios);
            await _unitOfWork.SaveAsync();
            return intervaloHorarioDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var estadoSolicitud = await _unitOfWork.IntervalosHorarios.GetByIdAsync(id);
            if(estadoSolicitud == null)
            {
                return NotFound();
            }
            _unitOfWork.IntervalosHorarios.Remove(estadoSolicitud);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}