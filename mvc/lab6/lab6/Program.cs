using lab6;
using lab6.Data;
using lab6.service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container."dependancy injection"
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<Istudent, StudentMoc>(); add transiant create new object each time
//builder.Services.AddSingleton<Istudent, StudentDB>();
//builder.Services.AddScoped<Istudent, StudentMoc>();
builder.Services.AddDbContext<ITIDBContext>(a =>
{
    a.UseSqlServer("Server=.;Database=mvc15;Trusted_Connection=True;");
});
builder.Services.AddSession();
builder.Services.AddTransient<Istudent, StudentDB>();

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();
//app.MapDefaultControllerRoute();
//app.MapControllerRoute(name:"xyz","iti/{controller}/{action}");
app.MapControllerRoute(name: "xyz", "iti/{action}",new {controller="student"});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=Index}/{id?}");

app.Run();
