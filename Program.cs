using Microsoft.EntityFrameworkCore;
using PrescriptionApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// ✅ Register DbContext with SQLite
builder.Services.AddDbContext<PrescriptionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PrescriptionContext")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Prescription}/{action=Index}/{id?}");

app.Run();

