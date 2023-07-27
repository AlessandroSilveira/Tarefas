using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Interfaces.Repositorios;
using Tarefas.Infra.Context;
using Tarefas.Infra.Repositorios;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Tarefas", Version = "v1" });
});

 builder.Services.AddDbContext<AppDbContext>
 (
    options => options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
 );

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarefas V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();

app.Run();
