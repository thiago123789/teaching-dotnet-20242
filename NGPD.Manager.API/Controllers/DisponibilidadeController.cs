using Microsoft.AspNetCore.Mvc;
using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities.Disponibilidade;
using NGPD.Manager.Entities.DTO;

namespace NGPD.Manager.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DisponibilidadeController : ControllerBase
{
    private readonly IDisponibilidadeService _disponibilidadeService;

    public DisponibilidadeController(IDisponibilidadeService disponibilidadeService)
    {
        this._disponibilidadeService = disponibilidadeService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Disponibilidade>>> GetAll()
    {
        var disponibilidades = await _disponibilidadeService.GetAllDisponibilidade();
        return Ok(disponibilidades);
    }

    [HttpPost]
    public async Task<ActionResult<Disponibilidade>> CreateDisponibilidade([FromBody] DisponibilidadeInputDto disponibilidadeInputDto)
    {
        var disponibilidade = await _disponibilidadeService.CreateDisponibilidade(disponibilidadeInputDto);
        return Ok(disponibilidade);
    } 
    
}