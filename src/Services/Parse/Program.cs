using BlobAccess.DataAccessLayer.Helpers;
using Dapr.Client;
using Dapr.Extensions.Configuration;
using DataAccess.DataAccess;
using DataAccess.Models;
using DocumentAccess.DocumentAccessLayer;
using DocumentAccess.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddDaprSecretStore("localsecretstore", new DaprClientBuilder().Build());

builder.Services.AddDbContextFactory<DocumentContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DocumentConnection"),
        x => x.MigrationsAssembly("Parse")));

builder.Services.AddDbContextFactory<BlobContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BlobConnection")));

builder.Services.AddScoped<InputFileRepository>();
builder.Services.AddScoped<IStorageHelper, SqlBlobStorageHelper>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();


builder.Services.AddControllers().AddDapr();
    //.AddJsonOptions(opts =>
    //{
    //    var enumConverter = new JsonStringEnumConverter();
    //    opts.JsonSerializerOptions.Converters.Add(enumConverter);
    //}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHostedService<ConsumeScopedServiceHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
