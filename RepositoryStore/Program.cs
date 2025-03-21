using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
