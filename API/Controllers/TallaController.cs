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
    public class TallaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TallaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TallaDto>>> Get()
    {
        var Talla = await _unitOfWork.Tallas.GetAllAsync();

        return _mapper.Map<List<TallaDto>>(Talla);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TallaDto>> Get(int id){
        var Talla = await _unitOfWork.Tallas.GetByIdAsync(id);
        if (Talla == null){
            return NotFound();
        }
        return _mapper.Map<TallaDto>(Talla);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TallaDto>> Post(TallaDto TallaDto){
        var Talla = _mapper.Map<Talla>(TallaDto);
        _unitOfWork.Tallas.Add(Talla);
        await _unitOfWork.SaveAsync();
        if(Talla == null){
            return BadRequest();
        }
        TallaDto.Id = Talla.Id;
        return CreatedAtAction(nameof(Post), new {id = TallaDto.Id}, TallaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TallaDto>> Put(int id, [FromBody]TallaDto TallaDto){
        if(TallaDto.Id == 0){
            TallaDto.Id = id;
        }

        if(TallaDto.Id != id){
            return BadRequest();
        }

        if(TallaDto == null){
            return NotFound();
        }
        var Talla = _mapper.Map<Talla>(TallaDto);
        _unitOfWork.Tallas.Update(Talla);
        await _unitOfWork.SaveAsync();
        return TallaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Talla = await _unitOfWork.Tallas.GetByIdAsync(id);
        if(Talla == null){
            return NotFound();
        }
        _unitOfWork.Tallas.Remove(Talla);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
