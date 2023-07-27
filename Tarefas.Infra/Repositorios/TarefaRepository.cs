using Tarefas.Domain.Interfaces.Repositorios;
using Tarefas.Infra.Context;
using Tarefas.Domain.Entities;

namespace Tarefas.Infra.Repositorios;
public class TarefaRepository :ITarefaRepository
{
    private readonly AppDbContext _dbContext;

    public TarefaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<TarefaItem> ObterTodos()
    {
        return _dbContext.Set<TarefaItem>().AsEnumerable();
    }

    public TarefaItem? ObterPorId(Guid Id)
    {
        return _dbContext.Set<TarefaItem>().FirstOrDefault(p => p.Id == Id);
    }

    public TarefaItem Criar(TarefaItem tarefaItem)
    {
        _dbContext.Set<TarefaItem>().Add(tarefaItem);
         _dbContext.SaveChanges();
        return tarefaItem;
    }

    public TarefaItem? Atualizar(Guid Id, TarefaItem tarefaAtualizada)
    {
        var item = _dbContext.Set<TarefaItem>().FirstOrDefault(t => t.Id == Id);

        item.Finalizado = tarefaAtualizada.Finalizado;
        item.Descricao = tarefaAtualizada.Descricao;
        item.Titulo = tarefaAtualizada.Titulo;
        _dbContext.SaveChanges();
        return _dbContext.Set<TarefaItem>().FirstOrDefault(x => x.Id == Id);
        
    }

    public bool Deletar(Guid Id)
    {
        var tarefa = _dbContext.Set<TarefaItem>().FirstOrDefault(p => p.Id == Id);
        if (tarefa is not null)
        {
            _dbContext.Remove(tarefa);
             _dbContext.SaveChanges();
            return true;
        }

        return false;
    }
}
