var builder = WebApplication.CreateBuilder(args);

// Initialize environment variables
EnvironmentVariables.Initialize(builder.Configuration);

builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(EnvironmentVariables.ConnectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiServices();

app.Run();
