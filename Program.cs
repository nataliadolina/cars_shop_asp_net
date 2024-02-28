using Shop.Data;
using Shop.Interfaces;
using Shop.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Shop.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json",
        optional: false,
        reloadOnChange: true);

string connection = builder.Configuration["DefaultConnection"];

builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
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
using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}
app.Run();
