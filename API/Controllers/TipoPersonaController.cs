using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
    {
        var TipoPersona = await _unitOfWork.TipoPersonas.GetAllAsync();

        return _mapper.Map<List<TipoPersonaDto>>(TipoPersona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaDto>> Get(int id){
        var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
        if (TipoPersona == null){
            return NotFound();
        }
        return _mapper.Map<TipoPersonaDto>(TipoPersona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersonaDto>> Post(TipoPersonaDto TipoPersonaDto){
        var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
        _unitOfWork.TipoPersonas.Add(TipoPersona);
        await _unitOfWork.SaveAsync();
        if(TipoPersona == null){
            return BadRequest();
        }
        TipoPersonaDto.Id = TipoPersona.Id;
        return CreatedAtAction(nameof(Post), new {id = TipoPersonaDto.Id}, TipoPersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody]TipoPersonaDto TipoPersonaDto){
        if(TipoPersonaDto.Id == 0){
            TipoPersonaDto.Id = id;
        }

        if(TipoPersonaDto.Id != id){
            return BadRequest();
        }

        if(TipoPersonaDto == null){
            return NotFound();
        }
        var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
        _unitOfWork.TipoPersonas.Update(TipoPersona);
        await _unitOfWork.SaveAsync();
        return TipoPersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
        if(TipoPersona == null){
            return NotFound();
        }
        _unitOfWork.TipoPersonas.Remove(TipoPersona);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
