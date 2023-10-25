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
    public class GeneroController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GeneroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GeneroDto>>> Get()
    {
        var Genero = await _unitOfWork.Generos.GetAllAsync();

        return _mapper.Map<List<GeneroDto>>(Genero);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroDto>> Get(int id){
        var Genero = await _unitOfWork.Generos.GetByIdAsync(id);
        if (Genero == null){
            return NotFound();
        }
        return _mapper.Map<GeneroDto>(Genero);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GeneroDto>> Post(GeneroDto GeneroDto){
        var Genero = _mapper.Map<Genero>(GeneroDto);
        _unitOfWork.Generos.Add(Genero);
        await _unitOfWork.SaveAsync();
        if(Genero == null){
            return BadRequest();
        }
        GeneroDto.Id = Genero.Id;
        return CreatedAtAction(nameof(Post), new {id = GeneroDto.Id}, GeneroDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody]GeneroDto GeneroDto){
        if(GeneroDto.Id == 0){
            GeneroDto.Id = id;
        }

        if(GeneroDto.Id != id){
            return BadRequest();
        }

        if(GeneroDto == null){
            return NotFound();
        }
        var Genero = _mapper.Map<Genero>(GeneroDto);
        _unitOfWork.Generos.Update(Genero);
        await _unitOfWork.SaveAsync();
        return GeneroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Genero = await _unitOfWork.Generos.GetByIdAsync(id);
        if(Genero == null){
            return NotFound();
        }
        _unitOfWork.Generos.Remove(Genero);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
