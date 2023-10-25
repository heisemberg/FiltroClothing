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
    public class VentaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VentaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VentaDto>>> Get()
    {
        var Venta = await _unitOfWork.Ventas.GetAllAsync();

        return _mapper.Map<List<VentaDto>>(Venta);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VentaDto>> Get(int id){
        var Venta = await _unitOfWork.Ventas.GetByIdAsync(id);
        if (Venta == null){
            return NotFound();
        }
        return _mapper.Map<VentaDto>(Venta);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VentaDto>> Post(VentaDto VentaDto){
        var Venta = _mapper.Map<Venta>(VentaDto);
        _unitOfWork.Ventas.Add(Venta);
        await _unitOfWork.SaveAsync();
        if(Venta == null){
            return BadRequest();
        }
        VentaDto.Id = Venta.Id;
        return CreatedAtAction(nameof(Post), new {id = VentaDto.Id}, VentaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VentaDto>> Put(int id, [FromBody]VentaDto VentaDto){
        if(VentaDto.Id == 0){
            VentaDto.Id = id;
        }

        if(VentaDto.Id != id){
            return BadRequest();
        }

        if(VentaDto == null){
            return NotFound();
        }
        var Venta = _mapper.Map<Venta>(VentaDto);
        _unitOfWork.Ventas.Update(Venta);
        await _unitOfWork.SaveAsync();
        return VentaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Venta = await _unitOfWork.Ventas.GetByIdAsync(id);
        if(Venta == null){
            return NotFound();
        }
        _unitOfWork.Ventas.Remove(Venta);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
