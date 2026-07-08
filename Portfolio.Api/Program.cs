var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
var initializeDatabase = app.Configuration.GetValue<bool>("InitializeDatabase:InitializeOnStartup");
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    if (initializeDatabase)
    {
        var dbInitializer = new DatabaseInitializer(app.Configuration);
        dbInitializer.Initialize();
    }
}

app.UseHttpsRedirection();


//TODO: map endpoints for the API here


app.Run();
