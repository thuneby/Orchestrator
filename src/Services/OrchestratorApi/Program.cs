using Configuration.Models;
using DataAccess.DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StateMachine.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile($"ServiceConfig.json", optional: false);
builder.Services.Configure<ServiceConfig>(options => builder.Configuration.GetSection("ServiceConfig").Bind(options));

builder.Services.AddDbContextFactory<OrchestratorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrchestratorConnection"),
        x => x.MigrationsAssembly("OrchestratorApi")));

builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<TenantRepository>();
builder.Services.AddScoped<WorkFlowProcessor>();

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
