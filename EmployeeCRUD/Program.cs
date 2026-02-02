using Microsoft.EntityFrameworkCore;
using EmployeeCRUD.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//WE ARE USING THE ChainSQL

builder.Services.AddDbContext<CrudEmployeeContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("ChainSQL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
