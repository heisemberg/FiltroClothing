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
    public class DetalleVentaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get()
    {
        var DetalleVenta = await _unitOfWork.DetalleVentas.GetAllAsync();

        return _mapper.Map<List<DetalleVentaDto>>(DetalleVenta);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleVentaDto>> Get(int id){
        var DetalleVenta = await _unitOfWork.DetalleVentas.GetByIdAsync(id);
        if (DetalleVenta == null){
            return NotFound();
        }
        return _mapper.Map<DetalleVentaDto>(DetalleVenta);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleVentaDto>> Post(DetalleVentaDto DetalleVentaDto){
        var DetalleVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
        _unitOfWork.DetalleVentas.Add(DetalleVenta);
        await _unitOfWork.SaveAsync();
        if(DetalleVenta == null){
            return BadRequest();
        }
        DetalleVentaDto.Id = DetalleVenta.Id;
        return CreatedAtAction(nameof(Post), new {id = DetalleVentaDto.Id}, DetalleVentaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleVentaDto>> Put(int id, [FromBody]DetalleVentaDto DetalleVentaDto){
        if(DetalleVentaDto.Id == 0){
            DetalleVentaDto.Id = id;
        }

        if(DetalleVentaDto.Id != id){
            return BadRequest();
        }

        if(DetalleVentaDto == null){
            return NotFound();
        }
        var DetalleVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
        _unitOfWork.DetalleVentas.Update(DetalleVenta);
        await _unitOfWork.SaveAsync();
        return DetalleVentaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var DetalleVenta = await _unitOfWork.DetalleVentas.GetByIdAsync(id);
        if(DetalleVenta == null){
            return NotFound();
        }
        _unitOfWork.DetalleVentas.Remove(DetalleVenta);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
