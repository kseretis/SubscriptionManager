using SubscriptionManager.Individual;
using SubscriptionManager.Individual.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
ConfigureServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();

#region Helpers

void ConfigureServices()
{
    builder.Services.AddSingleton<IIndividualService, IndividualService>();
}

#endregion