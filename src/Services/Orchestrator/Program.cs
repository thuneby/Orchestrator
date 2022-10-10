using Dapr.Client;
using Dapr.Extensions.Configuration;
using DataAccess.DataAccess;
using DataAccess.Models;
using EventBus.Abstractions;
using EventBus.Extensions;
using Microsoft.EntityFrameworkCore;
using StateMachine.BusinessLogic;
using System.Text.Json.Serialization;
using Orchestrator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration.AddJsonFile($"ServiceConfig.json", optional: false);
//builder.Services.Configure<ServiceConfig>(options => builder.Configuration.GetSection("ServiceConfig").Bind(options));

builder.Configuration.AddDaprSecretStore("localsecretstore", new DaprClientBuilder().Build());

builder.Services.AddDbContextFactory<DomainContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DomainConnection")));

builder.Services.AddDbContextFactory<OrchestratorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrchestratorConnection"),
        x => x.MigrationsAssembly("Orchestrator")));

builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<FlowRepository>();
builder.Services.AddScoped<TenantRepository>();
builder.Services.AddScoped<ParameterRepository>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<IEventBus, DaprEventBus>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<ProcessorFactory>();
builder.Services.AddScoped<WorkFlowProcessor>();

builder.Services.AddControllers().AddDapr()
    .AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.AddCaching();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();

app.UseRouting();
app.UseCloudEvents();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapSubscribeHandler();
    endpoints.MapControllers();
});

app.Run();
