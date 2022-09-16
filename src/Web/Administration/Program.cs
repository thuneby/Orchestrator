using DataAccess.Models;
using DocumentAccess.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<BlobContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BlobConnection")));

builder.Services.AddDbContextFactory<DocumentContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DocumentConnection")));

builder.Services.AddDbContextFactory<OrchestratorContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrchestratorConnection")));


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
