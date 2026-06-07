using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;
using BankMlekaBackendApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<BankMlekaBackendApp.Models.BankMlekaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<BankMlekaBackendApp.Services.IAuthService, BankMlekaBackendApp.Services.AuthService>();

// OpenAPI and Scalar UI
builder.Services.AddOpenApi();

var app = builder.Build();

// Apply migrations and seed admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<BankMlekaBackendApp.Models.BankMlekaContext>();
    // run migrations
    db.Database.Migrate();

    // seed admin
    var exists = db.Set<BankMlekaBackendApp.Models.User>().Any(u => u.Login == "admin");
    if (!exists)
    {
        var user = new BankMlekaBackendApp.Models.User { Login = "admin" };
        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<BankMlekaBackendApp.Models.User>();
        user.PasswordHash = hasher.HashPassword(user, "admin123");
        db.Set<BankMlekaBackendApp.Models.User>().Add(user);
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
