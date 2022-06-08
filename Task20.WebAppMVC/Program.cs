using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Task20.DataContext.Initialization;
using Task20.DataContext.DataBaseContext;
using Task20.DataContext.Extensions;
using Task20.Repositories.Extensions;
using Task20.Services.Extensions;
using Task20.ServicesApi;
using Task20.WebAppMVC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var connectionString = builder.Configuration.GetConnectionString("DataBase");
if (string.IsNullOrEmpty(connectionString))
    throw new ArgumentNullException(nameof(connectionString));

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.AddScoped<IUserContext, MvcUserContext>();
builder.Services.RegisterServicesApi("https://localhost:7205");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    UniversityDbContext context = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();
    InitializerDb.Initialize(context);
}

app.Run();
