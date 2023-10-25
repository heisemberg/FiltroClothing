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
    public class TipoProteccionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoProteccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoProteccionDto>>> Get()
    {
        var TipoProteccion = await _unitOfWork.TipoProtecciones.GetAllAsync();

        return _mapper.Map<List<TipoProteccionDto>>(TipoProteccion);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoProteccionDto>> Get(int id){
        var TipoProteccion = await _unitOfWork.TipoProtecciones.GetByIdAsync(id);
        if (TipoProteccion == null){
            return NotFound();
        }
        return _mapper.Map<TipoProteccionDto>(TipoProteccion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoProteccionDto>> Post(TipoProteccionDto TipoProteccionDto){
        var TipoProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
        _unitOfWork.TipoProtecciones.Add(TipoProteccion);
        await _unitOfWork.SaveAsync();
        if(TipoProteccion == null){
            return BadRequest();
        }
        TipoProteccionDto.Id = TipoProteccion.Id;
        return CreatedAtAction(nameof(Post), new {id = TipoProteccionDto.Id}, TipoProteccionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoProteccionDto>> Put(int id, [FromBody]TipoProteccionDto TipoProteccionDto){
        if(TipoProteccionDto.Id == 0){
            TipoProteccionDto.Id = id;
        }

        if(TipoProteccionDto.Id != id){
            return BadRequest();
        }

        if(TipoProteccionDto == null){
            return NotFound();
        }
        var TipoProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
        _unitOfWork.TipoProtecciones.Update(TipoProteccion);
        await _unitOfWork.SaveAsync();
        return TipoProteccionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var TipoProteccion = await _unitOfWork.TipoProtecciones.GetByIdAsync(id);
        if(TipoProteccion == null){
            return NotFound();
        }
        _unitOfWork.TipoProtecciones.Remove(TipoProteccion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
