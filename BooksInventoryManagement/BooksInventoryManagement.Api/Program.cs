using BooksInventoryManagement.Api.Middleware;
using BooksInventoryManagement.Application;
using BooksInventoryManagement.Infrastructure;
using BooksInventoryManagement.Infrastructure.Repository.Auth;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SQLitePCL.Batteries.Init();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Replace with your Angular app URL
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // Use if your app requires cookies/authentication
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Ensure database is created
    context.Database.EnsureCreated();

    // Seed roles and admin user
    await SeedIdentityData.SeedRolesAndAdmin(userManager, roleManager);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowAngularClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
