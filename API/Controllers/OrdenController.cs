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
    public class OrdenController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrdenController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrdenDto>>> Get()
    {
        var Orden = await _unitOfWork.Ordenes.GetAllAsync();

        return _mapper.Map<List<OrdenDto>>(Orden);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrdenDto>> Get(int id){
        var Orden = await _unitOfWork.Ordenes.GetByIdAsync(id);
        if (Orden == null){
            return NotFound();
        }
        return _mapper.Map<OrdenDto>(Orden);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrdenDto>> Post(OrdenDto OrdenDto){
        var Orden = _mapper.Map<Orden>(OrdenDto);
        _unitOfWork.Ordenes.Add(Orden);
        await _unitOfWork.SaveAsync();
        if(Orden == null){
            return BadRequest();
        }
        OrdenDto.Id = Orden.Id;
        return CreatedAtAction(nameof(Post), new {id = OrdenDto.Id}, OrdenDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrdenDto>> Put(int id, [FromBody]OrdenDto OrdenDto){
        if(OrdenDto.Id == 0){
            OrdenDto.Id = id;
        }

        if(OrdenDto.Id != id){
            return BadRequest();
        }

        if(OrdenDto == null){
            return NotFound();
        }
        var Orden = _mapper.Map<Orden>(OrdenDto);
        _unitOfWork.Ordenes.Update(Orden);
        await _unitOfWork.SaveAsync();
        return OrdenDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Orden = await _unitOfWork.Ordenes.GetByIdAsync(id);
        if(Orden == null){
            return NotFound();
        }
        _unitOfWork.Ordenes.Remove(Orden);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
