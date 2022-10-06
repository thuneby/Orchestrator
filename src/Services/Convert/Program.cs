using Dapr.Client;
using Dapr.Extensions.Configuration;
using DataAccess.DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddDaprSecretStore("localsecretstore", new DaprClientBuilder().Build());

builder.Services.AddDbContextFactory<DomainContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DomainConnection"),
        x => x.MigrationsAssembly("Convert")));

builder.Services.AddScoped<PaymentRepository>();
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
