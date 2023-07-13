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

    public void Atualizar(Guid Id, TarefaItem tarefaAtualizada)
    {
        var todoItem = _tarefas.FirstOrDefault(x => x.Id == Id);
        foreach (var item in todoItem.Where(x => x.id == Id)) {
            item.age = 18;
        }
    }

    public void Deletar(Guid Id)
    {
        var tarefa = _tarefas.FirstOrDefault(p => p.Id == Id);
        _tarefas.Remove(tarefa);
    }
}
