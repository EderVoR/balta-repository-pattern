using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Repositories;
using RepositoryStore.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services.AddTransient<IProductRepository,ProductRepository>();

var app = builder.Build();

app.MapGet("/v1/products", () => "Hello World!");
app.MapPost("/v1/products", () => "Hello World!");
app.MapPut("/v1/products", () => "Hello World!");
app.MapDelete("/v1/products", () => "Hello World!");

app.Run();
