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
    public class AccionController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AccionDto>>> Get()
        {
            var acciones = await _unitOfWork.Acciones.GetAllAsync();
            return _mapper.Map<List<AccionDto>>(acciones);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccionDto>>Get(int id)
        {
            var accion = await _unitOfWork.Acciones.GetByIdAsync(id);
            if(accion == null)
            {
                return NotFound();
            }
            return _mapper.Map<AccionDto>(accion);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccionDto>>Post(AccionDto accionDto)
        {
            var accion = _mapper.Map<Accion>(accionDto);
            this._unitOfWork.Acciones.Add(accion);
            await _unitOfWork.SaveAsync();
            if(accion == null)
            {
                return BadRequest();
            }
            accionDto.Id = accion.Id;
            return CreatedAtAction(nameof(Post), new {id = accionDto.Id}, accionDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccionDto>> Put(int id, [FromBody] AccionDto accionDto)
        {
            if(accionDto == null)
            {
                return NotFound();
            }
            var acciones = _mapper.Map<Accion>(accionDto);
            _unitOfWork.Acciones.Update(acciones);
            await _unitOfWork.SaveAsync();
            return accionDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var accion = await _unitOfWork.Acciones.GetByIdAsync(id);
            if(accion == null)
            {
                return NotFound();
            }
            _unitOfWork.Acciones.Remove(accion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}