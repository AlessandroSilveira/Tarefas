namespace Tarefas.Infra.Context;

using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<TarefaItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
          modelBuilder.Entity<TarefaItem>(entity => 
          {
               entity.ToTable("TarefasItem"); 
               entity.HasKey(e => e.Id); 
               entity.Property(e => e.Titulo).IsRequired();
               entity.Property(e => e.Descricao).IsRequired();  
               entity.Property(e => e.Finalizado).IsRequired(); 
          }); 
     } 
}