using System.Text.Json.Serialization;
using BlobAccess.DataAccessLayer.Helpers;
using DataAccess.DataAccess;
using DataAccess.Models;
using EventBus.Abstractions;
using EventBus.Extensions;
using Microsoft.EntityFrameworkCore;
using Utilities.Ftp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<BlobContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BlobConnection"),
        x => x.MigrationsAssembly("Ingestion")));
//builder.Services.AddDbContextFactory<OrchestratorContext>(opt =>
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrchestratorConnection")));

//builder.Services.AddScoped<ILoggerFactory, LoggerFactory>();
builder.Services.AddScoped<FtpControllerFactory>();
builder.Services.AddScoped<InputFileRepository>();
builder.Services.AddScoped<IStorageHelper, SqlBlobStorageHelper>();
//builder.Services.AddScoped<EventRepository>();
//builder.Services.AddScoped<IEventBus, SqlEventBus>();



builder.Services.AddControllers()
    .AddJsonOptions(opts =>
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
