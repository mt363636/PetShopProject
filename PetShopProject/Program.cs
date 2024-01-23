using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Data;
using PetShopProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetShopDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
    var identityContext = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
    identityContext.Database.Migrate();

}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");

app.Run();

