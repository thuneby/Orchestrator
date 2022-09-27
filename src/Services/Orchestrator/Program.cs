using BlobAccess.DataAccessLayer.Helpers;
using Configuration.Models;
using DataAccess.DataAccess;
using DataAccess.Models;
using DocumentAccess.DocumentAccessLayer;
using DocumentAccess.Models;
using EventBus.Abstractions;
using EventBus.Extensions;
using Ingestion.Controllers;
using Microsoft.EntityFrameworkCore;
using Parse.Controllers;
using StateMachine.BusinessLogic;
using System.Text.Json.Serialization;
using Convert.Controllers;
using Utilities.Ftp;
using Validate.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile($"ServiceConfig.json", optional: false);
builder.Services.Configure<ServiceConfig>(options => builder.Configuration.GetSection("ServiceConfig").Bind(options));

builder.Services.AddDbContextFactory<BlobContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BlobConnection")));

builder.Services.AddDbContextFactory<DocumentContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DocumentConnection")));

builder.Services.AddDbContextFactory<DomainContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DomainConnection")));

builder.Services.AddDbContextFactory<OrchestratorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrchestratorConnection"),
        x => x.MigrationsAssembly("Orchestrator")));

builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<FlowRepository>();
builder.Services.AddScoped<TenantRepository>();
builder.Services.AddScoped<FtpControllerFactory>();
builder.Services.AddScoped<InputFileRepository>();
builder.Services.AddScoped<IStorageHelper, SqlBlobStorageHelper>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<IEventBus, SqlEventBus>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<ReceiveFileController>();
builder.Services.AddScoped<ParseController>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<ConversionController>();
builder.Services.AddScoped<MasterDataRepository>();
builder.Services.AddScoped<ValidationController>();
builder.Services.AddScoped<ProcessorFactory>();
builder.Services.AddScoped<WorkFlowProcessor>();

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
}); 
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
