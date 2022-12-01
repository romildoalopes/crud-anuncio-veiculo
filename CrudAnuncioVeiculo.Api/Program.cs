using CrudAnuncioVeiculo.Api.Configurations;
using CrudAnuncioVeiculo.Domain.Handlers;
using CrudAnuncioVeiculo.Domain.Repositories;
using CrudAnuncioVeiculo.Domain.Services.Anuncio;
using CrudAnuncioVeiculo.Domain.Services.Config;
using CrudAnuncioVeiculo.Infra.Repositories;
using CrudAnuncioVeiculo.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RepositoryMap();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


