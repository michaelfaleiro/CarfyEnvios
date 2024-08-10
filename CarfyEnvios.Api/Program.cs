using CarfyEnvios.Api.Filters;
using CarfyEnvios.Application.Services;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Infra.Data;
using CarfyEnvios.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.PedidoUseCase();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));


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

