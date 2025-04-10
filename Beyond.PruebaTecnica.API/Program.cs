using Beyond.PruebaTecnica.Abstractions.Services;
using Beyond.PruebaTecnica.Abstractions.Repositories;
using Beyond.PruebaTecnica.Repositories;
using Beyond.PruebaTecnica.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITodoListRepository, TodoListRepository>();  
builder.Services.AddScoped<ITodoList, TodoListService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
