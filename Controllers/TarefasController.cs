using Microsoft.AspNetCore.Mvc;

namespace Tarefas.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ILogger<TarefasController> _logger;

    public TarefasController(ILogger<TarefasController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ObterTodos()
    {
        return Ok();
    }
}
