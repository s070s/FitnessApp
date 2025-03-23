using FitnessApp.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//comment this and the FitnessApp.API.Data namespace if you want to delete and redo scaffolding/migrations
var connectionString = builder.Configuration.GetConnectionString("FitnessConnection");
if (connectionString != null)
{
    var dbPath = Path.Combine(builder.Environment.ContentRootPath, connectionString);
    builder.Services.AddDbContext<FitnessContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

}

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
