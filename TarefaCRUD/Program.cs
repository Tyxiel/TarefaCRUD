using Microsoft.EntityFrameworkCore;
using TarefaCRUD.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TarefaDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Scaffold-DbContext "Server=PC03LAB2814\SENAI; Database=TarefaDB; User=sa; Password=senai.123" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
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
