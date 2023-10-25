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
    public class TipoEstadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoEstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoEstadoDto>>> Get()
    {
        var TipoEstado = await _unitOfWork.TipoEstados.GetAllAsync();

        return _mapper.Map<List<TipoEstadoDto>>(TipoEstado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEstadoDto>> Get(int id){
        var TipoEstado = await _unitOfWork.TipoEstados.GetByIdAsync(id);
        if (TipoEstado == null){
            return NotFound();
        }
        return _mapper.Map<TipoEstadoDto>(TipoEstado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoEstadoDto>> Post(TipoEstadoDto TipoEstadoDto){
        var TipoEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
        _unitOfWork.TipoEstados.Add(TipoEstado);
        await _unitOfWork.SaveAsync();
        if(TipoEstado == null){
            return BadRequest();
        }
        TipoEstadoDto.Id = TipoEstado.Id;
        return CreatedAtAction(nameof(Post), new {id = TipoEstadoDto.Id}, TipoEstadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEstadoDto>> Put(int id, [FromBody]TipoEstadoDto TipoEstadoDto){
        if(TipoEstadoDto.Id == 0){
            TipoEstadoDto.Id = id;
        }

        if(TipoEstadoDto.Id != id){
            return BadRequest();
        }

        if(TipoEstadoDto == null){
            return NotFound();
        }
        var TipoEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
        _unitOfWork.TipoEstados.Update(TipoEstado);
        await _unitOfWork.SaveAsync();
        return TipoEstadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var TipoEstado = await _unitOfWork.TipoEstados.GetByIdAsync(id);
        if(TipoEstado == null){
            return NotFound();
        }
        _unitOfWork.TipoEstados.Remove(TipoEstado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
