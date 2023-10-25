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
    public class ProveedorController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var Proveedor = await _unitOfWork.Proveedores.GetAllAsync();

        return _mapper.Map<List<ProveedorDto>>(Proveedor);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProveedorDto>> Get(int id){
        var Proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (Proveedor == null){
            return NotFound();
        }
        return _mapper.Map<ProveedorDto>(Proveedor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> Post(ProveedorDto ProveedorDto){
        var Proveedor = _mapper.Map<Proveedor>(ProveedorDto);
        _unitOfWork.Proveedores.Add(Proveedor);
        await _unitOfWork.SaveAsync();
        if(Proveedor == null){
            return BadRequest();
        }
        ProveedorDto.Id = Proveedor.Id;
        return CreatedAtAction(nameof(Post), new {id = ProveedorDto.Id}, ProveedorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody]ProveedorDto ProveedorDto){
        if(ProveedorDto.Id == 0){
            ProveedorDto.Id = id;
        }

        if(ProveedorDto.Id != id){
            return BadRequest();
        }

        if(ProveedorDto == null){
            return NotFound();
        }
        var Proveedor = _mapper.Map<Proveedor>(ProveedorDto);
        _unitOfWork.Proveedores.Update(Proveedor);
        await _unitOfWork.SaveAsync();
        return ProveedorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if(Proveedor == null){
            return NotFound();
        }
        _unitOfWork.Proveedores.Remove(Proveedor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
