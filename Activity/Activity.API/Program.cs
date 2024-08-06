using Activity.API;
using Activity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Initialize environment variables
EnvironmentVariables.Initialize(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// TO ADD MORE SERVICE
builder.Services.AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(EnvironmentVariables.ConnectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
