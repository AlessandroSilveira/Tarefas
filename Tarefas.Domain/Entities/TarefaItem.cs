namespace Tarefas.Domain.Entities;
public class TarefaItem
{
    public Guid Id { get; set;}
    public string? Titulo { get; set;}

    public string? Descricao { get; set;}

    public bool Finalizado { get; set;}
}
