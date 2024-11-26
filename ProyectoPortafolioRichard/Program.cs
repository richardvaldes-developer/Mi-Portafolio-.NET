using Microsoft.EntityFrameworkCore;
using ProyectoPortafolioRichard.Data;
using ProyectoPortafolioRichard.Services;

var builder = WebApplication.CreateBuilder(args);

//Apis Services Builder
builder.Services.AddHttpClient<GitHubService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de servicios
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
