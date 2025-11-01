using Blog.Application.Extensions;
using Blog.Infra.Data;
using Blog.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar Entity Framework
builder.Services.AddDbContext<Context>(options =>
{
    // Para desenvolvimento, usar InMemory Database
    if (builder.Environment.IsDevelopment())
    {
        options.UseInMemoryDatabase("BlogDatabase");
    }
    else
    {
        // Para produção, você pode configurar SQL Server ou outro provedor
        // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.UseInMemoryDatabase("BlogDatabase"); // Mantendo InMemory por enquanto
    }
});

// Registrar serviços da aplicação
builder.Services.AddApplicationServices();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Aplicar seed de dados
await app.Services.EnsureDatabaseSeededAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
