namespace Tarefas.Domain.Interfaces.Repositorios;
public interface ITarefaRepository
{
    IEnumerable<TarefaItem> ObterTodos();
    TarefaItem ObterPorId(Guid Id);
    TarefaItem Criar(TarefaItem tarefaItem);
    void Atualizar(Guid Id, TarefaItem todoItem);
    void Deletar(Guid Id);
}
