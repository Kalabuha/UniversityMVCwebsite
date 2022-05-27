using Microsoft.EntityFrameworkCore;
using Task20.DataContext.Initialization;
using Task20.DataContext.DataBaseContext;
using Task20.DataContext.Extensions;
using Task20.Repositories.Extensions;
using Task20.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DataBase");
if (string.IsNullOrEmpty(connectionString))
    throw new ArgumentNullException(nameof(connectionString));

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    UniversityDbContext context = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();
    InitializerDb.Initialize(context);
}

app.Run();
