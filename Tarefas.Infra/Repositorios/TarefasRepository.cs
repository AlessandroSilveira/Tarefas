using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repositorios;
using System.Linq;

namespace Tarefas.Infra.Repositorios;
public class TarefasRepository : ITarefaRepository
{
     private readonly List<TarefaItem> _tarefas;

    public TarefasRepository()
    {
        _tarefas = new List<TarefaItem>();
    }

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
        foreach (var item in _tarefas.Where(x => x.Id == Id)) {
            item.Finalizado = tarefaAtualizada.Finalizado;
            item.Descricao = tarefaAtualizada.Descricao;
            item.Titulo = tarefaAtualizada.Titulo;
        }

        return _tarefas.FirstOrDefault(x => x.Id == Id);
    }

    public bool Deletar(Guid Id)
    {
        var tarefa = _tarefas.FirstOrDefault(p => p.Id == Id);
        if(tarefa is not null){
            _tarefas.Remove(tarefa);
            return true;
        }
        
        return  false;  
    }
}
