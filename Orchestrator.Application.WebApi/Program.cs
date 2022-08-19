using Microsoft.EntityFrameworkCore;
using Orchestrator.Persistance.Common;
using Orchestrator.Persistance.DataAccess;
using Orchestrator.Persistance.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<OrchestratorContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(OrchestratorContext)}.db",
        x => x.MigrationsAssembly("Orchestrator.Application.WebApi")));

builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<TenantRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
