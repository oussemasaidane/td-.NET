using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServiceFlight, ServiceFlight>();
//IServiceFlight = new ServiceFlight();
builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();//Obligatoire!!//
//IunitOfWork UOW = new UnitOfWork(dbContext, Type);
builder.Services.AddDbContext<DbContext,AMContext>();//Obligatoire!!//
builder.Services
    .AddSingleton<Type>(p=>typeof(GenericRepository<>));//Obligatoire!!//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Privacy}/{id?}");

app.Run();
