using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces.Repositorios;
public interface ITarefaRepository
{
    IEnumerable<TarefaItem> ObterTodos();
    TarefaItem ObterPorId(Guid Id);
    TarefaItem Criar(TarefaItem tarefaItem);
    TarefaItem Atualizar(Guid Id, TarefaItem todoItem);
    bool Deletar(Guid Id);
}
