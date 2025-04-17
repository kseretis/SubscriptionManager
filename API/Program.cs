using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Set up
services.AddControllers();
ConfigureRepositories();
ConfigureServices();
ConfigureDatabase();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/swagger");
});

app.Run();

#region Helpers

void ConfigureRepositories()
{
    services.AddScoped<UserRepository>();
}

void ConfigureServices()
{
    services.AddScoped<IUserService, UserService>();
}

void ConfigureDatabase()
{
    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgresDb")));
}

#endregion