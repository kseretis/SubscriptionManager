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
ConfigureCors();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend"); // Use the CORS policy

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/swagger");
});

app.Run();

#region Helpers

void ConfigureCors()
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend",
            policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200") // Angular Frontend
                            .AllowAnyHeader()
                            .AllowAnyMethod());
     });
}

void ConfigureRepositories()
{
    services.AddScoped<UserRepository>();
    services.AddScoped<ProgramRepository>();
}

void ConfigureServices()
{
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IProgramService, ProgramService>();
}

void ConfigureDatabase()
{
    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgresDb")));
}

#endregion