using Portfolio.Api.Context;
using Portfolio.Api.Initialization;
using Portfolio.Api.Project;
using Portfolio.Api.Site;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddConfiguredContextDependencies();
builder.Services.AddProjectDependencies();
builder.Services.AddSiteDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
var initializeDatabase = app.Configuration.GetValue<bool>("InitializeDatabase:InitializeOnStartup");
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    if (initializeDatabase)
    {
        using var scope = app.Services.CreateScope();
        var mongoContext = scope.ServiceProvider.GetRequiredService<IPortfolioContext>();
        var database = mongoContext.Database;
        await DatabaseInitializer.ResetAndInitializeAsync(database);
    }
}

app.UseHttpsRedirection();


//TODO: map endpoints for the API here
//app.MapProjectEndpoints();
app.MapGet("/health", () => Results.Ok(new { status = "Healthy", timestamp = DateTime.UtcNow }));
app.MapProjectEndpoints();
app.MapSiteEndpoints();


app.Run();
