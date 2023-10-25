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
    public class ClienteController : BaseController
    {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var Cliente = await _unitOfWork.Clientes.GetAllAsync();

        return _mapper.Map<List<ClienteDto>>(Cliente);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> Get(int id){
        var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (Cliente == null){
            return NotFound();
        }
        return _mapper.Map<ClienteDto>(Cliente);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Post(ClienteDto ClienteDto){
        var Cliente = _mapper.Map<Cliente>(ClienteDto);
        _unitOfWork.Clientes.Add(Cliente);
        await _unitOfWork.SaveAsync();
        if(Cliente == null){
            return BadRequest();
        }
        ClienteDto.Id = Cliente.Id;
        return CreatedAtAction(nameof(Post), new {id = ClienteDto.Id}, ClienteDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody]ClienteDto ClienteDto){
        if(ClienteDto.Id == 0){
            ClienteDto.Id = id;
        }

        if(ClienteDto.Id != id){
            return BadRequest();
        }

        if(ClienteDto == null){
            return NotFound();
        }
        var Cliente = _mapper.Map<Cliente>(ClienteDto);
        _unitOfWork.Clientes.Update(Cliente);
        await _unitOfWork.SaveAsync();
        return ClienteDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if(Cliente == null){
            return NotFound();
        }
        _unitOfWork.Clientes.Remove(Cliente);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
}
