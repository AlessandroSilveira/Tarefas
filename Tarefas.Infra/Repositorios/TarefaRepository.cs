using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Infra.Repositorios;
public class TarefaRepository : ITarefaRepository
{
    public static List<TarefaItem> _tarefas { get; set; } = new List<TarefaItem>();

    public IEnumerable<TarefaItem> ObterTodos()
    {
        return _tarefas;
    }

    public TarefaItem? ObterPorId(Guid Id)
    {
        return _tarefas.FirstOrDefault(p => p.Id == Id);
    }

    public TarefaItem Criar(TarefaItem tarefaItem)
    {
        _tarefas.Add(tarefaItem);
        return tarefaItem;
    }

    public TarefaItem? Atualizar(Guid Id, TarefaItem tarefaAtualizada)
    {
        var item = _tarefas.FirstOrDefault(t => t.Id == Id);

        item.Finalizado = tarefaAtualizada.Finalizado;
        item.Descricao = tarefaAtualizada.Descricao;
        item.Titulo = tarefaAtualizada.Titulo;

        return _tarefas.FirstOrDefault(x => x.Id == Id);
    }

    public bool Deletar(Guid Id)
    {
        var tarefa = _tarefas.FirstOrDefault(p => p.Id == Id);
        if (tarefa is not null)
        {
            _tarefas.Remove(tarefa);
            return true;
        }

        return false;
    }
}
