using App.Models;
using App.Services;
using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var databaseProvider = builder.Configuration["DatabaseProvider"];
builder.Services.AddDbContext<AppDbContext>(options =>
{
    switch (databaseProvider)
    {
        case "Sqlite":
            options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"), o => o.MigrationsAssembly("App.Sqlite"));
            break;
        case "SqlServer":
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), o => o.MigrationsAssembly("App.SqlServer"));
            break;
        case "Postgres":
            options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"), o => o.MigrationsAssembly("App.Postgres"));
            break;
        case "InMemory":
            options.UseInMemoryDatabase("InMemory");
            break;
        default:
            throw new InvalidOperationException("Invalid database provider");
    }
});

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<AuthService>();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
});

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
