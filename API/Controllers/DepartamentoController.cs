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
    public class DepartamentoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
    {
        var Departamento = await _unitOfWork.Departamentos.GetAllAsync();

        return _mapper.Map<List<DepartamentoDto>>(Departamento);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Get(int id){
        var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if (Departamento == null){
            return NotFound();
        }
        return _mapper.Map<DepartamentoDto>(Departamento);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Post(DepartamentoDto DepartamentoDto){
        var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
        _unitOfWork.Departamentos.Add(Departamento);
        await _unitOfWork.SaveAsync();
        if(Departamento == null){
            return BadRequest();
        }
        DepartamentoDto.Id = Departamento.Id;
        return CreatedAtAction(nameof(Post), new {id = DepartamentoDto.Id}, DepartamentoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto DepartamentoDto){
        if(DepartamentoDto.Id == 0){
            DepartamentoDto.Id = id;
        }

        if(DepartamentoDto.Id != id){
            return BadRequest();
        }

        if(DepartamentoDto == null){
            return NotFound();
        }
        var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
        _unitOfWork.Departamentos.Update(Departamento);
        await _unitOfWork.SaveAsync();
        return DepartamentoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if(Departamento == null){
            return NotFound();
        }
        _unitOfWork.Departamentos.Remove(Departamento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
    }
