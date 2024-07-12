using Microsoft.AspNetCore.Mvc;
using NGPD.Manager.Entities;

namespace NGPD.Manager.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunoController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IList<Aluno>>> GetAll()
    {
        return Ok();
    }
}