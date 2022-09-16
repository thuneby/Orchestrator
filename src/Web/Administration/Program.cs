using BlobAccess.DataAccessLayer.Helpers;
using DataAccess.DataAccess;
using DataAccess.Models;
using DocumentAccess.DocumentAccessLayer;
using DocumentAccess.Models;
using EventBus.Abstractions;
using EventBus.Extensions;
using Microsoft.EntityFrameworkCore;
using Utilities.Ftp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<BlobContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BlobConnection")));

builder.Services.AddDbContextFactory<DocumentContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DocumentConnection")));

builder.Services.AddDbContextFactory<OrchestratorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrchestratorConnection")));

builder.Services.AddScoped<IFtpController, FileController>();
builder.Services.AddScoped<InputFileRepository>();
builder.Services.AddScoped<IStorageHelper, SqlBlobStorageHelper>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<IEventBus, SqlEventBus>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
