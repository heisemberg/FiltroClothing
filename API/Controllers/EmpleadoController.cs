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
    public class EmpleadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var Empleado = await _unitOfWork.Empleados.GetAllAsync();

        return _mapper.Map<List<EmpleadoDto>>(Empleado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Get(int id){
        var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (Empleado == null){
            return NotFound();
        }
        return _mapper.Map<EmpleadoDto>(Empleado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoDto>> Post(EmpleadoDto EmpleadoDto){
        var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
        _unitOfWork.Empleados.Add(Empleado);
        await _unitOfWork.SaveAsync();
        if(Empleado == null){
            return BadRequest();
        }
        EmpleadoDto.Id = Empleado.Id;
        return CreatedAtAction(nameof(Post), new {id = EmpleadoDto.Id}, EmpleadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody]EmpleadoDto EmpleadoDto){
        if(EmpleadoDto.Id == 0){
            EmpleadoDto.Id = id;
        }

        if(EmpleadoDto.Id != id){
            return BadRequest();
        }

        if(EmpleadoDto == null){
            return NotFound();
        }
        var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
        _unitOfWork.Empleados.Update(Empleado);
        await _unitOfWork.SaveAsync();
        return EmpleadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
        if(Empleado == null){
            return NotFound();
        }
        _unitOfWork.Empleados.Remove(Empleado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
