using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Models;
using RepositoryStore.Repositories;
using RepositoryStore.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services.AddTransient<IProductRepository,ProductRepository>();

var app = builder.Build();

app.MapGet("", () => "Funcionando");

app.MapGet("/v1/products", async (IProductRepository repository) 
	=> Results.Ok(await repository.GetAllAsync()));

app.MapGet("/v1/products/{id}", async (IProductRepository repository, int id) 
	=> Results.Ok(await repository.GetById(id)));

app.MapPost("/v1/products", async (IProductRepository repository, Product product) 
	=>	Results.Ok(await repository.CreateAsync(product)));

app.MapPut("/v1/products", async (IProductRepository repository, Product product)
	=> Results.Ok(await repository.UpdateAsync(product)));

app.MapDelete("/v1/products/{id}", async (IProductRepository repository, int id) =>
{
	var product = await repository.GetById(id);
	repository.DeleteAsync(product);
	return Results.Ok();
});

app.Run();
