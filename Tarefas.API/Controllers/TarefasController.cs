using Microsoft.AspNetCore.Mvc;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefaRepository _tarefaRepository;

    public TarefasController(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    [HttpGet]
    public IActionResult ObterTarefas()
    {
        var produtos = _tarefaRepository.ObterTodos();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public IActionResult ObterTarefa(Guid id)
    {
        var produto = _tarefaRepository.ObterPorId(id);

        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpPost]
    public IActionResult CreateProduto(TarefaItem tarefaItem)
    {
        _tarefaRepository.Criar(tarefaItem);
        return CreatedAtAction(nameof(ObterTarefa), new { id = tarefaItem.Id }, tarefaItem);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarTarefa(Guid id, TarefaItem tarefa)
    {
        var tarefaAntiga = _tarefaRepository.ObterPorId(id);
        if (tarefaAntiga is null)
        {
            return NotFound();
        }

        _tarefaRepository.Atualizar(id, tarefa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarTarefa(Guid id)
    {       
        _tarefaRepository.Deletar(id);

        return NoContent();
    }
}
