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
    public class EntregaController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EntregaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> Get()
        {
            var entregas = await _unitOfWork.Entregas.GetAllAsync();
            return _mapper.Map<List<EntregaDto>>(entregas);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntregaDto>>Get(int id)
        {
            var entrega = await _unitOfWork.Entregas.GetByIdAsync(id);
            if(entrega == null)
            {
                return NotFound();
            }
            return _mapper.Map<EntregaDto>(entrega);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EntregaDto>>Post(EntregaDto entregaDto)
        {
            var entrega = _mapper.Map<Entrega>(entregaDto);
            this._unitOfWork.Entregas.Add(entrega);
            await _unitOfWork.SaveAsync();
            if(entrega == null)
            {
                return BadRequest();
            }
            entregaDto.Id = entrega.Id;
            return CreatedAtAction(nameof(Post), new {id = entregaDto.Id}, entregaDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntregaDto>> Put(int id, [FromBody] EntregaDto entregaDto)
        {
            if(entregaDto == null)
            {
                return NotFound();
            }
            var entregas = _mapper.Map<Entrega>(entregaDto);
            _unitOfWork.Entregas.Update(entregas);
            await _unitOfWork.SaveAsync();
            return entregaDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var entrega = await _unitOfWork.Entregas.GetByIdAsync(id);
            if(entrega == null)
            {
                return NotFound();
            }
            _unitOfWork.Entregas.Remove(entrega);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}