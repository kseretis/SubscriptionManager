using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Database;
using SubscriptionManager.Endpoints.Individual;
using SubscriptionManager.Endpoints.Users;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Set up
services.AddControllers();
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

void ConfigureServices()
{
    services.AddScoped<IUserRepository, UserService>();
    services.AddSingleton<IIndividualRepository, IndividualService>();
}

void ConfigureDatabase()
{
    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
}

#endregion