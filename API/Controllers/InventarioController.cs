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
    public class InventarioController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventarioDto>>> Get()
    {
        var Inventario = await _unitOfWork.Inventarios.GetAllAsync();

        return _mapper.Map<List<InventarioDto>>(Inventario);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InventarioDto>> Get(int id){
        var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
        if (Inventario == null){
            return NotFound();
        }
        return _mapper.Map<InventarioDto>(Inventario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventarioDto>> Post(InventarioDto InventarioDto){
        var Inventario = _mapper.Map<Inventario>(InventarioDto);
        _unitOfWork.Inventarios.Add(Inventario);
        await _unitOfWork.SaveAsync();
        if(Inventario == null){
            return BadRequest();
        }
        InventarioDto.Id = Inventario.Id;
        return CreatedAtAction(nameof(Post), new {id = InventarioDto.Id}, InventarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InventarioDto>> Put(int id, [FromBody]InventarioDto InventarioDto){
        if(InventarioDto.Id == 0){
            InventarioDto.Id = id;
        }

        if(InventarioDto.Id != id){
            return BadRequest();
        }

        if(InventarioDto == null){
            return NotFound();
        }
        var Inventario = _mapper.Map<Inventario>(InventarioDto);
        _unitOfWork.Inventarios.Update(Inventario);
        await _unitOfWork.SaveAsync();
        return InventarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
        if(Inventario == null){
            return NotFound();
        }
        _unitOfWork.Inventarios.Remove(Inventario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
