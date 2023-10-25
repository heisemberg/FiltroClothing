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
    public class PrendaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PrendaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PrendaDto>>> Get()
    {
        var Prenda = await _unitOfWork.Prendas.GetAllAsync();

        return _mapper.Map<List<PrendaDto>>(Prenda);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PrendaDto>> Get(int id){
        var Prenda = await _unitOfWork.Prendas.GetByIdAsync(id);
        if (Prenda == null){
            return NotFound();
        }
        return _mapper.Map<PrendaDto>(Prenda);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PrendaDto>> Post(PrendaDto PrendaDto){
        var Prenda = _mapper.Map<Prenda>(PrendaDto);
        _unitOfWork.Prendas.Add(Prenda);
        await _unitOfWork.SaveAsync();
        if(Prenda == null){
            return BadRequest();
        }
        PrendaDto.Id = Prenda.Id;
        return CreatedAtAction(nameof(Post), new {id = PrendaDto.Id}, PrendaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PrendaDto>> Put(int id, [FromBody]PrendaDto PrendaDto){
        if(PrendaDto.Id == 0){
            PrendaDto.Id = id;
        }

        if(PrendaDto.Id != id){
            return BadRequest();
        }

        if(PrendaDto == null){
            return NotFound();
        }
        var Prenda = _mapper.Map<Prenda>(PrendaDto);
        _unitOfWork.Prendas.Update(Prenda);
        await _unitOfWork.SaveAsync();
        return PrendaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Prenda = await _unitOfWork.Prendas.GetByIdAsync(id);
        if(Prenda == null){
            return NotFound();
        }
        _unitOfWork.Prendas.Remove(Prenda);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
